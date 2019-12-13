using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BallShopManager : MonoBehaviour
{

    int moneyAmount = 100;
    int isBaseBallSold;

    public TMP_Text moneyAmountText;
    public TMP_Text BaseBallPrice;

    public Button buyButton;
    public Button equipButton;

    // Use this for initialization
    void Start()
    {
        Debug.Log(moneyAmount);
        //moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
    }

    // Update is called once per frame
    void Update()
    {

        moneyAmountText.text = moneyAmount.ToString();

        isBaseBallSold = PlayerPrefs.GetInt("isBaseBallSold");

        Debug.Log(moneyAmount);

        if (moneyAmount >= 10)
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
        }

        if (isBaseBallSold == 0)
        {
          buyButton.gameObject.SetActive(true);
        }
        else
        {
          equipButton.gameObject.SetActive(true);
          buyButton.gameObject.SetActive(false);
        }
    }

    public void buyBaseBall()
    {
        moneyAmount -= 10;
        PlayerPrefs.SetInt("isBaseBallSold", 1);
        BaseBallPrice.text = "Sold!";
        buyButton.gameObject.SetActive(false);
    }

    public void equipBaseBall()
    {
        moneyAmount -= 10;
        PlayerPrefs.SetInt("isBaseBallequip", 1);
        BaseBallPrice.text = "Equiped!";
        buyButton.gameObject.SetActive(false);
        equipButton.gameObject.SetActive(false);
    }

    public void exitShop()
    {
        PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
        SceneLoader.Instance.LoadScene("Scene_Shop");
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
