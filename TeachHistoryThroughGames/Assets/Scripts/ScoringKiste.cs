using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class ScoringKiste : MonoBehaviour 
{

	public GameObject ScoreTextKiste;
	public static int aktuellerStand;


	void Update()
	{
		//zeigt den aktuellen Maschinenbauteilstand, die eingesammelt wurden
		ScoreTextKiste.GetComponent<Text> ().text = " " + aktuellerStand;
		if (ScoringSystem.theScore == 4) 
		{
			ScoreTextKiste.SetActive (true);
		}
	}
}

