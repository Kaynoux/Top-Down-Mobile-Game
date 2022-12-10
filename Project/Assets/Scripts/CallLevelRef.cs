using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallLevelRef : MonoBehaviour
{
    public void ChangeSceneWithGlobalStats(string name)
    {
        GlobalStats.instance.LoadScene(name);
    }
}
