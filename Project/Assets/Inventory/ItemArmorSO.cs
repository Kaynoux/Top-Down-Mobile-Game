using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "Items/Armor")]
public class ItemArmorSO : ItemSO
{
    
    private void Awake()
    {
        itemType = ItemType.Chestplate;
    }
}
