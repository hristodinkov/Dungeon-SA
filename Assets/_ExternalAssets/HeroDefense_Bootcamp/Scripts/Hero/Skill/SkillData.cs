using UnityEngine;

/// <summary>
/// A ScriptableObject class for skill data.
/// </summary>
[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Objects/SkillData")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public float range;
    public float coolDown;
    public Sprite icon;
    public Sprite iconGrey;//For inactive/cooldown visual
    public ParticleSystem vfx;

    //Damage data this skill deals when it hits enemies
    public DamageData damageData;
}
