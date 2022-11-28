using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool keepShop;
    public bool keepStorage;
    public Transform[] menus;
    public Transform worldButtons;
    public CharacterController2d characterController2d;
    /*public Transform mainMenu;
    public Transform settingsMenu;
    public Transform shopMenu;
    public Transform leaderboardMenu;
    public Transform armorMenu;
    public Transform skillsMenu;*/

    public int currentMenuIndex;
   
    public Transform stats;
    public Transform storage;
    public InventorySO storageSO;
    

    private void Start()
    {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].gameObject.SetActive(false);
        }

        ChangeMenu(0);
        ToggleStats();
        GlobalStats.instance.CoinsChanged();
        GlobalStats.instance.GemsChanged();
    }

    

   

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadYourAsyncScene(sceneName));

    }

    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void ChangeMenu(int index)
    {
        if (currentMenuIndex == index)
        {
            return;
        }

        menus[index].gameObject.SetActive(true);
        menus[currentMenuIndex].gameObject.SetActive(false);

        if (index != 0)
        {
            worldButtons.gameObject.SetActive(false);
            characterController2d.enabled = false;
            
        }
        else
        {
            
            worldButtons.gameObject.SetActive(true);
            characterController2d.enabled = true;
        }

        if(index == 3 && keepShop == false)
        {
            ShopManager.instance.Load();
        }

        if (index == 4 && keepStorage == false)
        {
            StorageManager.instance.Load();
        }

        if (currentMenuIndex == 4)
        {
            storageSO.Save();
        }

        currentMenuIndex = index;
        
    }

    public void ToggleStats()
    {
        stats.gameObject.SetActive(true);
        storage.gameObject.SetActive(false);
    }

    public void ToggleStorage()
    {
        stats.gameObject.SetActive(false);
        storage.gameObject.SetActive(true);
    }
}
