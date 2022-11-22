using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour
{
    public ItemSO itemSO;
    public InventorySO storageSO;
    public ItemSlot itemSlot;
    public Item item;
    public Image image;


    private void Awake()
    {
        item = new Item(itemSO);
    }
    public void Add()
    {
        storageSO.AddItem(item);
    }
}
