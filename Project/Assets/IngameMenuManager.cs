using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenuManager : MonoBehaviour
{
    public Transform pauseMenu;

    private void Start()
    {
        ClosePauseMenu();
    }

    public void OpenPauseMenu()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void ClosePauseMenu()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void NormalTime()
    {
        Time.timeScale = 1;
    }


}
