using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterEquipmentSlot : MonoBehaviour, IDropHandler
{
    public event EventHandler OnItemDropped;

    public class OnItemDroppedEventArgs : EventArgs
    {
        public ItemStats itemStats;
    }
    public void OnDrop(PointerEventData eventData)
    {
        ItemStats itemStats = eventData.pointerDrag.gameObject.GetComponent<ItemStats>();

    }
}
