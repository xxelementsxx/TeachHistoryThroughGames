using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class CollectKiste : MonoBehaviour {

	//public ImagePosition InventarOverlayMBT; //ImagePosition kann SetActive nicht verwenden, mit GameObject umgehen in der Hierachie
	public GameObject InventarOverlayKiste;

	void OnTriggerEnter (Collider other)
	{
		if (ScoringSystem.theScore == 4)
		{
			ScoringKiste.aktuellerStand += 1;
			Destroy (gameObject);
		}
	}


	void Update ()
	{
		if (ScoringSystem.theScore == 4)
		{
			InventarOverlayKiste.SetActive (true);//Inventar für Kiste sichtbar schalten
		}
	}


}//Ende Klasse
