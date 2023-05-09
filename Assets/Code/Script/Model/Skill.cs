using System.Collections.Generic;

[System.Serializable]
public class Skill
{
    public string name;
    public string description;
    public float manaCost;
    public float cooldown;
    public List<SkillEffect> effects;
    public List<Talent> talents = new List<Talent>();
    internal float damage;
}