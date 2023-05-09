using UnityEngine;
using System.Collections.Generic;

public class HeroData : ScriptableObject
{
    public GameObject prefab;
    public string name;
    public string description;


    public float maxHealth;
    public float maxMana;


    public float moveSpeed = 5.0f;
    public float stopDistance = 0.1f;
    public float attackRange = 2.0f;
    public float attackCooldown = 1.0f;

    public List<SkillData> skills;
}

public class SkillData
{
    public string name;
    public string description;
    public float manaCost;
    public float cooldown;
    internal float damage;
}