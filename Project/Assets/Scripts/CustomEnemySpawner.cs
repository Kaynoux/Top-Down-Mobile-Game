using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class CustomEnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Instantiate(enemyPrefab, UtilsClass.GetMouseWorldPosition(), Quaternion.identity);
        }

        
    }


}
