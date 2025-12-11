using UnityEngine;
// All game events are listed here


/// <summary>
/// Published by the dying enemy, it contains the enemy object
/// and enemy data
/// </summary>
public class EnemyDieEventData : EventData
{
    public Enemy enemy;
    public GameObject enemyObject;
    public EnemyDieEventData(Enemy pEnemy, GameObject pEnemyObject)
    {
        name = "EnemyDieEvent";
        enemy = pEnemy;
        enemyObject = pEnemyObject;
    }

    //Overriding ToString method to display event information for debugging
    public override string ToString()
    {
        if (enemyObject == null)
            return "Enemy object already destroyed";
        else
        {
            return "Event name: " + name + "\n" +
                   "Enemy died at position: " + enemyObject.transform.position + "\n"
                    + "Enemy Droped Money: " + enemy.Money
                    + "\n" + "Enemy gave XP: " + enemy.XP;
        }
    }
}

/// <summary>
/// Published by the skill controller, it contains the position of the caster
/// and the skill data
/// </summary>

public class SkillEventData : EventData
{
    public SkillData skillData;
    public GameObject skillCaster;
    public SkillEventData(SkillData pSkillData,GameObject pSkillCaster)
    {
        name = "SkillUsedEvent";
        skillData = pSkillData;
        skillCaster = pSkillCaster;
    }

    //Overriding ToString method to display event information for debugging
    public override string ToString()
    {
        return "Event name: " + name + "\n" +
            "Skill casted by: " + skillCaster.name;
    }

}