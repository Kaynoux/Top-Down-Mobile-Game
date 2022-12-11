using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalStats : MonoBehaviour
{
    public static GlobalStats instance;

    /*public float baseTotalHealth = 100;
    public float baseTotalRegen = 0;
    public float baseTotalDefense = 0;
    public float baseTotalDodge = 0;
    public float baseTotalStrength = 10;
    public float baseTotalAttack = 10;
    public float baseTotalSkill = 100;
    public float baseTotalCritical = 0;
    public float baseTotalSpeed = 100;
    public float baseTotalLuck = 100;
    public float totalHealth;
    public float totalRegen;
    public float totalDefense;
    public float totalDodge;
    public float totalStrength;
    public float totalAttack;
    public float totalSkill;
    public float totalCritical;
    public float totalSpeed;
    public float totalLuck;*/

    [SerializeField] private Attribute[] attributes;


    public float gainPerHealthLevel;
    public float gainPerStrengthLevel;
    

    public InventorySO currentItems;

    

    
    public SaveDataSO saveDataSO;
    public static event EventHandler OnStatsChange;
   



    // Setup this very simple singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        
        saveDataSO.Load();
        QualitySettings.SetQualityLevel(saveDataSO.QualityLevelIndex);

    }

    private void Start()
    {
        RecalulateStats();
        //StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForFixedUpdate();
        RecalulateStats();
    }



    public void RecalulateStats()
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].baseValue = attributes[i].startValue;
            attributes[i].totalValue = attributes[i].baseValue;
        }

        attributes[0].totalValue += gainPerHealthLevel * saveDataSO.CurrentHealthLevel;
        attributes[4].totalValue += gainPerStrengthLevel * saveDataSO.CurrentStrengthLevel ;
       

        var slotList = currentItems.itemsContainer.invSlotList;
        for (int i = 0; i < slotList.Count; i++)
        {
            for (int ii = 0; ii < slotList[i].item.buffs.Length; ii++)
            {
                //Debug.Log(ReturnAttribute(slotList[i].item.buffs[ii].itemAttribute));
                ReturnAttribute(slotList[i].item.buffs[ii].itemAttribute).totalValue += slotList[i].item.buffs[ii].value;
            }
        }

        OnStatsChange?.Invoke(this, EventArgs.Empty);
        Debug.Log("Stats Recalulated");
        
        
    }

    public float Health
    {
        get { return attributes[0].totalValue; }
    }
    public float Regen
    {
        get { return attributes[1].totalValue; }
    }
    public float Defense
    {
        get { return attributes[2].totalValue; }
    }
    public float Dogde
    {
        get { return attributes[3].totalValue; }
    }
    public float Strength
    {
        get { return attributes[4].totalValue; }
    }
    public float Attack
    {
        get { return attributes[5].totalValue; }
    }
    public float Skill
    {
        get { return attributes[6].totalValue; }
    }
    public float Critical
    {
        get { return attributes[7].totalValue; }
    }
    public float Speed
    {
        get { return attributes[8].totalValue; }
    }

    public float Luck
    {
        get { return attributes[9].totalValue; }
    }



    /*public void CoinsChanged()
    {
        if (MainMenu.instance.coinsText != null)
        {
            MainMenu.instance.coinsText.ScoreShow(saveDataSO.TotalCoins);
        }

        
    }

    public void GemsChanged()
    {
        
    }*/

    public Attribute ReturnAttribute(ItemAttributes _itemAttribute)
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            if (attributes[i].itemAttribute == _itemAttribute)
            {
                return attributes[i];
                
            }
            
        }
        return null;
    }

    public void SaveCurrentItemsSO()
    {
        currentItems.Save();
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


}



[System.Serializable]
public class Attribute
{
    
    public ItemAttributes itemAttribute;
    public float startValue;
    public float baseValue;
    public float totalValue;

    
    /*public Attribute(string _name, float _baseValue)
    {
        atrributeName = _name;
        baseValue = _baseValue;
    }*/

}
