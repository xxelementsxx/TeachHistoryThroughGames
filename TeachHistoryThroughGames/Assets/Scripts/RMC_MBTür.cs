using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMC_MBTür : MonoBehaviour {

	public GameObject RMC;


	void Update () 
	{
		if (ScoringMBT.istStand == 3) 
		{
				GameObject.Destroy (RMC);
		}
	}
}//end class
