using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public SaveDataSO saveDataSO;
    public TMP_Dropdown dropdown;

    public Slider musicSlider;
    public Slider soundSlider;

    private void OnEnable()
    {
        musicSlider.value = saveDataSO.MusicVolume;
        soundSlider.value = saveDataSO.SoundVolume;
        dropdown.value = QualitySettings.GetQualityLevel();
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicParam", volume);
        saveDataSO.MusicVolume = volume;
    }

    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat("SoundParam", volume);
        saveDataSO.SoundVolume = volume;
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
        saveDataSO.QualityLevelIndex = index;
    }
}
