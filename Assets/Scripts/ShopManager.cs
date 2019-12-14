using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
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

    public void onBackButtonClicked()
	{
		SceneLoader.Instance.LoadScene("Scene_Menu");
	}

    public void onBallButtonClicked()
    {
        SceneLoader.Instance.LoadScene("Scene_Shop_Ball");
    }
}
