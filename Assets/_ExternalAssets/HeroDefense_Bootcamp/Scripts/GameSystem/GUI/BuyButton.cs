using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Controls whether a button can be clicked based on amount of money from
/// the money ScriptableObject, this is an observer of IntValue money, it only
/// call OnMoneyUpdate when the money value changes, instead of checking the value
/// in Update().
/// </summary>
[RequireComponent(typeof(Button))]
public class BuyButton : MonoBehaviour
{
    // Reference to the Button component
    [SerializeField]
    private Button buyButton;

    // The cost of the item associated with this button
    [SerializeField]
    private int cost;

    // A reference to the IntValue representing player's current money
    [SerializeField]
    private IntValue money;


    private void Start()
    {
        // Get the Button component on the same GameObject
        buyButton = GetComponent<Button>();

        // Initialize the button with the cost value
        Init(cost);
    }

    /// Initializes the button with a given cost.
    /// Updates the text on the button and sets its initial interactable state.
    public void Init(int pCost)
    {
        cost = pCost;

        // Find the TextMeshProUGUI component in child objects to show the cost
        TextMeshProUGUI moneyText = GetComponentInChildren<TextMeshProUGUI>();
        if (moneyText != null)
        {
            // Set the text to display the cost
            moneyText.text = "$ " + cost.ToString();
        }

        // Update button interactivity based on current money
        OnMoneyUpdate();
    }

    /// <summary>
    /// Updates the interactability of the buy button.
    /// Enables the button if the player has enough money, disables it otherwise.
    /// </summary>
    public void OnMoneyUpdate()
    {
        if (cost <= money.value)
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
        }
    }

    // Subscribe to the money value change event when this object is enabled
    private void OnEnable()
    {
        money.onValueChanged += OnMoneyUpdate;
    }

    // Unsubscribe from the money value change event when this object is disabled
    private void OnDisable()
    {
        money.onValueChanged -= OnMoneyUpdate;
    }
}
