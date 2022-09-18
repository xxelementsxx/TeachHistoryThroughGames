using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//Generalisierbarkeit: Bei erstellung eines weiteren Quizes muss ausschließlich Q1 und S1, um 1 erhöht werden
// Quiz zugehörig der Storyline 1
//Insg. enthält ein Quiz min. 3 Fragestellungen mit jeweils 3 Antwortmöglichkeiten
public class Q2S5 : MonoBehaviour {

	//(1) Zuweisungen wie Tags, Materialien, Game Objects
	//(1.1) Zuweisungstag: Wenn Raycast hits Ausgangsmaterial, dann tausche das MAT mit dem zu zuweisendem HIghlightsmaterial
	// Wird über Tags geregelt, welches GameObject, welches Material erhält


	//Ausgangsmaterial der Q2S5F1-Q2S5F4 (jeweils A1;A2;A3)
	[SerializeField] private Material defaultMATQ2S5F1A1;
	[SerializeField] private Material defaultMATQ2S5F1A2;
	[SerializeField] private Material defaultMATQ2S5F1A3;

	[SerializeField] private Material defaultMATQ2S5F2A1;//
	[SerializeField] private Material defaultMATQ2S5F2A2;
	[SerializeField] private Material defaultMATQ2S5F2A3;

	[SerializeField] private Material defaultMATQ2S5F3A1;
	[SerializeField] private Material defaultMATQ2S5F3A2;
	[SerializeField] private Material defaultMATQ2S5F3A3;

	[SerializeField] private Material defaultMATQ2S5F4A1;
	[SerializeField] private Material defaultMATQ2S5F4A2;
	[SerializeField] private Material defaultMATQ2S5F4A3;

	//more Question than Q1S1
	[SerializeField] private Material defaultMATQ2S5F5A1;
	[SerializeField] private Material defaultMATQ2S5F5A2;
	[SerializeField] private Material defaultMATQ2S5F5A3;

	[SerializeField] private Material defaultMATQ2S5F6A1;//
	[SerializeField] private Material defaultMATQ2S5F6A2;
	[SerializeField] private Material defaultMATQ2S5F6A3;

	[SerializeField] private Material defaultMATQ2S5F7A1;
	[SerializeField] private Material defaultMATQ2S5F7A2;
	[SerializeField] private Material defaultMATQ2S5F7A3;

	[SerializeField] private Material defaultMATQ2S5F8A1;
	[SerializeField] private Material defaultMATQ2S5F8A2;
	[SerializeField] private Material defaultMATQ2S5F8A3;

	//Selektionsmaterial der Q2S5F1-Q2S5F4 (jeweils A1;A2;A3)
	[SerializeField] private Material highMATQ2S5F1A1; // (optional) -> be transparent
	 //showFeedback: GO_hält FeedbackMAT
	[SerializeField] private Material highMATQ2S5F1A2;
	[SerializeField] private Material highMATQ2S5F1A3;

	[SerializeField] private Material highMATQ2S5F2A1;//
	[SerializeField] private Material highMATQ2S5F2A2;
	[SerializeField] private Material highMATQ2S5F2A3;

	[SerializeField] private Material highMATQ2S5F3A1;
	[SerializeField] private Material highMATQ2S5F3A2;
	[SerializeField] private Material highMATQ2S5F3A3;

	[SerializeField] private Material highMATQ2S5F4A1;
	[SerializeField] private Material highMATQ2S5F4A2;
	[SerializeField] private Material highMATQ2S5F4A3;

	//more Question than Q1S1
	[SerializeField] private Material highMATQ2S5F5A1;
	[SerializeField] private Material highMATQ2S5F5A2;
	[SerializeField] private Material highMATQ2S5F5A3;

	[SerializeField] private Material highMATQ2S5F6A1;//
	[SerializeField] private Material highMATQ2S5F6A2;
	[SerializeField] private Material highMATQ2S5F6A3;

	[SerializeField] private Material highMATQ2S5F7A1;
	[SerializeField] private Material highMATQ2S5F7A2;
	[SerializeField] private Material highMATQ2S5F7A3;

	[SerializeField] private Material highMATQ2S5F8A1;
	[SerializeField] private Material highMATQ2S5F8A2;
	[SerializeField] private Material highMATQ2S5F8A3;


	[SerializeField] private GameObject GOFeedbackMATQ2S5F1A1;
	[SerializeField] private GameObject GOFeedbackMATQ2S5F1A2;
	[SerializeField] private GameObject GOFeedbackMATQ2S5F1A3;

	[SerializeField] private GameObject GOFeedbackMATQ2S5F2A1;
	[SerializeField] private GameObject GOFeedbackMATQ2S5F2A2;
	[SerializeField] private GameObject GOFeedbackMATQ2S5F2A3;

	[SerializeField] private GameObject GOFeedbackMATQ2S5F3A1;
	[SerializeField] private GameObject GOFeedbackMATQ2S5F3A2;
	[SerializeField] private GameObject GOFeedbackMATQ2S5F3A3;

	[SerializeField] private GameObject GOFeedbackMATQ2S5F4A1;
	[SerializeField] private GameObject GOFeedbackMATQ2S5F4A2;
	[SerializeField] private GameObject GOFeedbackMATQ2S5F4A3;

	[SerializeField] private GameObject GOFeedbackMATQ2S5F5A1;
	[SerializeField] private GameObject GOFeedbackMATQ2S5F5A2;
	[SerializeField] private GameObject GOFeedbackMATQ2S5F5A3;

	[SerializeField] private GameObject GOFeedbackMATQ2S5F6A1;
	[SerializeField] private GameObject GOFeedbackMATQ2S5F6A2;
	[SerializeField] private GameObject GOFeedbackMATQ2S5F6A3;

