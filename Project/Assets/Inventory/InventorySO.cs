using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using JetBrains.Annotations;
using System.Runtime.Serialization;
using UnityEditor.Rendering;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Items/Inventory")]
public class InventorySO : ScriptableObject
{
    public int addItemWithId;
    public string savePath;
    public ItemDatabaseSO itemDatabaseSO;
    public Inventory itemsContainer = new Inventory();

    [ContextMenu("Add Item")]
    public void AddItemThroughEditor()
    {
        AddItem(itemDatabaseSO.GetItemWithId(addItemWithId));
    }
   
    public void AddItem(Item _item)
    {
        var slot = new InventorySlot(_item.id, _item);
        itemsContainer.invSlotList.Add(slot);
        Save();
    }

    public void RemoveItem(Item _item)
    {
        itemsContainer.invSlotList.RemoveAll(s => s.item == _item);
        Save();
    }

    

    [ContextMenu("Save")]
    public void Save()
    {
        //string saveData = JsonUtility.ToJson(this, true);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        //bf.Serialize(file, saveData);
        //file.Close();

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, itemsContainer);
        stream.Close();

    }
    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            //JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            //file.Close();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            itemsContainer = (Inventory)formatter.Deserialize(stream);
            stream.Close();
        }
    }
    [ContextMenu("Clear")]
    public void Clear()
    {
        itemsContainer = new Inventory();
    }
}

[System.Serializable]
public class Inventory
{
    public List<InventorySlot> invSlotList = new List<InventorySlot>();
}


[System.Serializable]
public class InventorySlot
{
    public Item item;
   
    
    public InventorySlot(int _id, Item _item)
    {
        item = _item;   
    }

    public ItemSO GetItemObject()
    {
        //Debug.Log(item.name);
        return item.id >= 0 ? StorageManager.instance.itemDatabaseSO.items[item.id] : null;
        
    }
}


