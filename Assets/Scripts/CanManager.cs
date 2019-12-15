using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanManager : MonoBehaviour
{
	int isCokeCanEquip;
    int isFiftyCanEquip;
    int isDevineCanEquip;

    private bool canHits;

    public Renderer rend;
    public Material[] canModels;

	public int canSelectorNumber;

    public GameObject _gameSoloManager;
    public GameObject can;

    // Start is called before the first frame update
    void Start()
    {

        isCokeCanEquip = PlayerPrefs.GetInt("isCokeCanEquip");
        isFiftyCanEquip = PlayerPrefs.GetInt("isFiftyCanEquip");
        isDevineCanEquip = PlayerPrefs.GetInt("isDevineCanEquip");

        canSelectorNumber = 0;

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
            can.gameObject.SetActive(false);
            _gameSoloManager.GetComponent<GameSoloManager>().CansHit();
            _gameSoloManager.GetComponent<GameSoloManager>().AddMoney();

        }



    }

}
