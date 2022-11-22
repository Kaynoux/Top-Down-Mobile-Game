using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ItemSlot : MonoBehaviour, IDropHandler
{

    public ItemType itemType = ItemType.Helmet;
    public ItemHolder currentItem;
    public bool isStorage;
    public InventorySO currentItemsSO;
    

    



    

    private void Start()
    {
        if (currentItem != null && isStorage)
        {
            RecolorSlot();
        }
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        
        if (eventData.pointerDrag != null)
        {
     
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            
                        
        }
    }

  
    

    

    public void Equip(ItemHolder _itemHolder)
    {
        if (_itemHolder == currentItem)
        {
            currentItem.transform.SetParent(transform);
            currentItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            currentItem.itemSlot = this;
            return;
        }
        if (currentItem != null)
        {
            Debug.Log("Besetz");
            
            StorageManager.instance.Store(currentItem);
            
            currentItem = null;
            
            
        }

        currentItem = _itemHolder;


        //StorageManager.instance.Leave(currentItem);
        
        InventoryManager.instance.EquipItem(currentItem);

        currentItem.transform.SetParent(transform);
        currentItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        currentItem.itemSlot = this;
        currentItemsSO.AddItem(currentItem.item);




    }

    

    public bool CorrectSlot(ItemHolder _itemHolder)
    {
        if (_itemHolder.itemSO.itemType == itemType)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void RecolorSlot()
    {
        GetComponent<Image>().color = currentItem.itemSO.itemColor;
        
    }

    public void DefaultColor()
    {
        
        GetComponent<Image>().color = new Color32(205, 163, 123, 255);
        
    }
}


    


