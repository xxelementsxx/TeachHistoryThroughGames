using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArthursPlayerProgressBar : MonoBehaviour 
{

	public Transform ArthurLoadingBar;
	public Transform ArthurTextIndicator;
	public Transform ArthurTextLoading;
	[SerializeField] private float aktuellerFortschritt;
	[SerializeField] private float Fortschrittsgeschwindigkeit;


	//Wenn der Score = 3 Wissensdiamanten, dann 
	public static int theScore; //Zugriff auf die Klasse ScoringSystem -> Variable: theScore + überprüft score

	// Update is called once per frame
	void Update ()
	{//update start

		//progess arthur #1: Gründungszeit
		if (ScoringSystem.theScore == 2) {
			if (aktuellerFortschritt < 25) { //(25) Gibt an wie viel Prozent geladen werden, wenn 1 Diamant gesammelt wurde

				aktuellerFortschritt += Fortschrittsgeschwindigkeit * Time.deltaTime; 
				ArthurTextIndicator.GetComponent<Text> ().text = ((int)aktuellerFortschritt).ToString () + "%"; 
				ArthurTextLoading.gameObject.SetActive (true); 

			} else { 
				ArthurTextLoading.gameObject.SetActive (false);
				//Wird im Center angezeigt, wenn die Progressbar 100% gefüllt ist: es erscheint: "Prima"
				ArthurTextIndicator.GetComponent<Text> ().text = "CLOSE TO YOU"; 
			}
			ArthurLoadingBar.GetComponent<Image>().fillAmount = aktuellerFortschritt / 100;
		}


	


	}//update end
}
