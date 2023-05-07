using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Skill[] skills;
    public Talent[] talents;

    public float moveSpeed = 5.0f;
    public float stopDistance = 0.1f;
    public float attackRange = 2.0f;
    public float attackCooldown = 1.0f;
    public Transform target;

    private bool isMoving = false;
    private bool isAttacking = false;
    private float attackTimer = 0.0f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 movementTargetPosition;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(1)) {
            movementTargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if ((Vector2)transform.position != movementTargetPosition) {
            transform.position = Vector2.MoveTowards(transform.position, movementTargetPosition, moveSpeed * Time.deltaTime);
        }

        if (target != null) {
            Vector3 direction = target.position - transform.position;
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

            if (direction.magnitude <= attackRange) {
                if (!isAttacking && Time.time > attackTimer) {
                    isMoving = false;
                    isAttacking = true;
                    attackTimer = Time.time + attackCooldown;

                    if (GetComponent<Animator>() != null) {
                        GetComponent<Animator>().SetTrigger("Attack");
                    }
                    target.GetComponent<Health>().TakeDamage(10);
                }
            } else {
                isMoving = true;
                isAttacking = false;
            }
        } else {
            isMoving = false;
            isAttacking = false;
        }

        Animator animator = GetComponent<Animator>();
        if (animator != null) {
            animator.SetBool("IsMoving", isMoving);
            animator.SetBool("IsAttacking", isAttacking);
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (Vector2.Distance(transform.position, movementTargetPosition) < stopDistance) {
            rb.velocity = Vector2.zero;
        }
    }

    void UseSkill(int skillIndex) {
        Skill skill = skills[skillIndex];
        foreach (SkillEffect effect in skill.effects) {
            if (effect.type == SkillEffectType.DAMAGE) {
                // apply damage to target
            } else if (effect.type == SkillEffectType.HEAL) {
                // apply healing to target
            } else if (effect.type == SkillEffectType.BUFF) {
                // apply buff to target
            }
            if (effect.vfx != null) {
                GameObject vfxObj = Instantiate(effect.vfx.particleEffect, target.position, Quaternion.identity);
                Destroy(vfxObj, effect.vfx.duration);
            }
        }
    }
    
    void ApplyTalent(int talentIndex, int skillIndex) {
        Talent talent = talents[talentIndex];
        Skill targetSkill = skills[skillIndex];
        foreach (TalentModifier modifier in talent.modifiers) {
            if (modifier.targetSkill == targetSkill) {
                if (modifier.modificationType == TalentModifierType.DAMAGE) {
                    targetSkill.damage += modifier.modificationValue;
                } else if (modifier.modificationType == TalentModifierType.MANA_COST) {
                    targetSkill.manaCost -= modifier.modificationValue;
                }
                if (modifier.vfx != null) {
                    GameObject vfxObj = Instantiate(modifier.vfx.particleEffect, target.position, Quaternion.identity);
                    Destroy(vfxObj, modifier.vfx.duration);
                }
            }
        }
    }
}