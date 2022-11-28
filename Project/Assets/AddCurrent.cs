using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AddCurrent : MonoBehaviour
{
    public bool gemPrice;
    public bool realLifePrice;
    public float payAmount;
    public float addAmount;
    

    public void TryBuy()
    {
        if (gemPrice && payAmount <= GlobalStats.instance.totalGems)
        {
            Debug.Log("Bought" + gameObject.name);
            GlobalStats.instance.totalGems-= payAmount;
            GlobalStats.instance.GemsChanged();
            GlobalStats.instance.totalCoins += addAmount;
            GlobalStats.instance.CoinsChanged();
        }
        else if (realLifePrice)
        {
            GlobalStats.instance.totalGems += addAmount;
            GlobalStats.instance.GemsChanged();
        }

        
    }

   

}

