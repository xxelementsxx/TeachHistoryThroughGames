using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class CollectMaschinenbauteile : MonoBehaviour {

	//public ImagePosition InventarOverlayMBT; //ImagePosition kann SetActive nicht verwenden, mit GameObject umgehen in der Hierachie
	public GameObject InventarOverlayMBT;

	void OnTriggerEnter (Collider other)
	{
		//Beginnt Maschinenbauteile zu kollekten, wenn 2 Wissensdiamanten eingesammelt wurden
		if (ScoringSystem.theScore == 5)
		{
			ScoringMBT.istStand += 1;
			Destroy (gameObject);
		}
	}


	void Update ()
	{
		//InventarOverlay für die Maschinenbauteile als Symbol erscheint, wenn 2 Wissensdiamanten gesammelt wurden
		if (ScoringSystem.theScore == 5)
		{
			InventarOverlayMBT.SetActive (true);//Inventar für MBT sichtbar schalten
		}
	}


}//Ende Klasse
