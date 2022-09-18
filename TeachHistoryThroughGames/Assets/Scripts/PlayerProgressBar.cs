using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerProgressBar : MonoBehaviour 
{

	public Transform LoadingBar;
	public Transform TextIndicator;
	public Transform TextLoading;
	[SerializeField] private float currentAmount;
	[SerializeField] private float speed;




	// Update is called once per frame
	void Update () 
	{
		if (currentAmount < 100) { 
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
}
