using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnlights : MonoBehaviour {

	//Zuweisung für das Objekt (die Leuchten im Physikhörsaal -> GO, was diese trägt) was aktiviert werden soll
	public GameObject PhysiclightsSetActive;
	public GameObject spawn3DMaschineInMBLehrraum; //setzt eine 3D Maschine, als Belohnung des Einsammelns der Maschinenbauteile, aktiv

	//Für Funktionsermöglichung benötigt: Open door Maschinenbauraum, wenn 3 von 3 Maschinenbauteile gesammelt sind
	public Transform openDoorByTurnHinge;
	//public bool StatusIfDoorIsOpenOrClosed; //Zeigt den Status (geschlossen oder geöffnet) der Öffnung der Türe an

	void Update () 
	{
		if (ScoringSystem.theScore == 5) 
		{ //Wenn 5 Wissensdiamanten-Score 5 ist, dann setze die Beleuchtungsanlage mit gegebenen Leuchten aktiv.
			PhysiclightsSetActive.SetActive (true);
			//Wenn der Maschinenbauteil-Score 3 ist, dann führe Funktion zur Maschinenbauraumtürdrehung aus und setze das 3D-Maschinenasset aktiv.
			if (ScoringMBT.istStand == 3) 
			{
				spawn3DMaschineInMBLehrraum.SetActive (true);
					//öffnet die Tür, indem das Tür Scharnier (door hinge), um 90 Grad gedreht wird
					var newRotTür = Quaternion.RotateTowards (openDoorByTurnHinge.rotation, Quaternion.Euler (0.0f, -90.0f, 0.0f), Time.deltaTime * 250);
					openDoorByTurnHinge.rotation = newRotTür;
			//	}
			}
		}
	}
		

}
