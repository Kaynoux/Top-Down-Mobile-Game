using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database", menuName = "Items/Database")]
public class ItemDatabaseSO : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemSO[] items;
    
    public Dictionary<int, ItemSO> GetItem = new Dictionary<int, ItemSO>();

    public void OnAfterDeserialize()
    {
       
       

        for (int i = 0; i < items.Length; i++)
        {
            items[i].id = i;
            GetItem.Add(i, items[i]);
        }
    }
    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, ItemSO>();
    }
}
