using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DisplayTime : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();

    }

    private void Update()
    {
        var time = MainSpawner.instance.time;
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        textMeshPro.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