	[SerializeField] private GameObject GOFeedbackMATQ2S5F7A1;
	[SerializeField] private GameObject GOFeedbackMATQ2S5F7A2;
	[SerializeField] private GameObject GOFeedbackMATQ2S5F7A3;

	[SerializeField] private GameObject GOFeedbackMATQ2S5F8A1;
	[SerializeField] private GameObject GOFeedbackMATQ2S5F8A2;
	[SerializeField] private GameObject GOFeedbackMATQ2S5F8A3;

	//Selektion der Antwortmöglichkeiten des Quizes über Tag-Erkennung
	//Tag-Erkennung für Q2S5F1
	[SerializeField] private string SelectionQ2S5F1A1 = "Q2S5F1A1";
	[SerializeField] private string SelectionQ2S5F1A2 = "Q2S5F1A2";
	[SerializeField] private string SelectionQ2S5F1A3 = "Q2S5F1A3";


	//Tag-Erkennung für Q2S5F2
	[SerializeField] private string SelectionQ2S5F2A1 = "Q2S5F2A1";
	[SerializeField] private string SelectionQ2S5F2A2 = "Q2S5F2A2";
	[SerializeField] private string SelectionQ2S5F2A3 = "Q2S5F2A3";


	//Tag-Erkennung für Q2S5F3
	[SerializeField] private string SelectionQ2S5F3A1 = "Q2S5F3A1";
	[SerializeField] private string SelectionQ2S5F3A2 = "Q2S5F3A2";
	[SerializeField] private string SelectionQ2S5F3A3 = "Q2S5F3A3";


	//Tag-Erkennung für Q2S5F4
	[SerializeField] private string SelectionQ2S5F4A1 = "Q2S5F4A1";
	[SerializeField] private string SelectionQ2S5F4A2 = "Q2S5F4A2";
	[SerializeField] private string SelectionQ2S5F4A3 = "Q2S5F4A3";

	//Tag-Erkennung für Q2S5F5
	[SerializeField] private string SelectionQ2S5F5A1 = "Q2S5F5A1";
	[SerializeField] private string SelectionQ2S5F5A2 = "Q2S5F5A2";
	[SerializeField] private string SelectionQ2S5F5A3 = "Q2S5F5A3";

	//Tag-Erkennung für Q2S5F6
	[SerializeField] private string SelectionQ2S5F6A1 = "Q2S5F6A1";
	[SerializeField] private string SelectionQ2S5F6A2 = "Q2S5F6A2";
	[SerializeField] private string SelectionQ2S5F6A3 = "Q2S5F6A3";

	//Tag-Erkennung für Q2S5F7
	[SerializeField] private string SelectionQ2S5F7A1 = "Q2S5F7A1";
	[SerializeField] private string SelectionQ2S5F7A2 = "Q2S5F7A2";
	[SerializeField] private string SelectionQ2S5F7A3 = "Q2S5F7A3";

	//Tag-Erkennung für Q2S5F8
	[SerializeField] private string SelectionQ2S5F8A1 = "Q2S5F8A1";
	[SerializeField] private string SelectionQ2S5F8A2 = "Q2S5F8A2";
	[SerializeField] private string SelectionQ2S5F8A3 = "Q2S5F8A3";

	//Zur Funktionsrealisierung des Materialwechsels durch den Renderer
	public static Transform Q2S5F1A1; //Quiz1, Storypart1, Frage1: Antwortmöglichkeit 1
	public static Transform Q2S5F1A2;
	public static Transform Q2S5F1A3;

	public static Transform Q2S5F2A1;
	public static Transform Q2S5F2A2;
	public static Transform Q2S5F2A3;

	public static Transform Q2S5F3A1;
	public static Transform Q2S5F3A2;
	public static Transform Q2S5F3A3;

	public static Transform Q2S5F4A1;
	public static Transform Q2S5F4A2;
	public static Transform Q2S5F4A3;

	//
	public static Transform Q2S5F5A1; //Quiz1, Storypart1, Frage1: Antwortmöglichkeit 1
	public static Transform Q2S5F5A2;
	public static Transform Q2S5F5A3;

	public static Transform Q2S5F6A1;
	public static Transform Q2S5F6A2;
	public static Transform Q2S5F6A3;

	public static Transform Q2S5F7A1;
	public static Transform Q2S5F7A2;
	public static Transform Q2S5F7A3;

	public static Transform Q2S5F8A1;
	public static Transform Q2S5F8A2;
	public static Transform Q2S5F8A3;
	//Geschwindigkeit des Raycasts
	public float force = 5;

	//Zur Aktivierung bzw. Deaktivierung der GameObjekte als Fragehalter
	public GameObject Q2S5F1;
	public GameObject Q2S5F2;
	public GameObject Q2S5F3;
	public GameObject Q2S5F4;

	//Erweiterung
	public GameObject Q2S5F5;
	public GameObject Q2S5F6;
	public GameObject Q2S5F7;
	public GameObject Q2S5F8;

	//Zur Aktivierung oder Deaktivierung von Antwortmöglichkeiten als GameObejkt
	public GameObject MeshQ2S5F1A1;
	public GameObject MeshQ2S5F1A2;
	public GameObject MeshQ2S5F1A3;

	public GameObject MeshQ2S5F2A1;
	public GameObject MeshQ2S5F2A2;
	public GameObject MeshQ2S5F2A3;

	public GameObject MeshQ2S5F3A1;
	public GameObject MeshQ2S5F3A2;
	public GameObject MeshQ2S5F3A3;

	public GameObject MeshQ2S5F4A1;
	public GameObject MeshQ2S5F4A2;
	public GameObject MeshQ2S5F4A3;

	//
	public GameObject MeshQ2S5F5A1;
	public GameObject MeshQ2S5F5A2;
	public GameObject MeshQ2S5F5A3;

