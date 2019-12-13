using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class OptionsManager : MonoBehaviour
{

    public AudioMixer audioMixer;
    public TMP_Dropdown qualityDropdown;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        qualityIndex = qualityDropdown.value;
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void onBackButtonClicked()
    {
        SceneLoader.Instance.LoadScene("Scene_Menu");
    }
}
