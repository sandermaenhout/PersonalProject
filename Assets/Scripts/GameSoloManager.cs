using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSoloManager : MonoBehaviour
{

    [Header("UI")]
    public GameObject uI_InformPanelGameObject;
    public GameObject searchForGamesButtonGameObject;
    public GameObject adjust_Button;
    public GameObject raycastCenter_Image;
    public GameObject ballController;

    public int moneyAmount;
    public int money = 1;
    public TMP_Text moneyAmountText;

    // Start is called before the first frame update
    void Start()
    {
        uI_InformPanelGameObject.SetActive(true);

        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = moneyAmount.ToString();
    }

    public void AddMoney()
    {
        moneyAmount += money;
        Debug.Log("Money Added");
        PlayerPrefs.Save();
    }



    #region UI Callback Methods
    public void PlayGame()
    { 
        searchForGamesButtonGameObject.SetActive(false);
        adjust_Button.SetActive(false);
        raycastCenter_Image.SetActive(false);
        uI_InformPanelGameObject.SetActive(false);
        ballController.SetActive(true);
    }

    public void onQuitButtonClicked()
    {
            SceneLoader.Instance.LoadScene("Scene_Menu");
            PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
    }
    #endregion
}
