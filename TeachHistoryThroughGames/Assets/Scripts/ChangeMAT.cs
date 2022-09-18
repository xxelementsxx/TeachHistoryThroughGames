using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class ChangeMAT : MonoBehaviour {

	//public static Material DefaultMAT01Knopf;
	public GameObject FeedbackMAT01Knopf;


	void Update ()
	{
		if (ScoringSystem.theScore == 1) //BALANCING
		{
			StartCoroutine (ChangeMATERIAL ());
		}
	}


	IEnumerator ChangeMATERIAL ()
	{
		yield return new WaitForSeconds (0.1f);
		FeedbackMAT01Knopf.SetActive (true);
	}
	

}
