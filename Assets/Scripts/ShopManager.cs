using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TMP_Text moneyAmountText;
    int moneyAmount;

    public GameObject[] balls;
    public GameObject[] cans;

    public TMP_Text BallAmount;
    public TMP_Text CanAmount;

    // Start is called before the first frame update
    void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = moneyAmount.ToString();

        BallAmount.text = balls.Length + " items";
        CanAmount.text = cans.Length + " items";
    }

    public void onBackButtonClicked()
	{
		SceneLoader.Instance.LoadScene("Scene_Menu");
	}

    public void onBallButtonClicked()
    {
        SceneLoader.Instance.LoadScene("Scene_Shop_Ball");
    }

    public void onCanButtonClicked()
    {
        SceneLoader.Instance.LoadScene("Scene_Shop_Can");
    }
}
