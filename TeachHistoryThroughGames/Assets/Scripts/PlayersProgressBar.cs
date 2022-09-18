using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayersProgressBar : MonoBehaviour 
{

	public Transform LoadingBar;
	public Transform TextIndicator;
	public Transform TextLoading;
	[SerializeField] private float currentAmount;
	[SerializeField] private float speed;


	//Wenn der Score = 3 Wissensdiamanten, dann 
	public static int theScore; //Zugriff auf die Klasse ScoringSystem -> Variable: theScore + überprüft score

	// Update is called once per frame
	void Update () 
	{//update start

		//progess task #1: Gründungszeit
		if (ScoringSystem.theScore == 1) {
			if (currentAmount < 10) { //(10) Gibt an wie viel Prozent geladen werden, wenn 1 Diamant gesammelt wurde
				//
				currentAmount += speed * Time.deltaTime; 
				TextIndicator.GetComponent<Text> ().text = ((int)currentAmount).ToString () + "%"; 
				TextLoading.gameObject.SetActive (true); 

			} else { 
				TextLoading.gameObject.SetActive (false);
				//Wird im Center angezeigt, wenn die Progressbar 100% gefüllt ist: es erscheint: "Prima"
				TextIndicator.GetComponent<Text> ().text = "PRIMA"; 
			}
		LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
		}


		//progess task #2:
		if (ScoringSystem.theScore == 2) {
			if (currentAmount < 30) { //(10) Gibt an wie viel Prozent geladen werden, wenn 1 Diamant gesammelt wurde
				//
				currentAmount += speed * Time.deltaTime; 
				TextIndicator.GetComponent<Text> ().text = ((int)currentAmount).ToString () + "%"; 
				TextLoading.gameObject.SetActive (true); 

			} else { 
				TextLoading.gameObject.SetActive (false);
				//Wird im Center angezeigt, wenn die Progressbar 100% gefüllt ist: es erscheint: "Prima"
				TextIndicator.GetComponent<Text> ().text = "WORKS"; 
			}
			LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
		}


		//progess task #3:
		if (ScoringSystem.theScore == 3) {
			if (currentAmount < 55) { //(10) Gibt an wie viel Prozent geladen werden, wenn 1 Diamant gesammelt wurde
				//
				currentAmount += speed * Time.deltaTime; 
				TextIndicator.GetComponent<Text> ().text = ((int)currentAmount).ToString () + "%"; 
				TextLoading.gameObject.SetActive (true); 

			} else { 
				TextLoading.gameObject.SetActive (false);
				//Wird im Center angezeigt, wenn die Progressbar 100% gefüllt ist: es erscheint: "Prima"
				TextIndicator.GetComponent<Text> ().text = "WORKS"; 
			}
			LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
		}


		//progess task #4:
		if (ScoringSystem.theScore == 4) {
			if (currentAmount < 75) { //(10) Gibt an wie viel Prozent geladen werden, wenn 1 Diamant gesammelt wurde
				//
				currentAmount += speed * Time.deltaTime; 
				TextIndicator.GetComponent<Text> ().text = ((int)currentAmount).ToString () + "%"; 
				TextLoading.gameObject.SetActive (true); 

			} else { 
				TextLoading.gameObject.SetActive (false);
				//Wird im Center angezeigt, wenn die Progressbar 100% gefüllt ist: es erscheint: "Prima"
				TextIndicator.GetComponent<Text> ().text = "WORKS"; 
			}
			LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
		}


		//progess task #5:
		if (ScoringSystem.theScore == 5) {
			if (currentAmount < 100) { //(10) Gibt an wie viel Prozent geladen werden, wenn 1 Diamant gesammelt wurde
				//
				currentAmount += speed * Time.deltaTime; 
				TextIndicator.GetComponent<Text> ().text = ((int)currentAmount).ToString () + "%"; 
				TextLoading.gameObject.SetActive (true); 

			} else { 
				TextLoading.gameObject.SetActive (false);
				//Wird im Center angezeigt, wenn die Progressbar 100% gefüllt ist: es erscheint: "Prima"
				TextIndicator.GetComponent<Text> ().text = "WORKS"; 
			}
			LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
		}


	}//update end
}