	public GameObject MeshQ2S5F6A1;
	public GameObject MeshQ2S5F6A2;
	public GameObject MeshQ2S5F6A3;

	public GameObject MeshQ2S5F7A1;
	public GameObject MeshQ2S5F7A2;
	public GameObject MeshQ2S5F7A3;

	public GameObject MeshQ2S5F8A1;
	public GameObject MeshQ2S5F8A2;
	public GameObject MeshQ2S5F8A3;

	//Zur Aktivierung oder Deaktivierung von Handlungsanweisung als GameObject (dient als Wegleiter zur Teilaufgabe2)
	public GameObject MeshHandlungsanweisungQ2S5;

	//Zeige Quiz (Frage 1 und 3 Antwortmöglichkeiten der Frage 1), wenn der Spielende, mit dem Fragezeichen-Mesh kollidiert bzw. es berührt
	//using set.Active (true) oder (false);
	public void OnTriggerEnter (Collider other)
	{
		//Frage-Antowrtblock 1
		Q2S5F1.SetActive (true);
		MeshQ2S5F1A1.SetActive (true);
		MeshQ2S5F1A2.SetActive (true);
		MeshQ2S5F1A3.SetActive (true);
	}


	//Deaktivate, wenn Player nicht mehr im Triggerbereich (wenn er nicht mehr mit Fragezeichenmesh kollidiert)
	public void OnTriggerExit (Collider other)
	{
		//Jedes GameObject und jedes Prefab, dass im Quiz existiert -> deaktiviere das letzte Object was momentan aktive ist
		MeshHandlungsanweisungQ2S5.SetActive (false);
		Q2S5F1.SetActive (false);
		MeshQ2S5F1A1.SetActive (false);
		MeshQ2S5F1A2.SetActive (false);
		MeshQ2S5F1A3.SetActive (false);

		Q2S5F2.SetActive (false);
		MeshQ2S5F2A1.SetActive (false);
		MeshQ2S5F2A2.SetActive (false);
		MeshQ2S5F2A3.SetActive (false);

		Q2S5F3.SetActive (false);
		MeshQ2S5F3A1.SetActive (false);
		MeshQ2S5F3A2.SetActive (false);
		MeshQ2S5F3A3.SetActive (false);


		Q2S5F4.SetActive (false);
		MeshQ2S5F4A1.SetActive (false);
		MeshQ2S5F4A2.SetActive (false);
		MeshQ2S5F4A3.SetActive (false);

		Q2S5F5.SetActive (false);
		MeshQ2S5F5A1.SetActive (false);
		MeshQ2S5F5A2.SetActive (false);
		MeshQ2S5F5A3.SetActive (false);

		Q2S5F6.SetActive (false);
		MeshQ2S5F6A1.SetActive (false);
		MeshQ2S5F6A2.SetActive (false);
		MeshQ2S5F6A3.SetActive (false);

		Q2S5F7.SetActive (false);
		MeshQ2S5F7A1.SetActive (false);
		MeshQ2S5F7A2.SetActive (false);
		MeshQ2S5F7A3.SetActive (false);

		Q2S5F8.SetActive (false);
		MeshQ2S5F8A1.SetActive (false);
		MeshQ2S5F8A2.SetActive (false);
		MeshQ2S5F8A3.SetActive (false);
	}
		

