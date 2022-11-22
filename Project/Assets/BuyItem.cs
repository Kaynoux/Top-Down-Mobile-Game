using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public bool isCoinPrice;
    public float price;
    public ItemHolder itemHolder;
    public void TryBuy()
    {
        if (isCoinPrice && price < GlobalStats.instance.totalCoins)
        {
            Debug.Log("Bought" + gameObject.name);
            itemHolder.Add();
        }
    }
}
    
