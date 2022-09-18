using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArthurProgressBar : MonoBehaviour 
{

	public Transform ALoadingBar;
	public Transform ATextIndicator;
	public Transform ATextLoading;
	[SerializeField] private float AcurrentAmount;
	[SerializeField] private float Aspeed;




	// Update is called once per frame
	void Update () 
	{
		if (AcurrentAmount < 100) { 
			AcurrentAmount += Aspeed * Time.deltaTime; 
			ATextIndicator.GetComponent<Text> ().text = ((int)AcurrentAmount).ToString () + "%"; 
			ATextLoading.gameObject.SetActive (true); 
		} else { 
			ATextLoading.gameObject.SetActive (false);
			//Wird im Center angezeigt, wenn die Progressbar 100% gefüllt ist: es erscheint: "Prima"
			ATextIndicator.GetComponent<Text> ().text = "Arthur hat gewonne"; 
		}
		ALoadingBar.GetComponent<Image>().fillAmount = AcurrentAmount / 100;


	}
}
