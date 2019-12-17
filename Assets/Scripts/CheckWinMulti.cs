using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class CheckWinMulti : MonoBehaviourPun
{
    public int cans; //Double the value because by hit he does -2 instead of -1

    public GameObject uI_InformPanelGameObject;
    public TextMeshProUGUI uI_InformText;

    public GameObject inventory_Button;
    public GameObject ballController;
    public GameObject MultiplayerManager;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WinOrLose();
    }

    public void CansHit()
    {
        cans -= 1;

    }

    public void WinOrLose()
    {
        if (cans <= 0)
        {
            if (photonView.IsMine)
            {
                ballController.SetActive(false);
                uI_InformPanelGameObject.SetActive(true);
                uI_InformText.text = "You win! Congratulations!";
            }
            else
            {
                ballController.SetActive(false);
                uI_InformPanelGameObject.SetActive(true);
                uI_InformText.text = "You lose! " + photonView.Owner.NickName + "Won the game";
            }
        }

    }
}
