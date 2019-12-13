using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoloManager : MonoBehaviour
{

    [Header("UI")]
    public GameObject uI_InformPanelGameObject;
    public GameObject searchForGamesButtonGameObject;
    public GameObject adjust_Button;
    public GameObject raycastCenter_Image;
    public GameObject ballController;


    // Start is called before the first frame update
    void Start()
    {
        uI_InformPanelGameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region UI Callback Methods
    public void PlayGame()
    { 
        searchForGamesButtonGameObject.SetActive(false);
        adjust_Button.SetActive(false);
        raycastCenter_Image.SetActive(false);
        uI_InformPanelGameObject.SetActive(false);
        ballController.SetActive(true);
    }

    public void onQuitButtonClicked()
    {
            SceneLoader.Instance.LoadScene("Scene_Menu");
    }
    #endregion
}
