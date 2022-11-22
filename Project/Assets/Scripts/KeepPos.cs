using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPos : MonoBehaviour
{
    private Vector3 originalPos;
    private void Start()
    {
        originalPos = transform.position;
    }

    void Update()
    {
        if (transform.hasChanged)
        {
            transform.position = originalPos;
        }   
    }
}
