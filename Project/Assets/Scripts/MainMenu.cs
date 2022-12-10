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
            totalHealthText.ScoreShow(GlobalStats.instance.Health);
            totalRegenText.ScoreShow(GlobalStats.instance.Regen);
            totalDefenseText.ScoreShow(GlobalStats.instance.Defense);
            totalDodgeText.ScoreShow(GlobalStats.instance.Dogde);
            totalStrengthText.ScoreShow(GlobalStats.instance.Strength);
            totalAttackText.ScoreShow(GlobalStats.instance.Attack);
            totalSkillText.ScoreShow(GlobalStats.instance.Skill);
            totalCriticalText.ScoreShow(GlobalStats.instance.Critical);
            totalSpeedText.ScoreShow(GlobalStats.instance.Speed);
            totalLuckText.ScoreShow(GlobalStats.instance.Luck);
        }
        else if (currentMenuIndex == 2)
        {
            totalHealthText1.ScoreShow(GlobalStats.instance.Health);
            totalRegenText1.ScoreShow(GlobalStats.instance.Regen);
            totalDefenseText1.ScoreShow(GlobalStats.instance.Defense);
            totalDodgeText1.ScoreShow(GlobalStats.instance.Dogde);
            totalStrengthText1.ScoreShow(GlobalStats.instance.Strength);
            totalAttackText1.ScoreShow(GlobalStats.instance.Attack);
            totalSkillText1.ScoreShow(GlobalStats.instance.Skill);
            totalCriticalText1.ScoreShow(GlobalStats.instance.Critical);
            totalSpeedText1.ScoreShow(GlobalStats.instance.Speed);
            totalLuckText1.ScoreShow(GlobalStats.instance.Luck);
        }

        

    }


}
