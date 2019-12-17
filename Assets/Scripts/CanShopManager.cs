using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CanShopManager : MonoBehaviour
{

    int moneyAmount;

    int isCokeCanSold;
    int isFiftyCanSold;
    int isDevineCanSold;

    int isCokeCanEquip;
    int isFiftyCanEquip;
    int isDevineCanEquip;

    public TMP_Text moneyAmountText;

    public TMP_Text CokeCanPrice;
    public TMP_Text FiftyCanPrice;
    public TMP_Text DevineCanPrice;

    public Button buyButtonCokeCan;
    public Button equipButtonCokeCan;
    public Button buyButtonFiftyCan;
    public Button equipButtonFiftyCan;
    public Button buyButtonDevineCan;
    public Button equipButtonDevineCan;

    // Use this for initialization

    void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount", 100);


    }

    // Update is called once per frame
    void Update()
    {

        moneyAmountText.text = moneyAmount.ToString();

        CheckCokeCan();
        CheckFiftyCan();
        CheckDevineCan();

    }

    public void CheckCokeCan()
    {

        isCokeCanSold = PlayerPrefs.GetInt("isCokeCanSold");
        isCokeCanEquip = PlayerPrefs.GetInt("isCokeCanEquip");

        if (isCokeCanSold == 0 && moneyAmount >= 25)
        {
            buyButtonCokeCan.interactable = true;
        }
        else
        {
            buyButtonCokeCan.interactable = false;
        }

        if (isCokeCanSold == 1)
        {
            equipButtonCokeCan.gameObject.SetActive(true);
            buyButtonCokeCan.gameObject.SetActive(false);
        }

        else
        {
            equipButtonCokeCan.gameObject.SetActive(false);
            buyButtonCokeCan.gameObject.SetActive(true);
        }

        if (isCokeCanEquip == 1)
        {
            equipButtonCokeCan.gameObject.SetActive(false);
        }
    }

    public void CheckFiftyCan()
    {

        isFiftyCanSold = PlayerPrefs.GetInt("isFiftyCanSold");
        isFiftyCanEquip = PlayerPrefs.GetInt("isFiftyCanEquip");

        if (isFiftyCanSold == 0 && moneyAmount >= 50)
        {
            buyButtonFiftyCan.interactable = true;
        }
        else
        {
            buyButtonFiftyCan.interactable = false;
        }

        if (isFiftyCanSold == 1)
        {
            equipButtonFiftyCan.gameObject.SetActive(true);
            buyButtonFiftyCan.gameObject.SetActive(false);
        }
        else
        {
            equipButtonFiftyCan.gameObject.SetActive(false);
            buyButtonFiftyCan.gameObject.SetActive(true);
        }

        if (isFiftyCanEquip == 1)
        {
            equipButtonFiftyCan.gameObject.SetActive(false);
        }
    }

    public void CheckDevineCan()
    {

        isDevineCanSold = PlayerPrefs.GetInt("isDevineCanSold");
        isDevineCanEquip = PlayerPrefs.GetInt("isDevineCanEquip");

        if (isDevineCanSold == 0 && moneyAmount >= 125)
        {
            buyButtonDevineCan.interactable = true;
        }
        else
        {
            buyButtonDevineCan.interactable = false;
        }

        if (isDevineCanSold == 1)
        {
            equipButtonDevineCan.gameObject.SetActive(true);
            buyButtonDevineCan.gameObject.SetActive(false);
        }
        else
        {
            equipButtonDevineCan.gameObject.SetActive(false);
            buyButtonDevineCan.gameObject.SetActive(true);
        }

        if (isDevineCanEquip == 1)
        {
            equipButtonDevineCan.gameObject.SetActive(false);
        }

    }

    public void buyCokeCan()
    {


        moneyAmount -= 25;
        PlayerPrefs.SetInt("isCokeCanSold", 1);
        CokeCanPrice.text = "Sold!";
        buyButtonCokeCan.gameObject.SetActive(false);
        PlayerPrefs.Save();
    }

    public void equipCokeCan()
    {
        isFiftyCanEquip = PlayerPrefs.GetInt("isFiftyCanEquip");
        isDevineCanEquip = PlayerPrefs.GetInt("isDevineCanEquip");



        if (isFiftyCanEquip == 1)
        {
            PlayerPrefs.SetInt("isFiftyCanEquip", 0);
            FiftyCanPrice.text = "Sold!";
        }
        if (isDevineCanEquip == 1)
        {
            PlayerPrefs.SetInt("isDevineCanEquip", 0);
            DevineCanPrice.text = "Sold!";
        }

        PlayerPrefs.SetInt("isCokeCanEquip", 1);
        CokeCanPrice.text = "Equiped!";
        buyButtonCokeCan.gameObject.SetActive(false);
        equipButtonCokeCan.gameObject.SetActive(false);
        PlayerPrefs.Save();
    }

    public void buyFiftyCan()
    {
        moneyAmount -= 50;
        PlayerPrefs.SetInt("isFiftyCanSold", 1);
        FiftyCanPrice.text = "Sold!";
        buyButtonFiftyCan.gameObject.SetActive(false);
        PlayerPrefs.Save();
    }

    public void equipFiftyCan()
    {
        isCokeCanEquip = PlayerPrefs.GetInt("isCokeCanEquip");
        isDevineCanEquip = PlayerPrefs.GetInt("isDevineCanEquip");

        if (isCokeCanEquip == 1)
        {
            PlayerPrefs.SetInt("isCokeCanEquip", 0);
            CokeCanPrice.text = "Sold!";
        }
        if (isDevineCanEquip == 1)
        {
            PlayerPrefs.SetInt("isDevineCanEquip", 0);
            DevineCanPrice.text = "Sold!";
        }

        PlayerPrefs.SetInt("isFiftyCanEquip", 1);
        FiftyCanPrice.text = "Equiped!";
        buyButtonFiftyCan.gameObject.SetActive(false);
        equipButtonDevineCan.gameObject.SetActive(false);
        PlayerPrefs.Save();
    }

    public void buyDevineCan()
    {
        moneyAmount -= 125;
        PlayerPrefs.SetInt("isDevineCanSold", 1);
        DevineCanPrice.text = "Sold!";
        buyButtonDevineCan.gameObject.SetActive(false);
        PlayerPrefs.Save();
    }

    public void equipDevineCan()
    {
        isCokeCanEquip = PlayerPrefs.GetInt("isCokeCanEquip");
        isFiftyCanEquip = PlayerPrefs.GetInt("isFiftyCanEquip");

        if (isFiftyCanEquip == 1)
        {
            PlayerPrefs.SetInt("isFiftyCanEquip", 0);
            FiftyCanPrice.text = "Sold!";
        }
        if (isCokeCanEquip == 1)
        {
            PlayerPrefs.SetInt("isCokeCanEquip", 0);
            CokeCanPrice.text = "Sold!";
        }

        PlayerPrefs.SetInt("isDevineCanEquip", 1);
        DevineCanPrice.text = "Equiped!";
        buyButtonDevineCan.gameObject.SetActive(false);
        equipButtonDevineCan.gameObject.SetActive(false);
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
