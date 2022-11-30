using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class StorageManager : MonoBehaviour
{
    public static StorageManager instance;

    
    public Transform content;
    public Transform itemSlots;
    public Transform itemSlotPrefab;
    public Transform itemLoadPrefab;
  
    public InventorySO storageSO;
    public InventorySO currentItemsSO;
    public ItemDatabaseSO itemDatabaseSO;
    private List<Transform> listOfChildren = new List<Transform>();
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
        _itemHolder.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
        _itemHolder.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        _itemHolder.itemSlot = itemBackground.GetComponent<ItemSlot>();
        itemBackground.GetComponent<ItemSlot>().currentItem = _itemHolder;
        itemBackground.GetComponent<ItemSlot>().itemType = _itemHolder.itemSO.itemType;
        storageSO.AddItem(_itemHolder.item);
        GlobalStats.instance.RecalulateStats();
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
            var newItem = Instantiate(itemLoadPrefab);
            
            ItemHolder itemHolder = newItem.GetComponent<ItemHolder>();

            
            itemHolder.itemSO = list[0].GetItemObject();
            itemHolder.image.sprite = itemHolder.itemSO.itemImage;
            itemHolder.item = list[0].item;
            list.RemoveAt(0);
            Store(itemHolder, true);
            
            
        }

        currentItemsSO.Load();
        var currentList = currentItemsSO.itemsContainer.invSlotList;
        var typeList = new List<ItemType> { ItemType.Helmet, ItemType.Chestplate, ItemType.Leggins, ItemType.Boots, ItemType.Ring, ItemType.Pet };
        GetChildRecursive(itemSlots);
        
        

        for (int i = 0; i < currentList.Count; i++)
        {
            for (int ii = 0; ii < typeList.Count; ii++)
            {
                if (itemDatabaseSO.GetItem[currentList[i].item.id].itemType == typeList[ii] )
                {
                    foreach (Transform child in listOfChildren[ii])
                    {
                        GameObject.Destroy(child.gameObject);

                    }
                    var newItem = Instantiate(itemLoadPrefab, listOfChildren[ii]);
                    ItemHolder itemHolder = newItem.GetComponent<ItemHolder>();
                    itemHolder.itemSO = currentList[i].GetItemObject();
                    itemHolder.image.sprite = itemHolder.itemSO.itemImage;
                    itemHolder.item = currentList[i].item;
                    itemHolder.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                    itemHolder.itemSlot = listOfChildren[ii].GetComponent<ItemSlot>();
                }
            }
            
        }
        










    }

    private void GetChildRecursive(Transform obj)
    {
        if (listOfChildren.Count != 0)
        {
            listOfChildren.Clear();
        }
        
        if (null == obj)
            return;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
                continue;
            //child.gameobject contains the current child you can do whatever you want like add it to an array
            listOfChildren.Add(child);
            //GetChildRecursive(child);
        }
    }


}
