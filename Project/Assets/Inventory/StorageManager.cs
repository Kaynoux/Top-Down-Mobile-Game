using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class StorageManager : MonoBehaviour
{
    public static StorageManager instance;

    
    public Transform content;
    public Transform itemSlotPrefab;
    public Transform itemLoadPrefab;
  
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

    public void Store(ItemHolder _itemHolder, bool isNew = false)
    {
        //if (_itemHolder.itemSlot.isStorage)
        //{
        //    Leave(_itemHolder);
        //}
        

        if(!isNew && !_itemHolder.itemSlot.isStorage)
        {
            
            _itemHolder.itemSlot.currentItem = null;
            currentItemsSO.RemoveItem(_itemHolder.item);
            
        }
        
        Debug.Log("Storage: Store " + _itemHolder.gameObject.name);
        var itemBackground = Instantiate(itemSlotPrefab, content);
        _itemHolder.transform.SetParent(itemBackground);
        _itemHolder.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        _itemHolder.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        _itemHolder.itemSlot = itemBackground.GetComponent<ItemSlot>();
        itemBackground.GetComponent<ItemSlot>().currentItem = _itemHolder;
        itemBackground.GetComponent<ItemSlot>().itemType = _itemHolder.itemSO.itemType;
        storageSO.AddItem(_itemHolder.item);
        storageSO.Save();
    }

    public void Leave(ItemHolder _itemHolder)
    {
        
        var parent = _itemHolder.itemSlot.gameObject;
        _itemHolder.transform.SetParent(GameObject.FindGameObjectWithTag("Equipment").transform);
        Destroy(parent.gameObject);
        Debug.Log("StorageManager: Leave " + _itemHolder.gameObject.name);
        storageSO.RemoveItem(_itemHolder.item);
        storageSO.Save();
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
        int count = list.Count;

        for (int i = 0; i < list.Count; i++)
        {
            var newItem = Instantiate(itemLoadPrefab);
            
            ItemHolder itemHolder = newItem.GetComponent<ItemHolder>();

            list[0].inventorySO = storageSO;
            itemHolder.itemSO = list[0].GetItemObject();
            itemHolder.image.sprite = itemHolder.itemSO.itemImage;
            itemHolder.item = list[0].item;
            list.RemoveAt(0);
            Store(itemHolder, true);
            
            
        }
        /*foreach (InventorySlot i in list.Reverse<InventorySlot>())
        {
            var newItem = Instantiate(itemLoadPrefab);

            ItemHolder itemHolder = newItem.GetComponent<ItemHolder>();

            i.inventorySO = storageSO;
            itemHolder.itemSO = i.GetItemObject();
            itemHolder.image.sprite = itemHolder.itemSO.itemImage;
            itemHolder.item = i.item;
            list.Remove(i);
            Store(itemHolder, true);
        }*/




       
    }


}
