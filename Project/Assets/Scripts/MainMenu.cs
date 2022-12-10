using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Transform[] menus;
    public Transform worldButtons;
    public CharacterController2d characterController2d;
    /*public Transform mainMenu;
    public Transform settingsMenu;
    public Transform shopMenu;
    public Transform leaderboardMenu;
    public Transform armorMenu;
    public Transform skillsMenu;*/

    public int oldMenuIndex;
    public int currentMenuIndex;
   
    public Transform storage;
    public InventorySO storageSO;
    public Transform content;

    public static MainMenu instance;

    [Header("Equipment")]
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

    [Header("Gym")]
    public ShowNumber totalHealthText1;
    public ShowNumber totalRegenText1;
    public ShowNumber totalDefenseText1;
    public ShowNumber totalDodgeText1;
    public ShowNumber totalStrengthText1;
    public ShowNumber totalAttackText1;
    public ShowNumber totalSkillText1;
    public ShowNumber totalCriticalText1;
    public ShowNumber totalSpeedText1;
    public ShowNumber totalLuckText1;

    public ShowNumber coinsText;
    public ShowNumber gemsText;
    public Transform itemSlots;

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
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].gameObject.SetActive(false);
        }

        ChangeMenu(0);
        GlobalStats.OnStatsChange += RedrawStats;
    }

    

   

    

    public void ChangeMenu(int index)
    {
        oldMenuIndex = currentMenuIndex;
        currentMenuIndex = index;
        /*
         * 0 Main
         * 1 Leaderboard
         * 2 Gym
         * 3 Shop
         * 4 Equip
         * 5 Settings
         */
        if (oldMenuIndex == currentMenuIndex)
        {
            return;
        }

        menus[currentMenuIndex].gameObject.SetActive(true);
        menus[oldMenuIndex].gameObject.SetActive(false);
       

        if (currentMenuIndex != 0)
        {
            worldButtons.gameObject.SetActive(false);
            characterController2d.enabled = false;
            
        }
        else
        {
            
            worldButtons.gameObject.SetActive(true);
            characterController2d.enabled = true;
        }

        if (currentMenuIndex == 2 )
        {
            RedrawStats(null, null);
        }

        else if (currentMenuIndex == 3)
        {
            ShopManager.instance.Load();
            
            
        }

        else if (currentMenuIndex == 4)
        {
            StorageManager.instance.Load();
            RedrawStats(null, null);
        }

       

        



    }

    private void RedrawStats(object sender, EventArgs e)
    {
        if (currentMenuIndex == 4)
        {
            totalHealthText.ScoreShow(GlobalStats.instance.attributes[0].totalValue);
            totalRegenText.ScoreShow(GlobalStats.instance.attributes[1].totalValue);
            totalDefenseText.ScoreShow(GlobalStats.instance.attributes[2].totalValue);
            totalDodgeText.ScoreShow(GlobalStats.instance.attributes[3].totalValue);
            totalStrengthText.ScoreShow(GlobalStats.instance.attributes[4].totalValue);
            totalAttackText.ScoreShow(GlobalStats.instance.attributes[5].totalValue);
            totalSkillText.ScoreShow(GlobalStats.instance.attributes[6].totalValue);
            totalCriticalText.ScoreShow(GlobalStats.instance.attributes[7].totalValue);
            totalSpeedText.ScoreShow(GlobalStats.instance.attributes[8].totalValue);
            totalLuckText.ScoreShow(GlobalStats.instance.attributes[9].totalValue);
        }
        else if (currentMenuIndex == 2)
        {
            totalHealthText1.ScoreShow(GlobalStats.instance.attributes[0].totalValue);
            totalRegenText1.ScoreShow(GlobalStats.instance.attributes[1].totalValue);
            totalDefenseText1.ScoreShow(GlobalStats.instance.attributes[2].totalValue);
            totalDodgeText1.ScoreShow(GlobalStats.instance.attributes[3].totalValue);
            totalStrengthText1.ScoreShow(GlobalStats.instance.attributes[4].totalValue);
            totalAttackText1.ScoreShow(GlobalStats.instance.attributes[5].totalValue);
            totalSkillText1.ScoreShow(GlobalStats.instance.attributes[6].totalValue);
            totalCriticalText1.ScoreShow(GlobalStats.instance.attributes[7].totalValue);
            totalSpeedText1.ScoreShow(GlobalStats.instance.attributes[8].totalValue);
            totalLuckText1.ScoreShow(GlobalStats.instance.attributes[9].totalValue);
        }

        

    }


}
