using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStats : MonoBehaviour
{
    public static GlobalStats instance;

    /*public float baseTotalHealth = 100;
    public float baseTotalRegen = 0;
    public float baseTotalDefense = 0;
    public float baseTotalDodge = 0;
    public float baseTotalStrength = 10;
    public float baseTotalAttack = 10;
    public float baseTotalSkill = 100;
    public float baseTotalCritical = 0;
    public float baseTotalSpeed = 100;
    public float baseTotalLuck = 100;
    public float totalHealth;
    public float totalRegen;
    public float totalDefense;
    public float totalDodge;
    public float totalStrength;
    public float totalAttack;
    public float totalSkill;
    public float totalCritical;
    public float totalSpeed;
    public float totalLuck;*/

    public Attribute[] attributes;
    public float totalCoins;
    public float totalGems;

    public InventorySO currentItems;

    public ShowNumber totalHealthText;
    public ShowNumber totalRegenText;
    public ShowNumber totalDefenseText;
    public ShowNumber totalDodgeText;
    public ShowNumber totalStrengthText;
    public ShowNumber totalAttackText;
    public ShowNumber totalSkillText;
    public ShowNumber totalCriticalText;
    public ShowNumber totalSpeedText;
    public ShowNumber totalLuckText;

    public ShowNumber coinsText;
    public ShowNumber gemsText;




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

    
    public void RecalulateStats()
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].totalValue = attributes[i].baseValue;
        }

        var slotList = currentItems.itemsContainer.invSlotList;
        for (int i = 0; i < slotList.Count; i++)
        {
            for (int ii = 0; ii < slotList[i].item.buffs.Length; ii++)
            {
                ReturnAttribute(slotList[i].item.buffs[ii].itemAttribute).totalValue += slotList[i].item.buffs[ii].value;
            }
        }

        Debug.Log("Global Stats: Recalulate Stats");
    }

    public void RedrawStats()
    {

        totalHealthText.ScoreShow(attributes[0].totalValue);
        totalRegenText.ScoreShow(attributes[1].totalValue);
        totalDefenseText.ScoreShow(attributes[2].totalValue);
        totalDodgeText.ScoreShow(attributes[3].totalValue);
        totalStrengthText.ScoreShow(attributes[4].totalValue);
        totalAttackText.ScoreShow(attributes[5].totalValue);
        totalSkillText.ScoreShow(attributes[6].totalValue);
        totalCriticalText.ScoreShow(attributes[7].totalValue);
        totalSpeedText.ScoreShow(attributes[8].totalValue);
        totalLuckText.ScoreShow(attributes[9].totalValue);

    }

    public void CoinsChanged()
    {
        coinsText.ScoreShow(totalCoins);
    }

    public void GemsChanged()
    {
        gemsText.ScoreShow(totalGems);
    }

    public Attribute ReturnAttribute(ItemAttributes _itemAttribute)
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            if (attributes[i].itemAttribute == _itemAttribute)
            {
                return attributes[i];
                
            }
            
        }
        return null;
    }


}

[System.Serializable]
public class Attribute
{
    
    public ItemAttributes itemAttribute;
    public float baseValue;
    public float totalValue;

    
    /*public Attribute(string _name, float _baseValue)
    {
        atrributeName = _name;
        baseValue = _baseValue;
    }*/

}
