using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BallShopManager : MonoBehaviour
{

    int moneyAmount = 10;
    int isBaseBallSold;

    public TMP_Text moneyAmountText;
    public TMP_Text BaseBallPrice;

    public Button buyButton;

    // Use this for initialization
    void Start()
    {
        Debug.Log(moneyAmount);
        //moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(moneyAmount);

        moneyAmountText.text = moneyAmount.ToString();

        isBaseBallSold = PlayerPrefs.GetInt("isBaseBallSold");
        
        if (moneyAmount >= 10 && isBaseBallSold == 0)
            buyButton.interactable = true;
        else
            buyButton.interactable = false;
    }

    public void buyBaseBall()
    {
        moneyAmount -= 10;
        PlayerPrefs.SetInt("isBaseBallSold", 1);
        BaseBallPrice.text = "Sold!";
        buyButton.gameObject.SetActive(false);
    }

    public void exitShop()
    {
        PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
        SceneLoader.Instance.LoadScene("Scene_Shop");
    }

}
