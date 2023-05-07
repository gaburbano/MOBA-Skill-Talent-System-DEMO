using System.Collections.Generic;

public class Skill
{
    public string name;
    public string description;
    public float manaCost;
    public float cooldown;
    public List<SkillEffect> effects;
    internal float damage;
}