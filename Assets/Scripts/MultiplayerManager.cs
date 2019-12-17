using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{
   

    [Header("UI")]
    public GameObject uI_InformPanelGameObject;
    public GameObject searchForGamesButtonGameObject;
    public GameObject adjust_Button;
    public GameObject raycastCenter_Image;
    public TextMeshProUGUI uI_InformText;

    public GameObject inventory_Button;
    public GameObject ballController;

    public int moneyAmount;
    public int money = 1;
    public TMP_Text moneyAmountText;


    // Start is called before the first frame update
    void Start()
    {
        uI_InformPanelGameObject.SetActive(true);
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = moneyAmount.ToString();
        
    }

    public void AddMoney()
    {
        moneyAmount += money;
        Debug.Log("Money Added");
        PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
    }



    #region UI Callback Methods
    public void JoinRandomRoom()
    {
        uI_InformText.text = "Searching for available rooms...";

        PhotonNetwork.JoinRandomRoom();

        searchForGamesButtonGameObject.SetActive(false);
        
    }

    public void onQuitButtonClicked()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
        else
        {
            SceneLoader.Instance.LoadScene("Scene_Menu");
            PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
        }

        PhotonNetwork.LeaveRoom();
    }


    #endregion

    #region PHOTON Callback Methods
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        uI_InformText.text = message;
        CreateAndJoinRoom();
    }

    public override void OnJoinedRoom()
    {
        adjust_Button.SetActive(false);
        raycastCenter_Image.SetActive(false);

        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            uI_InformText.text = "Joined to " + PhotonNetwork.CurrentRoom.Name + " Waiting for other Players...";
        }
        else
        {
            uI_InformText.text = "Joined to " + PhotonNetwork.CurrentRoom.Name;
            ballController.SetActive(true);
            inventory_Button.SetActive(true);
            StartCoroutine(DeactivateAfterSeconds(uI_InformPanelGameObject, 2.0f));
        }

        Debug.Log("Joined to " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name + " Player counts: " + PhotonNetwork.CurrentRoom.PlayerCount + " players");
        uI_InformText.text = newPlayer.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name + " Player counts: " + PhotonNetwork.CurrentRoom.PlayerCount + " players";

        ballController.SetActive(true);
        inventory_Button.SetActive(true);

        StartCoroutine(DeactivateAfterSeconds(uI_InformPanelGameObject, 2.0f));

       

    }

    public override void OnLeftRoom()
    {
        SceneLoader.Instance.LoadScene("Scene_Menu");
        PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
    }
    #endregion

    #region PRIVATE Methods
    void CreateAndJoinRoom()
    {
        string randomRoomName = "Room" + Random.Range(0, 1000);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;

        //creating the room
        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }

    IEnumerator DeactivateAfterSeconds(GameObject _gameObject, float _seconds)
    {
        yield return new WaitForSeconds(_seconds);
        _gameObject.SetActive(false);
    }

    #endregion
}
