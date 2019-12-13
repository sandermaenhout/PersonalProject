using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

	public void onBackButtonClicked()
	{
		SceneLoader.Instance.LoadScene("Scene_Menu");
	}

    public void onBallButtonClicked()
    {
        SceneLoader.Instance.LoadScene("Scene_Shop_Ball");
    }
}
