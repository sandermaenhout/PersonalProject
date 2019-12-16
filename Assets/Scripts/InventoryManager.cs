using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject Inventory;

    //balls
    int isBasketBallSold;
    int isBaseBallSold;
    int isTennisBallSold;
    int isBilliardBallSold;

    int isBasketBallEquip;
    int isBaseBallEquip;
    int isTennisBallEquip;
    int isBilliardEquip;


    //cans
    int isSodaCanSold;
    int isCokeCanSold;
    int isFiftyCanSold;
    int isDevineCanSold;

    int isSodaCanEquip;
    int isCokeCanEquip;
    int isFiftyCanEquip;
    int isDevineCanEquip;

    public Button Close;
    public Button equipBasketball;
    public Button equipBaseball;
    public Button equipTennisball;
    public Button equip8ball;

    public Button equipSodaCan;
    public Button equipCokeCan;
    public Button equipFiftyCan;
    public Button equipDevineCan;
    

    // Use this for initialization

    void Start()
    {
        PlayerPrefs.SetInt("isBasketBallSold", 1);
        PlayerPrefs.SetInt("isSodaCanSold", 1);
        Close.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EquipCans();
        EquipBalls();
    }


    public void EquipCans()
    {

        isSodaCanSold = PlayerPrefs.GetInt("isSodaCanSold");
        isCokeCanSold = PlayerPrefs.GetInt("isCokeCanSold");
        isFiftyCanSold = PlayerPrefs.GetInt("isFiftyCanSold");
        isDevineCanSold = PlayerPrefs.GetInt("isDevineCanSold");

        isSodaCanEquip = PlayerPrefs.GetInt("isSodaCanEquip");
        isCokeCanEquip = PlayerPrefs.GetInt("isCokeCanEquip");
        isFiftyCanEquip = PlayerPrefs.GetInt("isFiftyCanEquip");
        isDevineCanEquip = PlayerPrefs.GetInt("isDevineCanEquip");

        if (isSodaCanSold == 1)
        {
            equipSodaCan.gameObject.SetActive(true);
        }
        else
        {
            equipSodaCan.gameObject.SetActive(false);
        }

        if (isCokeCanSold == 1)
        {
            equipCokeCan.gameObject.SetActive(true);
        }
        else
        {
            equipCokeCan.gameObject.SetActive(false);
        }

        if (isFiftyCanSold == 1)
        {
            equipFiftyCan.gameObject.SetActive(true);
        }
        else
        {
            equipFiftyCan.gameObject.SetActive(false);
        }

        if (isDevineCanSold == 1)
        {
            equipDevineCan.gameObject.SetActive(true);
        }
        else
        {
            equipDevineCan.gameObject.SetActive(false);
        }

        if (isSodaCanEquip == 1)
        {
            PlayerPrefs.SetInt("isCokeCanEquip", 0);
            PlayerPrefs.SetInt("isFiftyCanEquip", 0);
            PlayerPrefs.SetInt("isDevineCanEquip", 0);
        }

        if (isCokeCanEquip == 1)
        {
            PlayerPrefs.SetInt("isSodaCanEquip", 0);
            PlayerPrefs.SetInt("isFiftyCanEquip", 0);
            PlayerPrefs.SetInt("isDevineCanEquip", 0);
        }

        if (isFiftyCanEquip == 1)
        {
            PlayerPrefs.SetInt("isCokeCanEquip", 0);
            PlayerPrefs.SetInt("isSodaCanEquip", 0);
            PlayerPrefs.SetInt("isDevineCanEquip", 0);
        }

        if (isDevineCanEquip == 1)
        {
            PlayerPrefs.SetInt("isCokeCanEquip", 0);
            PlayerPrefs.SetInt("isFiftyCanEquip", 0);
            PlayerPrefs.SetInt("isSodaCanEquip", 0);
        }

    }

    public void SodaCan()
    {
        PlayerPrefs.SetInt("isSodaCanEquip", 1);
        PlayerPrefs.SetInt("isCokeCanEquip", 0);
        PlayerPrefs.SetInt("isFiftyCanEquip", 0);
        PlayerPrefs.SetInt("isDevineCanEquip", 0);
        PlayerPrefs.Save();
        Debug.Log("Click Soda");
    }

    public void CokeCan()
    {
        PlayerPrefs.SetInt("isSodaCanEquip", 0);
        PlayerPrefs.SetInt("isCokeCanEquip", 1);
        PlayerPrefs.SetInt("isFiftyCanEquip", 0);
        PlayerPrefs.SetInt("isDevineCanEquip", 0);
        PlayerPrefs.Save();
        Debug.Log("Click Coke");
    }

    public void FiftyCan()
    {
        PlayerPrefs.SetInt("isSodaCanEquip", 0);
        PlayerPrefs.SetInt("isCokeCanEquip", 0);
        PlayerPrefs.SetInt("isFiftyCanEquip", 1);
        PlayerPrefs.SetInt("isDevineCanEquip", 0);
        PlayerPrefs.Save();
        Debug.Log("Click fifty");
    }

    public void DevineCan()
    {
        PlayerPrefs.SetInt("isSodaCanEquip", 0);
        PlayerPrefs.SetInt("isCokeCanEquip", 0);
        PlayerPrefs.SetInt("isFiftyCanEquip", 0);
        PlayerPrefs.SetInt("isDevineCanEquip", 1);
        PlayerPrefs.Save();
        Debug.Log("Click devine");
    }

    public void EquipBalls()
    {

        isBasketBallSold = PlayerPrefs.GetInt("isBasketBallSold");
        isBaseBallSold = PlayerPrefs.GetInt("isBaseBallSold");
        isTennisBallSold = PlayerPrefs.GetInt("isTennisBallSold");
        isBilliardBallSold = PlayerPrefs.GetInt("isBilliardBallSold");

        isBasketBallEquip = PlayerPrefs.GetInt("isBasketBallEquip");
        isBaseBallEquip = PlayerPrefs.GetInt("isBaseBallEquip");
        isTennisBallEquip = PlayerPrefs.GetInt("isTennisBallEquip");
        isBilliardEquip = PlayerPrefs.GetInt("isBilliardEquip");

        if (isBasketBallSold == 1)
        {
            equipBasketball.gameObject.SetActive(true);
        }
        else
        {
            equipBasketball.gameObject.SetActive(false);
        }

        if (isBaseBallSold == 1)
        {
            equipBaseball.gameObject.SetActive(true);
        }
        else
        {
            equipBaseball.gameObject.SetActive(false);
        }

        if (isTennisBallSold == 1)
        {
            equipTennisball.gameObject.SetActive(true);
        }
        else
        {
            equipTennisball.gameObject.SetActive(false);
        }

        if (isBilliardBallSold == 1)
        {
            equip8ball.gameObject.SetActive(true);
        }
        else
        {
            equip8ball.gameObject.SetActive(false);
        }

        if (isBasketBallEquip == 1)
        {
            PlayerPrefs.SetInt("isCokeCanEquip", 0);
            PlayerPrefs.SetInt("isFiftyCanEquip", 0);
            PlayerPrefs.SetInt("isDevineCanEquip", 0);
        }

        if (isBaseBallEquip == 1)
        {
            PlayerPrefs.SetInt("isSodaCanEquip", 0);
            PlayerPrefs.SetInt("isFiftyCanEquip", 0);
            PlayerPrefs.SetInt("isDevineCanEquip", 0);
        }

        if (isTennisBallEquip == 1)
        {
            PlayerPrefs.SetInt("isCokeCanEquip", 0);
            PlayerPrefs.SetInt("isSodaCanEquip", 0);
            PlayerPrefs.SetInt("isDevineCanEquip", 0);
        }

        if (isBilliardEquip == 1)
        {
            PlayerPrefs.SetInt("isCokeCanEquip", 0);
            PlayerPrefs.SetInt("isFiftyCanEquip", 0);
            PlayerPrefs.SetInt("isSodaCanEquip", 0);
        }

    }

    public void BasketBall()
    {
        PlayerPrefs.SetInt("isBasketBallEquip", 1);
        PlayerPrefs.SetInt("isBaseBallEquip", 0);
        PlayerPrefs.SetInt("isTennisBallEquip", 0);
        PlayerPrefs.SetInt("isBilliardEquip", 0);
        PlayerPrefs.Save();
    }

    public void BaseBall()
    {
        PlayerPrefs.SetInt("isBasketBallEquip", 0);
        PlayerPrefs.SetInt("isBaseBallEquip", 1);
        PlayerPrefs.SetInt("isTennisBallEquip", 0);
        PlayerPrefs.SetInt("isBilliardEquip", 0);
        PlayerPrefs.Save();
    }

    public void TennisBall()
    {
        PlayerPrefs.SetInt("isBasketBallEquip", 0);
        PlayerPrefs.SetInt("isBaseBallEquip", 0);
        PlayerPrefs.SetInt("isTennisBallEquip", 1);
        PlayerPrefs.SetInt("isBilliardEquip", 0);
        PlayerPrefs.Save();
    }

    public void BilliardBall()
    {
        PlayerPrefs.SetInt("isBasketBallEquip", 0);
        PlayerPrefs.SetInt("isBaseBallEquip", 0);
        PlayerPrefs.SetInt("isTennisBallEquip", 0);
        PlayerPrefs.SetInt("isBilliardEquip", 1);
        PlayerPrefs.Save();
    }

    public void openInventory()
    {
        Inventory.gameObject.SetActive(true);
        Close.gameObject.SetActive(true);
    }

    public void exitInventory()
    {
        Inventory.gameObject.SetActive(false);
        Close.gameObject.SetActive(false);
    }


}
