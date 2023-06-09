using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Hero : MonoBehaviour
{
    public string name;
    public string description;

    public float moveSpeed = 5.0f;
    public float stopDistance = 0.1f;
    public float attackRange = 2.0f;
    public float attackCooldown = 1.0f;

    public List<Skill> skills = new List<Skill>();

    public SkillData skillSO;

    void Awake() {
	}
}