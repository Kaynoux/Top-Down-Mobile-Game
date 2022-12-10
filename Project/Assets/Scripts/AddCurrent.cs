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
    public SaveDataSO saveDataSO;
    

    public void TryBuy()
    {
        if (gemPrice && payAmount <= saveDataSO.TotalGems)
        {
            //Debug.Log("Bought" + gameObject.name);
            saveDataSO.TotalGems -= payAmount;
            
            saveDataSO.TotalCoins += addAmount;
        }
        else if (realLifePrice)
        {
            saveDataSO.TotalGems += addAmount;
        }

        
    }

   

}

