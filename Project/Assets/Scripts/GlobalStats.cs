using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStats : MonoBehaviour
{
    public static GlobalStats instance;

    public float totalHealth;
    public float totalRegen;
    public float totalDefense;
    public float totalDodge;
    public float totalStrength;
    public float totalAttack;
    public float totalSkill;
    public float totalCritical;
    public float totalSpeed;
    public float totalLuck;

    public float totalCoins;
    public float totalGems;
    
    

    

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

        DontDestroyOnLoad(this.gameObject);


    }

    private void Update()
    {
         
    }
    public void RecalulateStats()
    {
        totalHealth = 100;
        totalRegen = 0;
        totalDefense = 0;
        totalDodge = 0;
        totalStrength = 10;
        totalAttack = 10;
        totalSkill = 100;
        totalCritical = 0;
        totalSpeed = 100;
        totalLuck = 100;

        var inv = InventoryManager.instance;
        List<ItemHolder> equipped = new List<ItemHolder>() { inv.currentHelmet, inv.currentChestplate, inv.currentLeggins, inv.currentBoots, inv.currentRing, inv.currentPet };

        for (int i = 0; i < equipped.Count; i++)
        {
            /*totalHealth += equipped[i].item.itemHealth;
            totalRegen += equipped[i].item.itemRegen;
            totalDefense += equipped[i].item.itemDefense;
            totalDodge += equipped[i].item.itemDodge;
            totalStrength += equipped[i].item.itemStrength;
            totalAttack += equipped[i].item.itemAttack;
            totalSkill += equipped[i].item.itemSkill;
            totalCritical += equipped[i].item.itemCritical;
            totalSpeed += equipped[i].item.itemSpeed;
            totalLuck += equipped[i].item.itemLuck;*/
        }
    }

    
}
