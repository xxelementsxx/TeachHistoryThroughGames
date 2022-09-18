using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class ScoringMBT : MonoBehaviour 
{

	public GameObject ScoreTextMBT;
	public static int istStand;


	void Update()
	{
		//zeigt den aktuellen Maschinenbauteilstand, die eingesammelt wurden
		ScoreTextMBT.GetComponent<Text> ().text = " " + istStand;
		if (ScoringSystem.theScore == 5) 
		{
			ScoreTextMBT.SetActive (true);
		}
	}
}

