using UnityEngine;
using TMPro;

/// <summary>
/// Presents a number in GUI whenevner the value is changed, this is an
/// observer of IntValue intValue, it only update the text when intValue
/// notifies its value has changed, instead of keep setting the text in
/// Update().
/// </summary>
public class NumberPresenter : MonoBehaviour
{
    [SerializeField]
    private IntValue intValue;
    [SerializeField]
    private TextMeshProUGUI numberText;

    private void UpdateNumberText()
    {
        numberText.text = "$ " + intValue.value.ToString();
    }

    private void Start()
    {
        UpdateNumberText();
    }

    private void OnEnable()
    {
        intValue.onValueChanged += UpdateNumberText;
    }

    private void OnDisable()
    {
        intValue.onValueChanged -= UpdateNumberText;
    }
}
