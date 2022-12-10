using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BaseUpgrades : MonoBehaviour
{
    public bool strength;
    public bool health;

    public float gainPerLevel;
    public float basePrice;
    public float incrementValue;

    public float currentPrice;
    public int level;

    public ShowNumber currentPriceText;
    public ShowNumber currentLevelText;
    public SaveDataSO saveDataSO;


    //\[Price = BaseCost \times Multiplier ^{(\#\:Owned)} \]
    private void Start()
    {
        
        if (health)
        {
            saveDataSO.CurrentHealthLevel++;
            level = saveDataSO.CurrentHealthLevel;
        }
        if (strength)
        {
            saveDataSO.CurrentStrengthLevel ++;
            level = saveDataSO.CurrentStrengthLevel;

        }
        currentPrice = basePrice * Mathf.Pow(incrementValue, level);
        UpdateText();
    }
    public void TryBuy()
    {
        if (currentPrice <= saveDataSO.TotalCoins)
        {
            saveDataSO.TotalCoins -= currentPrice;

            currentPrice = basePrice * Mathf.Pow(incrementValue, level);
            
            if (health)
            {
                saveDataSO.CurrentHealthLevel++;
                level = saveDataSO.CurrentHealthLevel;
            }
            if (strength)
            {
                saveDataSO.CurrentStrengthLevel++;
                level = saveDataSO.CurrentStrengthLevel;
                
            }
            GlobalStats.instance.RecalulateStats();
            UpdateText();
        }


    }

    private void UpdateText()
    {
        currentPriceText.ScoreShow(currentPrice);
        currentLevelText.ScoreShow(level);
    }


}
