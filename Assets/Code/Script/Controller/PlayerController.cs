using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Skill[] skills;
    public Talent[] talents;

    // Public variables for player movement and targeting
    public float moveSpeed = 5.0f;
    public float attackRange = 2.0f;
    public float attackCooldown = 1.0f;
    public Transform target;

    // Private variables for player state and attacking
    private bool isMoving = false;
    private bool isAttacking = false;
    private float attackTimer = 0.0f;

    void Update()
    {
        // Check if player has a target
        if (target != null)
        {
            // Move towards the target
            Vector3 direction = target.position - transform.position;
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

            // Check if player is in attack range
            if (direction.magnitude <= attackRange)
            {
                // Check if attack is off cooldown
                if (!isAttacking && Time.time > attackTimer)
                {
                    // Start attacking
                    isMoving = false;
                    isAttacking = true;
                    attackTimer = Time.time + attackCooldown;

                    // Play attack animation and deal damage to target
                    // Replace this code with your own attack animation and damage logic
                    if (GetComponent<Animator>() != null)
                    {
                        GetComponent<Animator>().SetTrigger("Attack");
                    }
                    target.GetComponent<Health>().TakeDamage(10);
                }
            }
            else
            {
                // Move towards the target
                isMoving = true;
                isAttacking = false;
            }
        }
        else
        {
            // Stop moving and attacking if no target
            isMoving = false;
            isAttacking = false;
        }

        // Update player animation state
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetBool("IsMoving", isMoving);
            animator.SetBool("IsAttacking", isAttacking);
        }
    }

    void UseSkill(int skillIndex) {
        Skill skill = skills[skillIndex];
        // apply all skill effects to target(s)
        foreach (SkillEffect effect in skill.effects) {
            // apply effect
            if (effect.type == "damage") {
                // apply damage to target
                // ...
            } else if (effect.type == "heal") {
                // apply healing to target
                // ...
            } else if (effect.type == "buff") {
                // apply buff to target
                // ...
            }
            // play VFX, if applicable
            if (effect.vfx != null) {
                // spawn particle effect
                GameObject vfxObj = Instantiate(effect.vfx.particleEffect, target.position, Quaternion.identity);
                // destroy particle effect after duration
                Destroy(vfxObj, effect.vfx.duration);
            }
        }
    }
    
    void ApplyTalent(int talentIndex, int skillIndex) {
        Talent talent = talents[talentIndex];
        Skill targetSkill = skills[skillIndex];
        // apply all talent modifiers to target skill
        foreach (TalentModifier modifier in talent.modifiers) {
            if (modifier.targetSkill == targetSkill) {
                // modify skill attribute
                if (modifier.modificationType == "damage") {
                    targetSkill.damage += modifier.modificationValue;
                } else if (modifier.modificationType == "manaCost") {
                    targetSkill.manaCost -= modifier.modificationValue;
                }
                // play VFX, if applicable
                if (modifier.vfx != null) {
                    // spawn particle effect
                    GameObject vfxObj = Instantiate(modifier.vfx.particleEffect, target.position, Quaternion.identity);
                    // destroy particle effect after duration
                    Destroy(vfxObj, modifier.vfx.duration);
                }
            }
        }
    }
}