using UnityEngine;
using System.Collections;
using TMPro;

public class Fps : MonoBehaviour
{
    private float count;
    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();

    }


    private IEnumerator Start()
    {
        GUI.depth = 2;
        while (true)
        {
            count = 1f / Time.unscaledDeltaTime;
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void OnGUI()
    {
        textMeshPro.text = new string("FPS: " + Mathf.Round(count));
    }
}