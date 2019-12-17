using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanManager : MonoBehaviour
{
    int isSodaCanEquip;
    int isCokeCanEquip;
    int isFiftyCanEquip;
    int isDevineCanEquip;

    public Renderer rend;
    //public bool multiplayer;
    public Material[] canModels;
    public AudioSource canFallingSound;

	public int canSelectorNumber;

    public GameObject _gameSoloManager;
    public GameObject _multiplayerManager;
    public GameObject _checkwin;
    public GameObject can;

    // Start is called before the first frame update
    void Update()
    {
        isSodaCanEquip = PlayerPrefs.GetInt("isSodaCanEquip");
        isCokeCanEquip = PlayerPrefs.GetInt("isCokeCanEquip");
        isFiftyCanEquip = PlayerPrefs.GetInt("isFiftyCanEquip");
        isDevineCanEquip = PlayerPrefs.GetInt("isDevineCanEquip");


        if (isSodaCanEquip == 1)
        {
            canSelectorNumber = 0;
        }
        if (isCokeCanEquip == 1)
        {
            canSelectorNumber = 1;
        }
        if (isFiftyCanEquip == 1)
        {
            canSelectorNumber = 2;
        }
        if (isDevineCanEquip == 1)
        {
            canSelectorNumber = 3;
        }

        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = canModels[canSelectorNumber];
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            canFallingSound.Play();
            can.gameObject.SetActive(false);
            if(_gameSoloManager == null)
            {
                _checkwin.GetComponent<CheckWinMulti>().CansHit();
                _multiplayerManager.GetComponent<MultiplayerManager>().AddMoney();
            }
            else
            {
                _gameSoloManager.GetComponent<GameSoloManager>().CansHit();
                _gameSoloManager.GetComponent<GameSoloManager>().AddMoney();
            }
            

        }



    }

}
