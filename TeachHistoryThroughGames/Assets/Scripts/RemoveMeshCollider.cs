using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMeshCollider : MonoBehaviour {

	public GameObject RMC;


	void Update () 
	{
		if (ScoringSystem.theScore == 1) 
		{
			//Wenn input korrekt eingegeben
			if (PasswortKeypadEins.input == PasswortKeypadEins.curPassword) 
			{ 
			//GameObject.FindGameObjectWithTag().name = "RemoveMeshCollider";
			GameObject.Destroy (RMC);
			}
		}
	}
}//end class
