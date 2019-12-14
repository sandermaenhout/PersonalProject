using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;

public class PlayMenuManager : MonoBehaviourPunCallbacks
{
    int moneyAmount;
    public TMP_Text moneyAmountText;

    [Header("Login UI")]
    public InputField PlayerNameInputField;
    public GameObject uI_LoginGameobject;

    [Header("Lobby UI")]
    public GameObject uI_LobbyGameobject;

    [Header("Connection Status UI")]
    public GameObject uI_ConnectionStatusGameobject;
    public Text connectionStatusText;
    public bool showConnectionStatus = false;



    #region UNITY METHODS
    // Start is called before the first frame update
    void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
    }


    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = moneyAmount.ToString();

        if (showConnectionStatus == true)
        {
            connectionStatusText.text = "Connection Status: " + PhotonNetwork.NetworkClientState;
        }

    }
    #endregion

    #region UI Callback Methods
    public void OnEnterGameButtonClicked()
    {

        string playerName = PlayerNameInputField.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            uI_LobbyGameobject.SetActive(false);
            uI_LoginGameobject.SetActive(false);

            showConnectionStatus = true;
            uI_ConnectionStatusGameobject.SetActive(true);

            if (!PhotonNetwork.IsConnected)
            {
                PhotonNetwork.LocalPlayer.NickName = playerName;

                PhotonNetwork.ConnectUsingSettings();
            }
        }
        else
        {
            Debug.Log("Player name is invalid or empty");
        }
    }

    public void OnBackButtonClicked()
    {
        //SceneManager.LoadScene("Scene_Loading");
        SceneLoader.Instance.LoadScene("Scene_Menu");
    }

    public void OnSoloButtonClicked()
    {
        //SceneManager.LoadScene("Scene_Loading");
        SceneLoader.Instance.LoadScene("Scene_Play");
    }

    public void OnMultiplayerButtonClicked()
    {
        if (PhotonNetwork.IsConnected)
        {
            SceneLoader.Instance.LoadScene("Scene_PlayMultiplayer");
        }
        else
        {
            uI_LobbyGameobject.SetActive(false);
            uI_ConnectionStatusGameobject.SetActive(false);

            uI_LoginGameobject.SetActive(true);
        }
    }
    #endregion

    #region PHOTON Callback Methods
    public override void OnConnected()
    {
        Debug.Log("We connected to the internet");

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " is connected to Photon servers");

        SceneLoader.Instance.LoadScene("Scene_PlayMultiplayer");

    }
    #endregion
}
