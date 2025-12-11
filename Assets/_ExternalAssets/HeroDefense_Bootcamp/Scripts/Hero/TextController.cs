using TMPro;
using UnityEngine;

public class TextController : HeroObserver
{
    public TextMeshProUGUI levelUI;
    private void Awake()
    {
        levelUI = GetComponent<TextMeshProUGUI>();
    }
    protected override void OnLevelUp(int currentLevel)
    {
        levelUI.text = currentLevel.ToString();
    }

    
}
