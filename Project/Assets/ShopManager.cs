using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public InventorySO shopSO;
    public Transform content;
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

    [ContextMenu("Load")]
    public void Load()
    {
        foreach (Transform child in content)
        {
            GameObject.Destroy(child.gameObject);
        }

        shopSO.Load();
        var list = shopSO.itemsContainer.invSlotList;
        for (int i = 0; i < list.Count; i++)
        {
            

        }
    }
}
