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
    public string savePath;
    public ItemDatabaseSO itemDatabaseSO;
    public Inventory itemsContainer = new Inventory();
   

   
    public void AddItem(Item _item)
    {
        var slot = new InventorySlot(_item.id, _item, itemDatabaseSO);
        itemsContainer.invSlotList.Add(slot);
        slot.inventorySO = this;
    }

    public void RemoveItem(Item _item)
    {
        itemsContainer.invSlotList.RemoveAll(s => s.item == _item);
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
    [System.NonSerialized] public InventorySO inventorySO;
   
    
    public InventorySlot(int _id, Item _item, ItemDatabaseSO _itemDatabaseSO)
    {
        item = _item;   
    }

    public ItemSO GetItemObject()
    {
        return item.id >= 0 ? inventorySO.itemDatabaseSO.items[item.id] : null;
    }
}


