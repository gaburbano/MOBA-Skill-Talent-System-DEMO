using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class SkillData : ScriptableObject
{
    [SerializeField] public string name;
    [SerializeField] public string description;
    [SerializeField] public float manaCost;
    [SerializeField] public float cooldown;
    [SerializeField] public float damage;
    [SerializeField] public List<SkillEffect> effects;
    [SerializeField] public List<Talent> talents = new List<Talent>();
}