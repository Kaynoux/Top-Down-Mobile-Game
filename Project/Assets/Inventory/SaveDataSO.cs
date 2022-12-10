using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Runtime.Serialization;


[CreateAssetMenu(fileName = "New SaveFile", menuName = "Items/SaveFile")]
public class SaveDataSO : ScriptableObject
{
    public string savePath;

    public static SaveDataSO instance;

    public SaveClass saveClass = new SaveClass();
    public static event EventHandler OnCoinChange;
    public static event EventHandler OnGemChange;

    private void Awake()
    {
        instance = this;
    }

    [ContextMenu("Save")]
    private void Save()
    {
        //string saveData = JsonUtility.ToJson(this, true);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        //bf.Serialize(file, saveData);
        //file.Close();

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, saveClass);
        stream.Close();

    }
    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            //JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            //file.Close();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            saveClass = (SaveClass)formatter.Deserialize(stream);
            stream.Close();
        }
    }
    [ContextMenu("Clear")]
    public void Clear()
    {
        saveClass = new SaveClass();
    }

    public float TotalCoins
    {
        get { return saveClass.totalCoins; }
        set { saveClass.totalCoins = value; Save(); OnCoinChange?.Invoke(this, EventArgs.Empty); }
    }

    public float TotalGems
    {
        get { return saveClass.totalGems; }
        set { saveClass.totalGems = value; Save(); OnGemChange?.Invoke(this, EventArgs.Empty); ; }
    }

    public int CurrentHealthLevel
    {
        get { return saveClass.currentHealthLevel; }
        set { saveClass.currentHealthLevel = value; Save(); }
    }

    public int CurrentStrengthLevel
    {
        get { return saveClass.currentStrengthLevel; }
        set { saveClass.currentStrengthLevel = value; Save(); }
    }

    public float MusicVolume
    {
        get { return saveClass.musicVolume; }
        set { saveClass.musicVolume = value; Save(); }
    }

    public float SoundVolume
    {
        get { return saveClass.soundVolume; }
        set { saveClass.soundVolume = value; Save(); }
    }

    public int QualityLevelIndex
    {
        get { return saveClass.qualityLevelIndex; }
        set { saveClass.qualityLevelIndex = value; Save(); }


    }
}

[System.Serializable]
public class SaveClass
{
    public float totalCoins;
    public float totalGems;

    public int currentHealthLevel;
    public int currentStrengthLevel;

    public float musicVolume;
    public float soundVolume;

    public int qualityLevelIndex;

    
}


