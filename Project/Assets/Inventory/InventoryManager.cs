using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{/*
    public static InventoryManager instance;

    // fill in inspector
    /*public static List<Transform> allItems = new List<Transform>();
    public List<Transform> ownedItems = new List<Transform>();
    public List<Transform> equippedItems = new List<Transform>();

    
    public ItemHolder emptyStats;

    public ItemHolder currentHelmet;
    public ItemHolder currentChestplate;
    public ItemHolder currentLeggins;
    public ItemHolder currentBoots;
    public ItemHolder currentRing;
    public ItemHolder currentPet;

    
    




    // Setup this very simple singleton
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

    private void Start()
    {
        GlobalStats.instance.RecalulateStats();
    }

    /*private void Update()
    {
        Debug.Log("1" + currentHelmet.itemHealth);
        Debug.Log("2" + currentChestplate.itemHealth);
    }



    public void PickUp()
    {

    }

    

    

    
    public void UnequipItem(ItemHolder _ItemHolder)
    {
        if (_ItemHolder == null)
        {
            Debug.Log("Not set");
            return;
        }
        if (_ItemHolder.itemSO.itemType == ItemType.Helmet)
        {
            currentHelmet = emptyStats;

        }
        else if (_ItemHolder.itemSO.itemType == ItemType.Chestplate)
        {
            currentChestplate = emptyStats;
        }
        else if (_ItemHolder.itemSO.itemType == ItemType.Leggins)
        {
            currentLeggins = emptyStats;
        }
        else if (_ItemHolder.itemSO.itemType == ItemType.Boots)
        {
            currentBoots = emptyStats;
        }
        else if (_ItemHolder.itemSO.itemType == ItemType.Ring)
        {
            currentRing = emptyStats;
        }
        else if (_ItemHolder.itemSO.itemType == ItemType.Pet)
        {
            currentPet = emptyStats;
        }

        GlobalStats.instance.RecalulateStats();

    }

    

    public void EquipItem(ItemHolder _ItemHolder)
    {
        /*totalHealth += _ItemHolder.itemHealth;
        totalRegen += _ItemHolder.itemRegen;
        totalDefense += _ItemHolder.itemDefense;
        totalDodge += _ItemHolder.itemDodge;
        totalStrength += _ItemHolder.itemStrength;
        totalAttack += _ItemHolder.itemAttack;
        totalSkill += _ItemHolder.itemSkill;
        totalCritical += _ItemHolder.itemCritical;
        totalSpeed += _ItemHolder.itemSpeed;
        totalLuck += _ItemHolder.itemLuck;

       
        if (_ItemHolder.itemSO.itemType == ItemType.Helmet)
        {
            currentHelmet = _ItemHolder;
            
        }
        else if (_ItemHolder.itemSO.itemType == ItemType.Chestplate)
        {
            currentChestplate = _ItemHolder;
            
        }
        else if (_ItemHolder.itemSO.itemType == ItemType.Leggins)
        {
            currentLeggins = _ItemHolder;
        }
        else if (_ItemHolder.itemSO.itemType == ItemType.Boots)
        {
            currentBoots = _ItemHolder;
        }
        else if (_ItemHolder.itemSO.itemType == ItemType.Ring)
        {
            currentRing = _ItemHolder;
        }
        else if (_ItemHolder.itemSO.itemType == ItemType.Pet)
        {
            currentPet = _ItemHolder;
        }
        else
        {
            Debug.Log("Equip Error");
        }

        GlobalStats.instance.RecalulateStats();

    }

    public ItemHolder GetCurrentItemWithType(ItemType itemType)
    {
        
        if (itemType == ItemType.Empty)
        {
            return emptyStats;
        }
        if (itemType == ItemType.Helmet)
        {
            return (currentHelmet);
        }
        else if (itemType == ItemType.Chestplate)
        {
            return (currentChestplate);
        }
        else if (itemType == ItemType.Leggins)
        {
            return (currentLeggins);
        }
        else if (itemType == ItemType.Boots)
        {
            return (currentBoots);
        }
        else if (itemType == ItemType.Ring)
        {
            return (currentRing);
        }
        else if (itemType == ItemType.Pet)
        {
            return (currentPet);
        }
        else
        {
            Debug.Log("Error Type GetCurrent");
            return emptyStats;
            
        }
    }

    

    public void UnequipAll()
    {
        currentHelmet = emptyStats;
        currentChestplate = emptyStats;
        currentLeggins = emptyStats;
        currentBoots = emptyStats;
        currentRing = emptyStats;
        currentPet = emptyStats;
        GlobalStats.instance.RecalulateStats();

    }

 */  
}
