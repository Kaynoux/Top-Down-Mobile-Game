using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    public bool isCoinPrice;
    public float price;
    public ItemHolder itemHolder;
    public TMP_Text nameText;
    public ShowNumber showNumber;
    public Image itemSlotImage;
    public Image itemBoarderImage;
    public Image itemPriceBoarderImage;
    
    public void TryBuy()
    {
        if (isCoinPrice && price <= GlobalStats.instance.totalCoins)
        {
            Debug.Log("Bought" + gameObject.name);
            itemHolder.Add();
            GlobalStats.instance.totalCoins -= price;
            GlobalStats.instance.CoinsChanged();
        }

        
    }

    
    

    public void UpdateText(string _name, float _price, Color _color)
    {
        price = _price;
        nameText.text = _name;
        showNumber.ScoreShow(_price);
        itemSlotImage.color = _color;
        itemBoarderImage.color = _color;
        itemPriceBoarderImage.color = _color;
    }
    
}
    
