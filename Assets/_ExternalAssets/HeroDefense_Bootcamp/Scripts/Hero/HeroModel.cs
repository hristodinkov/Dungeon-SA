using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

/// <summary>
/// Hero model, manages XP, leveling, damage scaling, and skills.
/// </summary>
public class HeroModel : MonoBehaviour
{

    public event Action<int> onLevelUp; // Event triggered when the hero levels up todo: use this to implement
                                        //an observer pattern for the hero, so that when the hero levels up, the GUI level number also updates and
                                        //a VFX is played on the hero to indicate the level-up.

    #region "hero setup, no need to change"
    [Header("Hero attribtues")]
    [SerializeField]
    private DamageData initialDamageData; // Initial base damage data for the hero

    [SerializeField]
    private DamageData levelUpIncreaseData; // Damage enhancement per level

    private DamageData currentDamageData; // The damage data the hero currently has

    [SerializeField]
    private float attackInterval = 0.5f; // Time between hero's attacks

    public Skill[] skills; // A linear skill tree, saved in an array

    public int[] xpNeededForEachLevel; // An array to set needed XP to level up for each level

    private int currentXP = 0; // Current accumulated experience points

    private int currentLevel = 1; // Current hero level, starts at level 1

    [Header("Controllers")]
    [SerializeField]
    private AttackController attackController; // Controls hero's attacks

    [SerializeField]
    private SkillController skillControllerPrefab; // Prefab used to represent each skill in the UI

    [SerializeField]
    private GameObject skillPanel; // Parent UI panel where skill controllers are added

    [Header("XP Bar display")]
    [SerializeField]
    private Image xpBar; // UI progress bar showing current XP progress
    #endregion

    

    private void Start()
    {
        // Initialize current damage with the initial damage values
        currentDamageData = initialDamageData;

        // Initialize the attack controller with the damage data and attack interval
        attackController.Init(ref currentDamageData, attackInterval);

        // Instantiate skill controllers for each skill in the skill tree
        for (int i = 0; i < skills.Length; i++)
        {
            SkillController skillController = Instantiate(skillControllerPrefab);
            skillController.transform.SetParent(skillPanel.transform, false);
            skillController.Init(ref skills[i], this);
        }

        // Initialize XP bar to empty
        xpBar.fillAmount = 0f;
    }

    public void OnEnemyKilled(EventData eventData)
    {
        // Only process XP if the hero hasn't reached the final level
        if (currentLevel <= xpNeededForEachLevel.Length)
        {
            // Cast event data to EnemyDieEventData to access XP reward
            EnemyDieEventData enemyDieEventData = (EnemyDieEventData)eventData;

            // Add enemy's XP value to hero's current XP
            currentXP += enemyDieEventData.enemy.XP;

            int previousLevel = currentLevel;

            // Check for multiple level-ups if XP is enough
            while (currentXP >= xpNeededForEachLevel[currentLevel - 1])
            {
                // Increase hero's damage values according to level-up bonuses
                currentDamageData.damage += levelUpIncreaseData.damage;
                currentDamageData.slowDown += levelUpIncreaseData.slowDown;
                currentDamageData.slowDownTime += levelUpIncreaseData.slowDownTime;

                // Subtract XP needed for this level
                currentXP -= xpNeededForEachLevel[currentLevel - 1];

                // Increase hero's level
                currentLevel++;

                // Break if max level is reached
                if (currentLevel > xpNeededForEachLevel.Length)
                {
                    break;
                }
            }

            // If hero reached max level, fill XP bar completely
            if (currentLevel == xpNeededForEachLevel.Length + 1)
            {
                xpBar.fillAmount = 1f;
            }
            else
            {
                // Otherwise, update XP bar based on progress toward next level
                xpBar.fillAmount = (float)currentXP / (float)xpNeededForEachLevel[currentLevel - 1];
            }

            // Trigger level-up event if level increased
            if (currentLevel > previousLevel)
            {
                onLevelUp?.Invoke(currentLevel);
            }
        }
    }
}