	// Update is called once per frame
	void Update () 
	{
		//Wenn Raycast hits eins der Objekt (jeweils die Antwortmöglichkeiten der vers. Fragen), dann tausche das Material und löse nach betätigen der Aktionstaste auf dem Kontroller eine Funktion aus
		// ... für Q2S5F1A1
		if (Q2S5F1A1 != null) //start Q2S5F1A1
		{
			var selectionRenderer = Q2S5F1A1.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F1A1;
			Q2S5F1A1 = null;
		}

		var rayQ2S5F1A1 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F1A1;

		if (Physics.Raycast (rayQ2S5F1A1, out hitQ2S5F1A1, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F1A1.transform;
			if (selection.CompareTag (SelectionQ2S5F1A1)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F1A1;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F1A1A2A3());
						StartCoroutine (FeedbackQ2S5F1A1 ());
					}
				}

				Q2S5F1A1 = selection;
			}
		} //Ende Q2S5F1A1

		//-----

		if (Q2S5F1A2 != null) //start Q2S5F1A2
		{
			var selectionRenderer = Q2S5F1A2.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F1A2;
			Q2S5F1A2 = null;
		}

		var rayQ2S5F1A2 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F1A2;

		if (Physics.Raycast (rayQ2S5F1A2, out hitQ2S5F1A2, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F1A2.transform;
			if (selection.CompareTag (SelectionQ2S5F1A2)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F1A2;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F1A1A2A3());
						StartCoroutine (FeedbackQ2S5F1A2 ());
					}
				}

				Q2S5F1A2 = selection;
			}
		} //Ende Q2S5F1A2

		//-----

		if (Q2S5F1A3 != null) //start Q2S5F1A3
		{
			var selectionRenderer = Q2S5F1A3.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F1A3;
			Q2S5F1A3 = null;
		}

		var rayQ2S5F1A3 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F1A3;

		if (Physics.Raycast (rayQ2S5F1A3, out hitQ2S5F1A3, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F1A3.transform;
			if (selection.CompareTag (SelectionQ2S5F1A3)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F1A3;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F1A1A2A3());
						StartCoroutine (FeedbackQ2S5F1A3 ());
					}
				}

				Q2S5F1A3 = selection;
			}
		} //Ende Q2S5F1A3


		//-----
		if (Q2S5F2A1 != null) //start Q2S5F2A1
		{
			var selectionRenderer = Q2S5F2A1.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F2A1;
			Q2S5F2A1 = null;
		}

		var rayQ2S5F2A1 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F2A1;

		if (Physics.Raycast (rayQ2S5F2A1, out hitQ2S5F2A1, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F2A1.transform;
			if (selection.CompareTag (SelectionQ2S5F2A1)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F2A1;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F2A1A2A3());
						StartCoroutine(FeedbackQ2S5F2A1 ());
					}
				}

				Q2S5F2A1 = selection;
			}
		} //Ende Q2S5F2A1


		//-----
		if (Q2S5F2A2 != null) //start Q2S5F2A2
		{
			var selectionRenderer = Q2S5F2A2.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F2A2;
			Q2S5F2A2 = null;
		}

		var rayQ2S5F2A2 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F2A2;

		if (Physics.Raycast (rayQ2S5F2A2, out hitQ2S5F2A2, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F2A2.transform;
			if (selection.CompareTag (SelectionQ2S5F2A2)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F2A2;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F2A1A2A3());
						StartCoroutine(FeedbackQ2S5F2A2 ());
					}
				}

				Q2S5F2A2 = selection;
			}
		} //Ende Q2S5F2A2


		//-----
		if (Q2S5F2A3 != null) //start Q2S5F2A3
		{
			var selectionRenderer = Q2S5F2A3.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F2A3;
			Q2S5F2A3 = null;
		}

		var rayQ2S5F2A3 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F2A3;

		if (Physics.Raycast (rayQ2S5F2A3, out hitQ2S5F2A3, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F2A3.transform;
			if (selection.CompareTag (SelectionQ2S5F2A3)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F2A3;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F2A1A2A3());
						StartCoroutine(FeedbackQ2S5F2A3 ());
					}
				}

				Q2S5F2A3 = selection;
			}
		} //Ende Q2S5F2A3


		//-----
		if (Q2S5F3A1 != null) //start Q2S5F3A1
		{
			var selectionRenderer = Q2S5F3A1.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F3A1;
			Q2S5F3A1 = null;
		}

		var rayQ2S5F3A1 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F3A1;

		if (Physics.Raycast (rayQ2S5F3A1, out hitQ2S5F3A1, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F3A1.transform;
			if (selection.CompareTag (SelectionQ2S5F3A1)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F3A1;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F3A1A2A3());
						StartCoroutine(FeedbackQ2S5F3A1 ());
					}
				}

				Q2S5F3A1 = selection;
			}
		} //Ende Q2S5F3A1


		//-----
		if (Q2S5F3A2 != null) //start Q2S5F3A2
		{
			var selectionRenderer = Q2S5F3A2.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F3A2;
			Q2S5F3A2 = null;
		}

		var rayQ2S5F3A2 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F3A2;

		if (Physics.Raycast (rayQ2S5F3A2, out hitQ2S5F3A2, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F3A2.transform;
			if (selection.CompareTag (SelectionQ2S5F3A2)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F3A2;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F3A1A2A3());
						StartCoroutine(FeedbackQ2S5F3A2 ());
					}
				}

				Q2S5F3A2 = selection;
			}
		} //Ende Q2S5F3A2


		//-----
		if (Q2S5F3A3 != null) //start Q2S5F3A3
		{
			var selectionRenderer = Q2S5F3A3.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F3A3;
			Q2S5F3A3 = null;
		}

		var rayQ2S5F3A3 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F3A3;

		if (Physics.Raycast (rayQ2S5F3A3, out hitQ2S5F3A3, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F3A3.transform;
			if (selection.CompareTag (SelectionQ2S5F3A3)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F3A3;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F3A1A2A3());
						StartCoroutine(FeedbackQ2S5F3A3 ());
					}
				}

				Q2S5F3A3 = selection;
			}
		} //Ende Q2S5F3A3


		//-----End Quiz-----
		if (Q2S5F4A1 != null) //start Q2S5F4A1
		{
			var selectionRenderer = Q2S5F4A1.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F4A1;
			Q2S5F4A1 = null;
		}

		var rayQ2S5F4A1 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F4A1;

		if (Physics.Raycast (rayQ2S5F4A1, out hitQ2S5F4A1, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F4A1.transform;
			if (selection.CompareTag (SelectionQ2S5F4A1)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F4A1;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F4A1A2A3());
						StartCoroutine(FeedbackQ2S5F4A1 ());
					}
				}

				Q2S5F4A1 = selection;
			}
		} //Ende Q2S5F4A1


		//-----End Quiz-----
		if (Q2S5F4A2 != null) //start Q2S5F4A2
		{
			var selectionRenderer = Q2S5F4A2.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F4A2;
			Q2S5F4A2 = null;
		}

		var rayQ2S5F4A2 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F4A2;

		if (Physics.Raycast (rayQ2S5F4A2, out hitQ2S5F4A2, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F4A2.transform;
			if (selection.CompareTag (SelectionQ2S5F4A2)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F4A2;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F4A1A2A3());
						StartCoroutine(FeedbackQ2S5F4A2 ());
					}
				}

				Q2S5F4A2 = selection;
			}
		} //Ende Q2S5F4A2


		//-----Matrix Antworten für neue Antworten des Quiz-----
		if (Q2S5F4A3 != null) //start Q2S5F4A3
		{
			var selectionRenderer = Q2S5F4A3.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F4A3;
			Q2S5F4A3 = null;
		}

		var rayQ2S5F4A3 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F4A3;

		if (Physics.Raycast (rayQ2S5F4A3, out hitQ2S5F4A3, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F4A3.transform;
			if (selection.CompareTag (SelectionQ2S5F4A3)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F4A3;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F4A1A2A3());
						StartCoroutine(FeedbackQ2S5F4A3 ());
					}
				}

				Q2S5F4A3 = selection;
			}
		} //Ende Q2S5F4A3


		//----------------Erweiterung------------------
		if (Q2S5F5A1 != null) //start Q2S5F5A1
		{
			var selectionRenderer = Q2S5F5A1.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F5A1;
			Q2S5F5A1 = null;
		}

		var rayQ2S5F5A1 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F5A1;

		if (Physics.Raycast (rayQ2S5F5A1, out hitQ2S5F5A1, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F5A1.transform;
			if (selection.CompareTag (SelectionQ2S5F5A1)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F5A1;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F5A1A2A3());
						StartCoroutine(FeedbackQ2S5F5A1 ());
					}
				}

				Q2S5F5A1 = selection;
			}
		} //Ende Q2S5F5A1


		//----------------Erweiterung------------------
		if (Q2S5F5A2 != null) //start Q2S5F5A2
		{
			var selectionRenderer = Q2S5F5A2.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F5A2;
			Q2S5F5A2 = null;
		}

		var rayQ2S5F5A2 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F5A2;

		if (Physics.Raycast (rayQ2S5F5A2, out hitQ2S5F5A2, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F5A2.transform;
			if (selection.CompareTag (SelectionQ2S5F5A2)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F5A2;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F5A1A2A3());
						StartCoroutine(FeedbackQ2S5F5A2 ());
					}
				}

				Q2S5F5A2 = selection;
			}
		} //Ende Q2S5F5A2


		//----------------Erweiterung------------------
		if (Q2S5F5A3 != null) //start Q2S5F5A3
		{
			var selectionRenderer = Q2S5F5A3.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F5A3;
			Q2S5F5A3 = null;
		}

		var rayQ2S5F5A3 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F5A3;

		if (Physics.Raycast (rayQ2S5F5A3, out hitQ2S5F5A3, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F5A3.transform;
			if (selection.CompareTag (SelectionQ2S5F5A3)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F5A3;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F5A1A2A3());
						StartCoroutine(FeedbackQ2S5F5A3 ());
					}
				}

				Q2S5F5A3 = selection;
			}
		} //Ende Q2S5F5A3


		//----------------Erweiterung------------------
		if (Q2S5F6A1 != null) //start Q2S5F6A1
		{
			var selectionRenderer = Q2S5F6A1.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F6A1;
			Q2S5F6A1 = null;
		}

		var rayQ2S5F6A1 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F6A1;

		if (Physics.Raycast (rayQ2S5F6A1, out hitQ2S5F6A1, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F6A1.transform;
			if (selection.CompareTag (SelectionQ2S5F6A1)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F6A1;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F6A1A2A3());
						StartCoroutine(FeedbackQ2S5F6A1 ());
					}
				}

				Q2S5F6A1 = selection;
			}
		} //Ende Q2S5F6A1
		//--------------------------------


		//----------------Erweiterung------------------
		if (Q2S5F6A2 != null) //start Q2S5F6A2
		{
			var selectionRenderer = Q2S5F6A2.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F6A2;
			Q2S5F6A2 = null;
		}

		var rayQ2S5F6A2 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F6A2;

		if (Physics.Raycast (rayQ2S5F6A2, out hitQ2S5F6A2, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F6A2.transform;
			if (selection.CompareTag (SelectionQ2S5F6A2)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F6A2;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F6A1A2A3());
						StartCoroutine(FeedbackQ2S5F6A2 ());
					}
				}

				Q2S5F6A2 = selection;
			}
		} //Ende Q2S5F6A2
		//--------------------------------


		//----------------Erweiterung------------------
		if (Q2S5F6A3 != null) //start Q2S5F6A3
		{
			var selectionRenderer = Q2S5F6A3.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F6A3;
			Q2S5F6A3 = null;
		}

		var rayQ2S5F6A3 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F6A3;

		if (Physics.Raycast (rayQ2S5F6A3, out hitQ2S5F6A3, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F6A3.transform;
			if (selection.CompareTag (SelectionQ2S5F6A3)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F6A3;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F6A1A2A3());
						StartCoroutine(FeedbackQ2S5F6A3 ());
					}
				}

				Q2S5F6A3 = selection;
			}
		} //Ende Q2S5F6A3
		//--------------------------------


		//----------------Erweiterung------------------
		if (Q2S5F7A1 != null) //start Q2S5F7A1
		{
			var selectionRenderer = Q2S5F7A1.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F7A1;
			Q2S5F7A1 = null;
		}

		var rayQ2S5F7A1 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F7A1;

		if (Physics.Raycast (rayQ2S5F7A1, out hitQ2S5F7A1, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F7A1.transform;
			if (selection.CompareTag (SelectionQ2S5F7A1)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F7A1;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F7A1A2A3());
						StartCoroutine(FeedbackQ2S5F7A1 ());
					}
				}

				Q2S5F7A1 = selection;
			}
		} //Ende Q2S5F7A1
		//--------------------------------


		//----------------Erweiterung------------------
		if (Q2S5F7A2 != null) //start Q2S5F7A2
		{
			var selectionRenderer = Q2S5F7A2.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F7A2;
			Q2S5F7A2 = null;
		}

		var rayQ2S5F7A2 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F7A2;

		if (Physics.Raycast (rayQ2S5F7A2, out hitQ2S5F7A2, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F7A2.transform;
			if (selection.CompareTag (SelectionQ2S5F7A2)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F7A2;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F7A1A2A3());
						StartCoroutine(FeedbackQ2S5F7A2 ());
					}
				}

				Q2S5F7A2 = selection;
			}
		} //Ende Q2S5F7A2
		//--------------------------------


		//----------------Erweiterung------------------
		if (Q2S5F7A3 != null) //start Q2S5F7A3
		{
			var selectionRenderer = Q2S5F7A3.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F7A3;
			Q2S5F7A3 = null;
		}

		var rayQ2S5F7A3 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F7A3;

		if (Physics.Raycast (rayQ2S5F7A3, out hitQ2S5F7A3, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F7A3.transform;
			if (selection.CompareTag (SelectionQ2S5F7A3)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F7A3;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5F7A1A2A3());
						StartCoroutine(FeedbackQ2S5F7A3 ());
					}
				}

				Q2S5F7A3 = selection;
			}
		} //Ende Q2S5F7A3
		//--------------------------------


		//----------------Erweiterung------------------
		if (Q2S5F8A1 != null) //start Q2S5F8A1
		{
			var selectionRenderer = Q2S5F8A1.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F8A1;
			Q2S5F8A1 = null;
		}

		var rayQ2S5F8A1 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F8A1;

		if (Physics.Raycast (rayQ2S5F8A1, out hitQ2S5F8A1, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F8A1.transform;
			if (selection.CompareTag (SelectionQ2S5F8A1)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F8A1;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5MeshHandlungsanweisung());//Handlungsanweisung korrekt an dieser Stelle
						StartCoroutine(FeedbackQ2S5F8A1 ());
					}
				}

				Q2S5F8A1 = selection;
			}
		} //Ende Q2S5F8A1
		//--------------------------------


		//----------------Erweiterung------------------
		if (Q2S5F8A2 != null) //start Q2S5F8A2
		{
			var selectionRenderer = Q2S5F8A2.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F8A2;
			Q2S5F8A2 = null;
		}

		var rayQ2S5F8A2 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F8A2;

		if (Physics.Raycast (rayQ2S5F8A2, out hitQ2S5F8A2, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F8A2.transform;
			if (selection.CompareTag (SelectionQ2S5F8A2)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F8A2;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5MeshHandlungsanweisung());
						StartCoroutine(FeedbackQ2S5F8A2 ());
					}
				}

				Q2S5F8A2 = selection;
			}
		} //Ende Q2S5F8A2
		//--------------------------------


		//----------------Erweiterung------------------
		if (Q2S5F8A3 != null) //start Q2S5F8A3
		{
			var selectionRenderer = Q2S5F8A3.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ2S5F8A3;
			Q2S5F8A3 = null;
		}

		var rayQ2S5F8A3 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ2S5F8A3;

		if (Physics.Raycast (rayQ2S5F8A3, out hitQ2S5F8A3, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ2S5F8A3.transform;
			if (selection.CompareTag (SelectionQ2S5F8A3)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ2S5F8A3;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ2S5MeshHandlungsanweisung());
						StartCoroutine(FeedbackQ2S5F8A3 ());
					}
				}

				Q2S5F8A3 = selection;
			}
		} //Ende Q2S5F8A3
		//--------------------------------



	}//Ende Update




	//GOFeedbackMATQ2S5F1A1
	IEnumerator FeedbackQ2S5F1A1 () //F1A1
	{
		yield return new WaitForSeconds(0.4f); //(Zeit wie lange GO bleibt) soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F1A1.SetActive (true);
	}
		
	IEnumerator FeedbackQ2S5F1A2 ()//F1A2
	{
		yield return new WaitForSeconds(0.4f); //soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F1A2.SetActive (true);
	}

	IEnumerator FeedbackQ2S5F1A3 ()//F1A3korrekt
	{
		yield return new WaitForSeconds(0.4f); //soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F1A3.SetActive (true);
		ErhöheWissDiaScoreQ2S5F1A3 (); //Verweis auf die Methode, die Anzahl der Wissensdiamanten zu erhöhen (geht schneller set Active falls, weil die void Methode gleichzeitig ausgeführt wird)
	}

	//If korrekt Antwort dann erhöhe dia score um 1
	void ErhöheWissDiaScoreQ2S5F1A3 () //Erhöht die Anzahl der Wissensdiamanten in Abhängigkeit zur aktuellen Anzahl von Wissensdiamanten
	{
		if (ScoringSystem.theScore == 5) { //Wenn 5 der aktuelle Wissensdiamantenstand bei 5 liegt, dann erhöhe diesen um einen
			ScoringSystem.theScore++;
			//nach F1A1A2A3
			RoutineQ2S5F1A1A2A3 ();//Verweist auf die zu startende Iteration RoutineQ2S5F1A1A2A3 ab Zeile: 1340
		}
	}

	//_________
	IEnumerator FeedbackQ2S5F2A1 ()//F2A1
	{
		yield return new WaitForSeconds(0.4f); //(Zeit wie lange GO bleibt) soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F2A1.SetActive (true);
	}

	IEnumerator FeedbackQ2S5F2A2 ()//F2A1korrekt
	{
		yield return new WaitForSeconds(0.4f); //soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F2A2.SetActive (true);
		ErhöheWissDiaScoreQ2S5F2A2 ();
	}

	void ErhöheWissDiaScoreQ2S5F2A2 () //Erhöht die Anzahl der Wissensdiamanten in Abhängigkeit zur aktuellen Anzahl von Wissensdiamanten
	{
		if (ScoringSystem.theScore == 6) {
			ScoringSystem.theScore++;
			RoutineQ2S5F2A1A2A3 ();//nach F2A1A2A3
		}
	}

	IEnumerator FeedbackQ2S5F2A3 () //F2A3
	{
		yield return new WaitForSeconds(0.4f); //soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F2A3.SetActive (true);
	}

	IEnumerator FeedbackQ2S5F3A1 ()//F3A1
	{
		yield return new WaitForSeconds(0.4f); //(Zeit wie lange GO bleibt) soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F3A1.SetActive (true);
	}

	IEnumerator FeedbackQ2S5F3A2 ()//F3A2
	{
		yield return new WaitForSeconds(0.4f); //soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F3A2.SetActive (true);
	}

	IEnumerator FeedbackQ2S5F3A3 ()//F3A3
	{
		yield return new WaitForSeconds(0.4f); //soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F3A3.SetActive (true);
	}

	//_________
	IEnumerator FeedbackQ2S5F4A1 ()//F4A1korrekt
	{
		yield return new WaitForSeconds(0.4f); //(Zeit wie lange GO bleibt) soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F4A1.SetActive (true);
		ErhöheWiDiaScoreQ2S5F4A1 ();//nach F4A1A2A3
	}

	//Erhöht die Anzahl der Wissensdiamanten in Abhängigkeit zur aktuellen Anzahl von Wissensdiamanten
	void ErhöheWiDiaScoreQ2S5F4A1 () 
	{
		if (ScoringSystem.theScore == 7) {
			ScoringSystem.theScore++;
			RoutineQ2S5F4A1A2A3 ();//nach F4A1A2A3
		}
	}

	IEnumerator FeedbackQ2S5F4A2 ()//F4A2
	{
		yield return new WaitForSeconds(0.4f); //soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F4A2.SetActive (true);
	}

	IEnumerator FeedbackQ2S5F4A3 ()//F4A3
	{
		yield return new WaitForSeconds(0.4f); //soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F4A3.SetActive (true);
	}

	//_________
	IEnumerator FeedbackQ2S5F5A1 ()//F5A1
	{
		yield return new WaitForSeconds(0.4f); //(Zeit wie lange GO bleibt) soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F5A1.SetActive (true);
	}

	IEnumerator FeedbackQ2S5F5A2 ()//F5A2
	{
		yield return new WaitForSeconds(0.4f); //soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F5A2.SetActive (true);
	}

	IEnumerator FeedbackQ2S5F5A3 ()//F5A3
	{
		yield return new WaitForSeconds(0.4f); //soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F5A3.SetActive (true);
	}

	//_________
	IEnumerator FeedbackQ2S5F6A1 ()//F6A1
	{
		yield return new WaitForSeconds(0.4f); //(Zeit wie lange GO bleibt) soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F6A1.SetActive (true);
	}

	IEnumerator FeedbackQ2S5F6A2 ()//F6A2korrekt
	{
		yield return new WaitForSeconds(0.4f); //soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F6A2.SetActive (true);
		ErhöheWissDiaScoreQ2S5F6A2 ();
	}

	void ErhöheWissDiaScoreQ2S5F6A2 () //Erhöht die Anzahl der Wissensdiamanten in Abhängigkeit zur aktuellen Anzahl von Wissensdiamanten
	{
		if (ScoringSystem.theScore == 7) {
			ScoringSystem.theScore++;
			RoutineQ2S5F6A1A2A3 ();//nach F6A1A2A3
		}
	}

	IEnumerator FeedbackQ2S5F6A3 ()//F6A3
	{
		yield return new WaitForSeconds(0.4f); //soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F6A3.SetActive (true);
	}

	//_________
	IEnumerator FeedbackQ2S5F7A1 ()//F7A1
	{
		yield return new WaitForSeconds(0.4f); //(Zeit wie lange GO bleibt) soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F7A1.SetActive (true);
	}

	IEnumerator FeedbackQ2S5F7A2 ()//F7A2
	{
		yield return new WaitForSeconds(0.4f); //soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F7A2.SetActive (true);
	}

	IEnumerator FeedbackQ2S5F7A3 ()//F7A3
	{
		yield return new WaitForSeconds(0.4f); //soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F7A3.SetActive (true);
	}

	//_________
	IEnumerator FeedbackQ2S5F8A1 ()//F8A1
	{
		yield return new WaitForSeconds(0.4f); //(Zeit wie lange GO bleibt) soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F8A1.SetActive (true);
		ErhöheWiDiaScoreQ2S5F8A1 ();
	}

	//Erhöht die Anzahl der Wissensdiamanten in Abhängigkeit zur aktuellen Anzahl von Wissensdiamanten
	void ErhöheWiDiaScoreQ2S5F8A1 () //F8A1
	{
		if (ScoringSystem.theScore == 8) {
			ScoringSystem.theScore++;
			RoutineQ2S5MeshHandlungsanweisung (); //nach F8A1A2A3
		}
	}

	IEnumerator FeedbackQ2S5F8A2 () //F8A2
	{
		yield return new WaitForSeconds(0.4f); //soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F8A2.SetActive (true);
	}

	IEnumerator FeedbackQ2S5F8A3 ()//F8A3
	{
		yield return new WaitForSeconds(0.4f); //soll Dauer des Renderns über die Zeit mittels WaitForSecons regeln (erst FeedbackMAT dann wird die nächste Antwortfrage aktiv gesetzt)
		GOFeedbackMATQ2S5F8A3.SetActive (true);
	}


	//Antwortblock 2 für Frage 2
	IEnumerator RoutineQ2S5F1A1A2A3()
	{
		//active
		yield return new WaitForSeconds(0.9f);
		Q2S5F2.SetActive (true);
		MeshQ2S5F2A1.SetActive (true);
		MeshQ2S5F2A2.SetActive (true);
		MeshQ2S5F2A3.SetActive (true);
		//deactivate
		GOFeedbackMATQ2S5F1A1.SetActive (false);
		GOFeedbackMATQ2S5F1A2.SetActive (false); //changeMAT to FeedbackMAT
		GOFeedbackMATQ2S5F1A3.SetActive (false);
		Q2S5F1.SetActive (false);
		MeshQ2S5F1A1.SetActive (false);
		MeshQ2S5F1A2.SetActive (false);
		MeshQ2S5F1A3.SetActive (false);
	}

	//Antwortblock 3 für Frage 3
	IEnumerator RoutineQ2S5F2A1A2A3()
	{
		//active
		yield return new WaitForSeconds(0.9f);
		Q2S5F3.SetActive (true);
		MeshQ2S5F3A1.SetActive (true);
		MeshQ2S5F3A2.SetActive (true);
		MeshQ2S5F3A3.SetActive (true);
		//deactivate
		GOFeedbackMATQ2S5F2A1.SetActive (false);
		GOFeedbackMATQ2S5F2A2.SetActive (false); //changeMAT to FeedbackMAT
		GOFeedbackMATQ2S5F2A3.SetActive (false);
		Q2S5F2.SetActive (false);
		MeshQ2S5F2A1.SetActive (false);
		MeshQ2S5F2A2.SetActive (false);
		MeshQ2S5F2A3.SetActive (false);
	}

	//Antwortblock 4 für Frage 4
	IEnumerator RoutineQ2S5F3A1A2A3()
	{
		//active
		yield return new WaitForSeconds(0.9f);
		Q2S5F4.SetActive (true);
		MeshQ2S5F4A1.SetActive (true);
		MeshQ2S5F4A2.SetActive (true);
		MeshQ2S5F4A3.SetActive (true);
		//deactivate
		GOFeedbackMATQ2S5F3A1.SetActive (false);
		GOFeedbackMATQ2S5F3A2.SetActive (false); //changeMAT to FeedbackMAT
		GOFeedbackMATQ2S5F3A3.SetActive (false);
		Q2S5F3.SetActive (false);
		MeshQ2S5F3A1.SetActive (false);
		MeshQ2S5F3A2.SetActive (false);
		MeshQ2S5F3A3.SetActive (false);
	}

	//Antwortblock 5 Erweiterung
	IEnumerator RoutineQ2S5F4A1A2A3() //F je um 1erhöhen
	{
		//active
		yield return new WaitForSeconds(0.9f);
		Q2S5F5.SetActive (true);
		MeshQ2S5F5A1.SetActive (true);
		MeshQ2S5F5A2.SetActive (true);
		MeshQ2S5F5A3.SetActive (true);
		//deactivate
		GOFeedbackMATQ2S5F4A1.SetActive (false);
		GOFeedbackMATQ2S5F4A2.SetActive (false); //changeMAT to FeedbackMAT
		GOFeedbackMATQ2S5F4A3.SetActive (false);
		Q2S5F4.SetActive (false);
		MeshQ2S5F4A1.SetActive (false);
		MeshQ2S5F4A2.SetActive (false);
		MeshQ2S5F4A3.SetActive (false);
	}

	//Antwortblock 6 Erweiterung
	IEnumerator RoutineQ2S5F5A1A2A3()
	{
		//active, je um 1erhöhen
		yield return new WaitForSeconds(0.9f);
		Q2S5F6.SetActive (true);
		MeshQ2S5F6A1.SetActive (true);
		MeshQ2S5F6A2.SetActive (true);
		MeshQ2S5F6A3.SetActive (true);
		//deactivate
		GOFeedbackMATQ2S5F5A1.SetActive (false);
		GOFeedbackMATQ2S5F5A2.SetActive (false); //changeMAT to FeedbackMAT
		GOFeedbackMATQ2S5F5A3.SetActive (false);
		Q2S5F5.SetActive (false);
		MeshQ2S5F5A1.SetActive (false);
		MeshQ2S5F5A2.SetActive (false);
		MeshQ2S5F5A3.SetActive (false);
	}

	//Antwortblock 7 Erweiterung
	IEnumerator RoutineQ2S5F6A1A2A3()
	{
		//active
		yield return new WaitForSeconds(0.9f);
		Q2S5F7.SetActive (true);
		MeshQ2S5F7A1.SetActive (true);
		MeshQ2S5F7A2.SetActive (true);
		MeshQ2S5F7A3.SetActive (true);
		//deactivate
		GOFeedbackMATQ2S5F6A1.SetActive (false);
		GOFeedbackMATQ2S5F6A2.SetActive (false); //changeMAT to FeedbackMAT
		GOFeedbackMATQ2S5F6A3.SetActive (false);
		Q2S5F6.SetActive (false);
		MeshQ2S5F6A1.SetActive (false);
		MeshQ2S5F6A2.SetActive (false);
		MeshQ2S5F6A3.SetActive (false);
	}

	//Antwortblock 8 Erweiterung
	IEnumerator RoutineQ2S5F7A1A2A3()
	{
		//active
		yield return new WaitForSeconds(0.9f);
		Q2S5F8.SetActive (true);
		MeshQ2S5F8A1.SetActive (true);
		MeshQ2S5F8A2.SetActive (true);
		MeshQ2S5F8A3.SetActive (true);
		//deactivate
		GOFeedbackMATQ2S5F7A1.SetActive (false);
		GOFeedbackMATQ2S5F7A2.SetActive (false); //changeMAT to FeedbackMAT
		GOFeedbackMATQ2S5F7A3.SetActive (false);
		Q2S5F7.SetActive (false);
		MeshQ2S5F7A1.SetActive (false);
		MeshQ2S5F7A2.SetActive (false);
		MeshQ2S5F7A3.SetActive (false);
	}


	//Ende Quiz mit Handlungsanweisung
	IEnumerator RoutineQ2S5MeshHandlungsanweisung ()//
	{
		//active
		yield return new WaitForSeconds(0.9f);
		MeshHandlungsanweisungQ2S5.SetActive (true);
		//deactivate
		GOFeedbackMATQ2S5F8A1.SetActive (false);
		GOFeedbackMATQ2S5F8A2.SetActive (false); //changeMAT to FeedbackMAT
		GOFeedbackMATQ2S5F8A3.SetActive (false);
		Q2S5F5.SetActive (false);
		Q2S5F7.SetActive (false);
		Q2S5F8.SetActive (false);
		MeshQ2S5F8A1.SetActive (false);
		MeshQ2S5F8A2.SetActive (false);
		MeshQ2S5F8A3.SetActive (false);
	}





}//Ende Klasse
