using System.Collections.Generic;

[System.Serializable]
public class Talent {
    public string name;
    public string description;
    public List<TalentModifier> modifiers;
}