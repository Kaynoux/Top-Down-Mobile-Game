using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LiveNumber : MonoBehaviour
{
    public bool coin;
    public bool gem;
    private ShowNumber showNumber;
    public SaveDataSO saveDataSO;

    private void Start()
    {
        showNumber = GetComponent<ShowNumber>();
        if (coin)
        {
            ValueChangeCoin(null, null);
            SaveDataSO.OnCoinChange += ValueChangeCoin;
        }
        if (gem)
        {
            ValueChangeGem(null, null);
            SaveDataSO.OnGemChange += ValueChangeGem;
        }
    }

    private void ValueChangeCoin(object sender, EventArgs e)
    {
        showNumber.ScoreShow(saveDataSO.TotalCoins);
    }

    private void ValueChangeGem(object sender, EventArgs e)
    {
        showNumber.ScoreShow(saveDataSO.TotalGems);
    }

}
