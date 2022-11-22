using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.GraphicsBuffer;

public enum ItemRarity { Common, Uncommon, Rare, Epic, Legendary }
public enum ItemType { Helmet, Chestplate, Leggins, Boots, Ring, Pet, Empty }

public enum ItemAttributes { Health, Regen, Defense, Dodge, Strength, Attack, Skill, Critical, Speed, Luck }



public class ItemSO : ScriptableObject
{
    
    
    public ItemRarity itemRarity;
    public int id;
    



    public ItemType itemType;
    public Sprite itemImage;
    public Color itemColor;

    

    public Item data = new Item();

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
    
   
    
    
    





}

[System.Serializable]
public class Item
{
    public string name;
    public int id = 0;
    public ItemBuff[] buffs;

    
   
    public Item()
    {
        id = 0;
    }
    public Item(ItemSO _itemSO)
    {

        id = _itemSO.data.id;
        buffs = new ItemBuff[_itemSO.data.buffs.Length];

        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(_itemSO.data.buffs[i].value);
        }

    }


}

[System.Serializable]
public class ItemBuff
{
    public ItemAttributes attribute;
    public float value;

    public ItemBuff(float _value)
    {
        value = _value;
    }



}










