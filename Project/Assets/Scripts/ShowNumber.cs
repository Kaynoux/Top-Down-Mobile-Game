using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowNumber : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    public bool isPercent;
    public bool isCapAt100Percent;
    

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
            
    }
    public void ScoreShow(float score)
    {
        string result;
        string[] ScoreNames = new string[] { "", "k", "M", "B", "T", "aa", "ab", "ac", "ad", "ae", "af", "ag", "ah", "ai", "aj", "ak", "al", "am", "an", "ao", "ap", "aq", "ar", "as", "at", "au", "av", "aw", "ax", "ay", "az", "ba", "bb", "bc", "bd", "be", "bf", "bg", "bh", "bi", "bj", "bk", "bl", "bm", "bn", "bo", "bp", "bq", "br", "bs", "bt", "bu", "bv", "bw", "bx", "by", "bz", };
        int i;

        for (i = 0; i < ScoreNames.Length; i++)
        {
            if (score < 1000) break;
            else score /= 1000;
        }

        if (isCapAt100Percent && score >= 100)
        {
            score = 100;
        }
            

        if (score == System.MathF.Floor(score))
        {
            result = score.ToString("F2") + ScoreNames[i];
        }
        else result = score.ToString("F2") + ScoreNames[i];

        if (isPercent)
        {
            result = result + "%";
        }

        if (textMeshPro != null)
        {
            textMeshPro.text = result;
        }
        
    }
}
