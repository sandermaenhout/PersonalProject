using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class OptionsManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown qualityDropdown;
    public TMP_Text moneyAmountText;
    public int moneyAmount;

    // Start is called before the first frame update
    void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = moneyAmount.ToString();
    }

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
