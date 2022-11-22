using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StorageManager : MonoBehaviour
{
    public static StorageManager instance;

    
    public Transform content;
    public Transform itemSlotPrefab;
    public Transform itemSlotWithItemPrefab;
  
    public InventorySO storageSO;
    public InventorySO currentItemsSO;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    public void Store(ItemHolder _itemHolder)
    {
        //if (_itemHolder.itemSlot.isStorage)
        //{
        //    Leave(_itemHolder);
        //}
        if (!_itemHolder.itemSlot.isStorage)
        {
            
            _itemHolder.itemSlot.currentItem = null;
            currentItemsSO.RemoveItem(_itemHolder.item);
            
        }
        
        Debug.Log("Storage: Store " + _itemHolder.gameObject.name);
        var itemBackground = Instantiate(itemSlotPrefab, content);
        _itemHolder.transform.SetParent(itemBackground);
        _itemHolder.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        _itemHolder.itemSlot = itemBackground.GetComponent<ItemSlot>();
        itemBackground.GetComponent<ItemSlot>().currentItem = _itemHolder;
        itemBackground.GetComponent<ItemSlot>().itemType = _itemHolder.itemSO.itemType;
        storageSO.AddItem(_itemHolder.item);
    }

    public void Leave(ItemHolder _itemHolder)
    {
        
        var parent = _itemHolder.itemSlot.gameObject;
        _itemHolder.transform.SetParent(GameObject.FindGameObjectWithTag("Equipment").transform);
        Destroy(parent.gameObject);
        Debug.Log("StorageManager: Leave " + _itemHolder.gameObject.name);
        storageSO.RemoveItem(_itemHolder.item);
        //Er removed die ersten items nicht
    }

    [ContextMenu("Load")]
    public void Load()
    {
        foreach (Transform child in content)
        {
            GameObject.Destroy(child.gameObject);
        }

        storageSO.Load();
        var list = storageSO.itemsContainer.invSlotList;
        for (int i = 0; i < list.Count; i++)
        {
            var slot = Instantiate(itemSlotWithItemPrefab, content);

            ItemSlot itemSlot = slot.GetComponent<ItemSlot>();
            ItemHolder itemHolder = slot.GetComponentInChildren<ItemHolder>();

            list[i].inventorySO = storageSO;
            itemHolder.itemSO = list[i].GetItemObject();

            itemSlot.itemType = itemHolder.itemSO.itemType;
            itemSlot.currentItem = itemHolder;
            itemHolder.image.sprite = itemHolder.itemSO.itemImage;
            itemHolder.item = list[i].item;
            Leave(itemHolder);
            Store(itemHolder);
            
        }
    }


}
