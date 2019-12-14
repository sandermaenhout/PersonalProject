using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BallShopManager : MonoBehaviour
{

    int moneyAmount;

    int isBaseBallSold;
    int isTennisBallSold;
    int isBilliardBallSold;

    int isBaseBallEquip;
    int isTennisBallEquip;
    int isBilliardEquip;

    public TMP_Text moneyAmountText;

    public TMP_Text BaseBallPrice;
    public TMP_Text TennisPrice;
    public TMP_Text BilliardPrice;

    public Button buyButtonBaseball;
    public Button equipButtonBaseball;
    public Button buyButtonTennis;
    public Button equipButtonTennis;
    public Button buyButtonBilliard;
    public Button equipButtonBilliard;

    // Use this for initialization

    void Start()
    { 
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount", 100);

        
    }

    // Update is called once per frame
    void Update()
    {

        moneyAmountText.text = moneyAmount.ToString();

        CheckBaseball();
        CheckTennis();
        CheckBilliard();

    }

    public void CheckBaseball()
    {
        
        isBaseBallSold = PlayerPrefs.GetInt("isBaseBallSold");
        isBaseBallEquip = PlayerPrefs.GetInt("isBaseBallEquip");

        if (isBaseBallSold == 0 && moneyAmount >= 10)
        {
            buyButtonBaseball.interactable = true;
        }
        else
        {
            buyButtonBaseball.interactable = false;
        }

        if (isBaseBallSold == 1)
        {
            equipButtonBaseball.gameObject.SetActive(true);
            buyButtonBaseball.gameObject.SetActive(false);
        }
        
        else
        {
            equipButtonBaseball.gameObject.SetActive(false);
            buyButtonBaseball.gameObject.SetActive(true);
        }

        if (isBaseBallEquip == 1)
        {
            equipButtonBaseball.gameObject.SetActive(false);
        }
    }

    public void CheckTennis()
    {

        isTennisBallSold = PlayerPrefs.GetInt("isTennisBallSold");
        isTennisBallEquip = PlayerPrefs.GetInt("isTennisBallEquip");

        if (isTennisBallSold == 0 && moneyAmount >= 30)
        {
            buyButtonTennis.interactable = true;
        }
        else
        {
            buyButtonTennis.interactable = false;
        }

        if (isTennisBallSold == 1)
        {
            equipButtonTennis.gameObject.SetActive(true);
            buyButtonTennis.gameObject.SetActive(false);
        }
        else
        {
            equipButtonTennis.gameObject.SetActive(false);
            buyButtonTennis.gameObject.SetActive(true);
        }

        if (isTennisBallEquip == 1)
        {
            equipButtonTennis.gameObject.SetActive(false);
        }
    }

    public void CheckBilliard()
    {

        isBilliardBallSold = PlayerPrefs.GetInt("isBilliardBallSold");
        isBilliardEquip = PlayerPrefs.GetInt("isBilliardEquip");

        if (isBilliardBallSold == 0 && moneyAmount >= 50)
        {
            buyButtonBilliard.interactable = true;
        }
        else
        {
            buyButtonBilliard.interactable = false;
        }

        if (isBilliardBallSold == 1)
        {
            equipButtonBilliard.gameObject.SetActive(true);
            buyButtonBilliard.gameObject.SetActive(false);
        }
        else
        {
            equipButtonBilliard.gameObject.SetActive(false);
            buyButtonBilliard.gameObject.SetActive(true);
        }

        if (isBilliardEquip == 1)
        {
            equipButtonBilliard.gameObject.SetActive(false);
        }

    }

    public void buyBaseBall()
    {
        

        moneyAmount -= 10;
        PlayerPrefs.SetInt("isBaseBallSold", 1);
        BaseBallPrice.text = "Sold!";
        buyButtonBaseball.gameObject.SetActive(false);
        PlayerPrefs.Save();
    }

    public void equipBaseBall()
    {
        isTennisBallEquip = PlayerPrefs.GetInt("isTennisBallEquip");
        isBilliardEquip = PlayerPrefs.GetInt("isBilliardEquip");

        isBaseBallSold = PlayerPrefs.GetInt("isBaseBallSold");

        

        if (isTennisBallEquip == 1)
        {
            PlayerPrefs.SetInt("isTennisBallEquip", 0);
            TennisPrice.text = "Sold!";
        }
        if (isBilliardEquip == 1)
        {
            PlayerPrefs.SetInt("isBilliardEquip", 0);
            BilliardPrice.text = "Sold!";
        }

        PlayerPrefs.SetInt("isBaseBallEquip", 1);
        BaseBallPrice.text = "Equiped!";
        buyButtonBaseball.gameObject.SetActive(false);
        equipButtonBaseball.gameObject.SetActive(false);
        PlayerPrefs.Save();
    }

    public void buyTennisBall()
    {
        moneyAmount -= 30;
        PlayerPrefs.SetInt("isTennisBallSold", 1);
        TennisPrice.text = "Sold!";
        buyButtonTennis.gameObject.SetActive(false);
        PlayerPrefs.Save();
    }

    public void equipTennisBall()
    {
        isBaseBallEquip = PlayerPrefs.GetInt("isBaseBallEquip");
        isBilliardEquip = PlayerPrefs.GetInt("isBilliardEquip");

        if (isBaseBallEquip == 1)
        {
            PlayerPrefs.SetInt("isBaseBallEquip", 0);
            BaseBallPrice.text = "Sold!";
        }
        if (isBilliardEquip == 1)
        {
            PlayerPrefs.SetInt("isBilliardEquip", 0);
            BilliardPrice.text = "Sold!";
        }

        PlayerPrefs.SetInt("isTennisBallEquip", 1);
        TennisPrice.text = "Equiped!";
        buyButtonTennis.gameObject.SetActive(false);
        equipButtonTennis.gameObject.SetActive(false);
        PlayerPrefs.Save();
    }

    public void buyBilliardBall()
    {
        moneyAmount -= 50;
        PlayerPrefs.SetInt("isBilliardBallSold", 1);
        BilliardPrice.text = "Sold!";
        buyButtonBilliard.gameObject.SetActive(false);
        PlayerPrefs.Save();
    }

    public void equipBilliardBall()
    {
        isBaseBallEquip = PlayerPrefs.GetInt("isBaseBallEquip");
        isTennisBallEquip = PlayerPrefs.GetInt("isTennisBallEquip");

        if (isTennisBallEquip == 1)
        {
            PlayerPrefs.SetInt("isTennisBallEquip", 0);
            TennisPrice.text = "Sold!";
        }
        if (isBaseBallEquip == 1)
        {
            PlayerPrefs.SetInt("isBaseBallEquip", 0);
            BaseBallPrice.text = "Sold!";
        }

        PlayerPrefs.SetInt("isBilliardEquip", 1);
        BilliardPrice.text = "Equiped!";
        buyButtonBilliard.gameObject.SetActive(false);
        equipButtonBilliard.gameObject.SetActive(false);
        PlayerPrefs.Save();
    }


    public void exitShop()
    {
        PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
        SceneLoader.Instance.LoadScene("Scene_Shop");
        PlayerPrefs.Save();
    }

    void OnGUI()
    {
        //Delete all of the PlayerPrefs settings by pressing this Button
        if (GUI.Button(new Rect(100, 200, 200, 60), "Delete"))
        {
            PlayerPrefs.DeleteAll();
        }
    }

}
