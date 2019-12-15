using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSoloManager : MonoBehaviour
{
    int cans = 12; //Double the value because by hit he does -2 instead of -1
    int balls = 3;

    [Header("UI")]
    public GameObject uI_InformPanelGameObject;
    public GameObject searchForGamesButtonGameObject;
    public GameObject adjust_Button;
    public GameObject raycastCenter_Image;
    public GameObject ballController;

    public GameObject restartButton;
    public TextMeshProUGUI informUIPanel_text;
    public GameObject ballsLeft;
    public TextMeshProUGUI ballsText;

    public int moneyAmount;
    public int money = 1;
    public TMP_Text moneyAmountText;
    public GameObject[] ballsLifes;



    // Start is called before the first frame update
    void Start()
    {
        uI_InformPanelGameObject.SetActive(true);
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
        ballsLeft.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = moneyAmount.ToString();
        ballsText.text = "balls: " + balls;
        WinOrLose();
    }

    public void AddMoney()
    {
        moneyAmount += money;
        Debug.Log("Money Added");
        PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
    }

    public void CansHit()
    {
        cans -= 1;
        
    }

    public void BallThrowed()
    {
        balls -= 1;

        if(balls == 2)
        {
            ballsLifes[2].gameObject.SetActive(false);
        }

        if(balls == 1)
        {
            ballsLifes[1].gameObject.SetActive(false);
        }

        if(balls == 0)
        {
            ballsLifes[0].gameObject.SetActive(false);
        }

    }

    public void WinOrLose()
    {
        if (cans <= 0 && balls >= 0)
        {
            ballController.SetActive(false);
            uI_InformPanelGameObject.SetActive(true);
            informUIPanel_text.text = "You win! Congratulations!";
            restartButton.SetActive(true);
        }
        if (balls == 0 && cans > 0)
        {
            ballController.SetActive(false);
            uI_InformPanelGameObject.SetActive(true);
            informUIPanel_text.text = "You lose! Try again!";
            restartButton.SetActive(true);
        }
    }


    #region UI Callback Methods
    public void PlayGame()
    {
        searchForGamesButtonGameObject.SetActive(false);
        adjust_Button.SetActive(false);
        raycastCenter_Image.SetActive(false);
        uI_InformPanelGameObject.SetActive(false);
        ballController.SetActive(true);
        ballsLeft.SetActive(true);
    }

    public void Restart()
    {
        SceneLoader.Instance.LoadScene("Scene_Play");
    }

    public void onQuitButtonClicked()
    {
            SceneLoader.Instance.LoadScene("Scene_Menu");
            PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
    }
    #endregion
}
