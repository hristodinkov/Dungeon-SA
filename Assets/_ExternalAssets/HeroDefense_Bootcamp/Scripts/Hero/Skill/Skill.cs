using UnityEngine;
using System;

/// <summary>
/// Basic skill class contains required level, cost to buy the skill, if it's learned
/// and the skill data.
/// </summary>
[Serializable]
public class Skill
{
    public int requiredLevel;
    public int cost;
    public bool learned;
    public SkillData skillData;
}
