using UnityEngine;

public class HeroController : MonoBehaviour {
    public Hero hero;
    public Transform target;

    private bool _isMoving = false;
    private bool _isAttacking = false;
    private float _attackTimer = 0.0f;

    private Rigidbody2D _rb;
    private Vector2 _movement;
    private Vector2 _movementTargetPosition;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        hero = GetComponent<Hero>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(1)) {
            _movementTargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if ((Vector2)transform.position != _movementTargetPosition) {
            transform.position = Vector2.MoveTowards(transform.position, _movementTargetPosition, hero.moveSpeed * Time.deltaTime);
        }

        if (target != null) {
            Vector3 direction = target.position - transform.position;
            transform.Translate(direction.normalized * hero.moveSpeed * Time.deltaTime, Space.World);

            if (direction.magnitude <= hero.attackRange) {
                if (!_isAttacking && Time.time > _attackTimer) {
                    _isMoving = false;
                    _isAttacking = true;
                    _attackTimer = Time.time + hero.attackCooldown;

                    if (GetComponent<Animator>() != null) {
                        GetComponent<Animator>().SetTrigger("Attack");
                    }
                    target.GetComponent<Health>().TakeDamage(10);
                }
            } else {
                _isMoving = true;
                _isAttacking = false;
            }
        } else {
            _isMoving = false;
            _isAttacking = false;
        }

        Animator animator = GetComponent<Animator>();
        if (animator != null) {
            animator.SetBool("IsMoving", _isMoving);
            animator.SetBool("IsAttacking", _isAttacking);
        }
    }

    void FixedUpdate() {
        _rb.MovePosition(_rb.position + _movement * hero.moveSpeed * Time.fixedDeltaTime);

        if (Vector2.Distance(transform.position, _movementTargetPosition) < hero.stopDistance) {
            _rb.velocity = Vector2.zero;
        }
    }

    void UseSkill(int skillIndex) {
        Skill skill = hero.skills[skillIndex];
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
        Talent talent = hero.talents[talentIndex];
        Skill targetSkill = hero.skills[skillIndex];
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