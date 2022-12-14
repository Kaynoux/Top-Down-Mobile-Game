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
    public SaveDataSO saveDataSO;
    public void TryBuy()
    {
        if (isCoinPrice && price <= saveDataSO.TotalCoins)
        {
            Debug.Log("Bought" + gameObject.name);
            itemHolder.Add();
            GlobalStats.instance.saveDataSO.TotalCoins -= price;
            
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
    
