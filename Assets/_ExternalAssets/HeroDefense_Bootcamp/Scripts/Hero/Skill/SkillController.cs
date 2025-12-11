using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

/// <summary>
/// Handles UI and interaction logic for an individual skill,
/// including display, cooldown, purchase, and availability based on hero level.
/// This class is an observer of HeroModel hero, it subscribes/unsubscribes its
/// onLevelUp event to get updates about the hero's level, based on which it decides
/// whether or not to unlock the skill
/// </summary>
public class SkillController : MonoBehaviour
{
    [SerializeField]
    private GameEvent skillEvent; // Event to publish when the skill is used

    [SerializeField]
    private Skill skill; // Reference to the associated skill data

    [SerializeField]
    private Button skillButton; // UI button used to activate the skill

    [SerializeField]
    private Image skillIcon; // Icon shown in the skill UI (non-interactive display)

    [SerializeField]
    private Image coolDownIcon; // UI overlay used to show cooldown progress

    [SerializeField]
    private TextMeshProUGUI skillText; // Displays skill name and required level

    private HeroModel hero; // Reference to the owning hero

    [SerializeField]
    private BuyButton buyButton; // UI element to allow purchasing the skill

    [SerializeField]
    private IntValue money; // Money ScriptableObject

    /// <summary>
    /// Initializes the skill controller with the specified skill and hero context.
    /// Sets up the button, visuals, and level-based availability.
    /// </summary>
    public void Init(ref Skill pSkill, HeroModel pHero)
    {
        skill = pSkill;
        hero = pHero;

        // This is an observer implementation: subscribe to hero level up events to manage unlock visibility
        hero.onLevelUp += OnHeroLeveledUp;

        // Display skill name and level requirement
        skillText.text = "Lv" + skill.requiredLevel.ToString() + " " + skill.skillData.skillName;

        // Set the default greyed-out skill icon
        skillIcon.sprite = skill.skillData.iconGrey;

        // Set up the skill button icon and transition states
        skillButton.image.sprite = skill.skillData.icon;
        skillButton.transition = Selectable.Transition.SpriteSwap;

        // Define the grey icon for the disabled state
        SpriteState spriteState = skillButton.spriteState;
        spriteState.disabledSprite = skill.skillData.iconGrey;
        skillButton.spriteState = spriteState;

        // Button is disabled by default until the skill is unlocked and purchased
        skillButton.interactable = false;

        // Set up cooldown icon with the same sprite
        coolDownIcon.sprite = skill.skillData.icon;

        // Initialize the buy button with the skill's cost
        buyButton.Init(skill.cost);

        // Hide the skill button until unlocked
        skillButton.gameObject.SetActive(false);

        // Check if the skill should be shown based on current level
        OnHeroLeveledUp(1);
    }

    /// <summary>
    /// Called when the skill is used.
    /// Publishes the skill event and starts the cooldown process.
    /// </summary>
    public void OnSkillUsed()
    {
        // Publish the skill event with skill data and hero GameObject
        skillEvent.Publish(new SkillEventData(skill.skillData, hero.gameObject), gameObject);

        // Disable the button and show cooldown icon
        skillButton.interactable = false;
        coolDownIcon.gameObject.SetActive(true);

        // Start cooldown coroutine
        StartCoroutine(CoolDown(skill.skillData.coolDown));
    }

    /// <summary>
    /// Called when the player buys the skill.
    /// Deducts the cost, marks the skill as learned, and enables the button.
    /// </summary>
    public void BuySkill()
    {
        money.value -= skill.cost; // Deduct skill cost
        skill.learned = true; // Mark skill as purchased
        skillButton.interactable = true; // Enable button
        buyButton.gameObject.SetActive(false); // Hide buy button
    }

    /// <summary>
    /// Called when the hero levels up.
    /// If the level meets the skill's requirement, show the skill button.
    /// </summary>
    private void OnHeroLeveledUp(int level)
    {
        if (!skill.learned)
        {
            if (level >= skill.requiredLevel)
            {
                skillButton.gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Coroutine to handle skill cooldown visuals and re-enable the button.
    /// </summary>
    private IEnumerator CoolDown(float coolDownTime)
    {
        coolDownIcon.fillAmount = 0f;
        float timePassed = 0f;

        while (timePassed < coolDownTime)
        {
            timePassed += Time.deltaTime;
            coolDownIcon.fillAmount += Time.deltaTime / coolDownTime;
            yield return null;
        }

        // Reactivate the skill button and hide the cooldown icon
        skillButton.interactable = true;
        coolDownIcon.gameObject.SetActive(false);
    }

    /// <summary>
    /// Clean up event subscription when this object is destroyed.
    /// </summary>
    private void OnDestroy()
    {
        if (hero != null)
        {
            hero.onLevelUp -= OnHeroLeveledUp;
        }
    }
}