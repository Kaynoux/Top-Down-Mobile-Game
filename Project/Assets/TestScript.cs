using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public InventorySO inventorySO;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            inventorySO.Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            inventorySO.Load();
        }

    }
}
