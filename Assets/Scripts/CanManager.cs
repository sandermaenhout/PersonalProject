using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanManager : MonoBehaviour
{
	int isCokeEquip;

	public Renderer rend;
	public Material[] canModels;

	public int canSelectorNumber;

	// Start is called before the first frame update
	void Start()
    {

		isCokeEquip = PlayerPrefs.GetInt("isCokeEquip");

		canSelectorNumber = 0;

		if (isCokeEquip == 1)
		{
			canSelectorNumber = 1;
		}
		//if (isBilliardBallequip == 1)
		//{
		//    ballSelectorNumber = 1;
		//}

		rend = GetComponent<Renderer>();
		rend.enabled = true;
		rend.sharedMaterial = canModels[canSelectorNumber];
	}


}
