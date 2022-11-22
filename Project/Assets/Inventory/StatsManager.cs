using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
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

    

    private void OnEnable()
    {
        RedrawStats();
    }

    private void Start()
    {
        RedrawStats();
    }


    public void RedrawStats()
    {

        totalHealthText.ScoreShow(GlobalStats.instance.totalHealth);
        totalRegenText.ScoreShow(GlobalStats.instance.totalRegen);
        totalDefenseText.ScoreShow(GlobalStats.instance.totalDefense);
        totalDodgeText.ScoreShow(GlobalStats.instance.totalDodge);
        totalStrengthText.ScoreShow(GlobalStats.instance.totalStrength);
        totalAttackText.ScoreShow(GlobalStats.instance.totalAttack);
        totalSkillText.ScoreShow(GlobalStats.instance.totalSkill);
        totalCriticalText.ScoreShow(GlobalStats.instance.totalCritical);
        totalSpeedText.ScoreShow(GlobalStats.instance.totalSpeed);
        totalLuckText.ScoreShow(GlobalStats.instance.totalLuck);

    }
}
