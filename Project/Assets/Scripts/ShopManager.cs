using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public InventorySO shopSO;
    public Transform shopPrefab;

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
        foreach (Transform child in MainMenu.instance.content)
        {
            GameObject.Destroy(child.gameObject);
        }

        shopSO.Load();
        var list = shopSO.itemsContainer.invSlotList;
        int count = list.Count;

        for (int i = 0; i < list.Count; i++)
        {
            var newItem = Instantiate(shopPrefab, MainMenu.instance.content);

            ItemHolder itemHolder = newItem.GetComponent<ItemHolder>();
            itemHolder.itemSO = list[0].GetItemObject();
            itemHolder.image.sprite = itemHolder.itemSO.itemImage;
            itemHolder.item = list[0].item;
            list.RemoveAt(0);
            
            
            
            
            itemHolder.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            itemHolder.gameObject.GetComponent<BuyItem>().UpdateText(itemHolder.itemSO.name, itemHolder.itemSO.itemPrice, itemHolder.itemSO.itemColor);
            shopSO.AddItem(itemHolder.item);
            shopSO.Save();
            


        }


    }
}
