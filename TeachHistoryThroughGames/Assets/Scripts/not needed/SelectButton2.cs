using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class SelectButton2 : MonoBehaviour {

	[SerializeField] private string selecableTagButton1 = "Button1"; //Q1B1
	[SerializeField] private string selecableTagButton2 = "Button2"; //Q1B2
	[SerializeField] private string selecableTagButton3 = "Button3"; //Q2B1
	[SerializeField] private string selecableTagButton4 = "Button4"; //Q2B2
	[SerializeField] private string selecableTagButton5 = "Button5"; //Q3B1
	[SerializeField] private string selecableTagButton6 = "Button6"; //Q3B2


	[SerializeField] private Material highlightMATButton1;
	[SerializeField] private Material highlightMATButton2;
	[SerializeField] private Material highlightMATButton3;
	[SerializeField] private Material highlightMATButton4;
	[SerializeField] private Material highlightMATButton5;
	[SerializeField] private Material highlightMATButton6;


	[SerializeField] private Material defaultMATButton1; //Q1B1
	[SerializeField] private Material defaultMATButton2; //Q1B2
	[SerializeField] private Material defaultMATButton3; //Q2B1
	[SerializeField] private Material defaultMATButton4; //Q2B2
	[SerializeField] private Material defaultMATButton5; //Q3B1
	[SerializeField] private Material defaultMATButton6; //Q3B2

	//Selection
	public static Transform Button1Selection; //Q1B1
	public static Transform Button2Selection; //Q1B2
	public static Transform Button3Selection; //Q2B1
	public static Transform Button4Selection; //Q2B2
	public static Transform Button5Selection; //Q3B1
	public static Transform Button6Selection; //Q3B2


	public float force = 5;


	//Set active or deactivate
	public GameObject Question2;
	public GameObject ButtonQuest3;
	public GameObject ButtonQuest4;


	public GameObject Question3;
	public GameObject ButtonQuest5;
	public GameObject ButtonQuest6;



	private void Update ()
	{
		//Beginn Button1 (Quest1 Button1)
		if (Button1Selection != null) 
		{
			var selectionRenderer = Button1Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATButton1;
			Button1Selection = null;
		}

		var ray1 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit1;

		if (Physics.Raycast (ray1, out hit1, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit1.transform;
			if (selection.CompareTag (selecableTagButton1)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMATButton1;
					//OnGUI ();	//shows for this answer doorkeycode = [x]
					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(Buttonaction12());
					}
				}

				Button1Selection = selection;
			}
		}



		//beginn button 2 (Quest1 Button2)
		if (Button2Selection != null) 
		{
			var selectionRenderer = Button2Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATButton2;
			Button2Selection = null;
		}

		var ray2 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit2;

		if (Physics.Raycast (ray2, out hit2, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit2.transform;
			if (selection.CompareTag (selecableTagButton2)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMATButton2;
					//OnGUI ();
					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(Buttonaction12());
					}
				}

				Button2Selection = selection;
			}
		}//end button2


		//beginn button 3 (Quest2 Button1)
		if (Button3Selection != null) 
		{
			var selectionRenderer = Button3Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATButton3;
			Button3Selection = null;
		}

		var ray3 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit3;

		if (Physics.Raycast (ray3, out hit3, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit3.transform;
			if (selection.CompareTag (selecableTagButton3)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMATButton3;
					//OnGUI ();
					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(Buttonaction34());
					}
				}

				Button3Selection = selection;
			}
		}//end button3



		//beginn button 4 (Quest2 Button2)
		if (Button4Selection != null) 
		{
			var selectionRenderer = Button4Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATButton4;
			Button4Selection = null;
		}

		var ray4 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit4;

		if (Physics.Raycast (ray4, out hit4, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit4.transform;
			if (selection.CompareTag (selecableTagButton4)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMATButton4;
					//OnGUI ();
					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(Buttonaction34());
					}
				}

				Button4Selection = selection;
			}
		}//end button4



		//beginn button 5 (Quest3 Button1)
		if (Button5Selection != null) 
		{
			var selectionRenderer = Button5Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATButton5;
			Button5Selection = null;
		}

		var ray5 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit5;

		if (Physics.Raycast (ray5, out hit5, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit5.transform;
			if (selection.CompareTag (selecableTagButton5)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMATButton5;
					//OnGUI ();
				}

				Button5Selection = selection;
			}
		}//end button5
	


		//beginn button 6 (Quest3 Button1)
		if (Button6Selection != null) 
		{
			var selectionRenderer = Button6Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATButton6;
			Button6Selection = null;
		}

		var ray6 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit6;

		if (Physics.Raycast (ray6, out hit6, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit6.transform;
			if (selection.CompareTag (selecableTagButton6)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMATButton6;
					//OnGUI ();
				}

				Button6Selection = selection;
			}
		}//end button6





	}//end update

	public GameObject Question1;
	public GameObject ButtonQuest1;
	public GameObject ButtonQuest2;

	//Zeigt Frage 1 und Anwortbutton bei Kollision mit Fragezeichen
	public void OnTriggerEnter (Collider other)
	{
	//Quest1
		Question1.SetActive (true);
		ButtonQuest1.SetActive (true);
		ButtonQuest2.SetActive (true);

	}

	//Deaktiviert alles, wenn man nicht mehr im Triggerbereich(Fragezeichen) steht
	public void OnTriggerExit (Collider other)
	{

		//deactivation Quest1
		Question1.SetActive (false);
		ButtonQuest1.SetActive (false);
		ButtonQuest2.SetActive (false);

		//deactivation Quest2
		Question2.SetActive (false);
		ButtonQuest3.SetActive (false);
		ButtonQuest4.SetActive (false);

		//deactivation Quest3
		Question3.SetActive (false);
		ButtonQuest5.SetActive (false);
		ButtonQuest6.SetActive (false);

	}

	IEnumerator Buttonaction12()
	{
		yield return new WaitForSeconds(0.5f);
		Question2.SetActive (true);
		ButtonQuest3.SetActive (true);
		ButtonQuest4.SetActive (true);
		//deactivate
		Question1.SetActive (false);
		ButtonQuest1.SetActive (false);
		ButtonQuest2.SetActive (false);
	}


	IEnumerator Buttonaction34()
	{
		yield return new WaitForSeconds(0.5f);
		Question3.SetActive (true);
		ButtonQuest5.SetActive (true);
		ButtonQuest6.SetActive (true);
		//deactivate if pressed
		Question1.SetActive (false);
		ButtonQuest1.SetActive (false);
		ButtonQuest2.SetActive (false);
		//deactivate routine 1
		Question2.SetActive (false);
		ButtonQuest3.SetActive (false);
		ButtonQuest4.SetActive (false);
	}

	//show Code from pressed Antwort
//	public void OnGUI()
//	{
//		if (Button1Selection == true) {
//			GUI.Box (new Rect (230, 30, 150, 20), "Door-key-code[1] for this answer");
//		}
//
//
//		if (Button2Selection == true) {
//			GUI.Box (new Rect (230, 30, 150, 20), "Door-key-code[5] for this answer");
//		}
//
//
//		if (Button3Selection == true) {
//			GUI.Box (new Rect (230, 30, 150, 20), "Door-key-code[2] for this answer");
//		}
//
//
//		if (Button4Selection == true) {
//			GUI.Box (new Rect (230, 30, 150, 20), "Door-key-code[6] for this answer");
//		}
//
//
//		if (Button4Selection == true) {
//			GUI.Box (new Rect (230, 30, 150, 20), "Door-key-code[3] for this answer");
//		}
//
//
//		if (Button5Selection == true) {
//			GUI.Box (new Rect (230, 30, 150, 20), "Door-key-code[7] for this answer");
//		}
//
//
//		if (Button6Selection == true) {
//			GUI.Box (new Rect (230, 30, 150, 20), "Door-key-code[4] for this answer");
//		}
//		
//	}
		
}