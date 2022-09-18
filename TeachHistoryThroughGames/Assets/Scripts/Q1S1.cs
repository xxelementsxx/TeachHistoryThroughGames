using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//Generalisierbarkeit: Bei erstellung eines weiteren Quizes muss ausschließlich Q1 und S1, um 1 erhöht werden
// Quiz zugehörig der Storyline 1
//Insg. enthält ein Quiz min. 3 Fragestellungen mit jeweils 3 Antwortmöglichkeiten
public class Q1S1 : MonoBehaviour {

	//(1) Zuweisungen wie Tags, Materialien, Game Objects
	//(1.1) Zuweisungstag: Wenn Raycast hits Ausgangsmaterial, dann tausche das MAT mit dem zu zuweisendem HIghlightsmaterial
		// Wird über Tags geregelt, welches GameObject, welches Material erhält


	//Ausgangsmaterial der Q1S1F1-Q1S1F4 (jeweils A1;A2;A3)
	[SerializeField] private Material defaultMATQ1S1F1A1;
	[SerializeField] private Material defaultMATQ1S1F1A2;
	[SerializeField] private Material defaultMATQ1S1F1A3;

	[SerializeField] private Material defaultMATQ1S1F2A1;//
	[SerializeField] private Material defaultMATQ1S1F2A2;
	[SerializeField] private Material defaultMATQ1S1F2A3;

	[SerializeField] private Material defaultMATQ1S1F3A1;
	[SerializeField] private Material defaultMATQ1S1F3A2;
	[SerializeField] private Material defaultMATQ1S1F3A3;

	[SerializeField] private Material defaultMATQ1S1F4A1;
	[SerializeField] private Material defaultMATQ1S1F4A2;
	[SerializeField] private Material defaultMATQ1S1F4A3;


	//Selektionsmaterial der Q1S1F1-Q1S1F4 (jeweils A1;A2;A3)
	[SerializeField] private Material highMATQ1S1F1A1;
	[SerializeField] private Material highMATQ1S1F1A2;
	[SerializeField] private Material highMATQ1S1F1A3;

	[SerializeField] private Material highMATQ1S1F2A1;//
	[SerializeField] private Material highMATQ1S1F2A2;
	[SerializeField] private Material highMATQ1S1F2A3;

	[SerializeField] private Material highMATQ1S1F3A1;
	[SerializeField] private Material highMATQ1S1F3A2;
	[SerializeField] private Material highMATQ1S1F3A3;

	[SerializeField] private Material highMATQ1S1F4A1;
	[SerializeField] private Material highMATQ1S1F4A2;
	[SerializeField] private Material highMATQ1S1F4A3;


	//Selektion der Antwortmöglichkeiten des Quizes über Tag-Erkennung
	//Tag-Erkennung für Q1S1F1
	[SerializeField] private string SelectionQ1S1F1A1 = "Q1S1F1A1";
	[SerializeField] private string SelectionQ1S1F1A2 = "Q1S1F1A2";
	[SerializeField] private string SelectionQ1S1F1A3 = "Q1S1F1A3";


	//Tag-Erkennung für Q1S1F2
	[SerializeField] private string SelectionQ1S1F2A1 = "Q1S1F2A1";
	[SerializeField] private string SelectionQ1S1F2A2 = "Q1S1F2A2";
	[SerializeField] private string SelectionQ1S1F2A3 = "Q1S1F2A3";


	//Tag-Erkennung für Q1S1F3
	[SerializeField] private string SelectionQ1S1F3A1 = "Q1S1F3A1";
	[SerializeField] private string SelectionQ1S1F3A2 = "Q1S1F3A2";
	[SerializeField] private string SelectionQ1S1F3A3 = "Q1S1F3A3";


	//Tag-Erkennung für Q1S1F4
	[SerializeField] private string SelectionQ1S1F4A1 = "Q1S1F4A1";
	[SerializeField] private string SelectionQ1S1F4A2 = "Q1S1F4A2";
	[SerializeField] private string SelectionQ1S1F4A3 = "Q1S1F4A3";


	//Zur Funktionsrealisierung des Materialwechsels durch den Renderer
	public static Transform Q1S1F1A1; //Quiz1, Storypart1, Frage1: Antwortmöglichkeit 1
	public static Transform Q1S1F1A2;
	public static Transform Q1S1F1A3;

	public static Transform Q1S1F2A1;
	public static Transform Q1S1F2A2;
	public static Transform Q1S1F2A3;

	public static Transform Q1S1F3A1;
	public static Transform Q1S1F3A2;
	public static Transform Q1S1F3A3;

	public static Transform Q1S1F4A1;
	public static Transform Q1S1F4A2;
	public static Transform Q1S1F4A3;

	//Geschwindigkeit des Raycasts
	public float force = 5;

	//Zur Aktivierung bzw. Deaktivierung der GameObjekte als Fragehalter
	public GameObject Q1S1F1;
	public GameObject Q1S1F2;
	public GameObject Q1S1F3;
	public GameObject Q1S1F4;

	//Zur Aktivierung oder Deaktivierung von Antwortmöglichkeiten als GameObejkt
	public GameObject MeshQ1S1F1A1;
	public GameObject MeshQ1S1F1A2;
	public GameObject MeshQ1S1F1A3;

	public GameObject MeshQ1S1F2A1;
	public GameObject MeshQ1S1F2A2;
	public GameObject MeshQ1S1F2A3;

	public GameObject MeshQ1S1F3A1;
	public GameObject MeshQ1S1F3A2;
	public GameObject MeshQ1S1F3A3;

	public GameObject MeshQ1S1F4A1;
	public GameObject MeshQ1S1F4A2;
	public GameObject MeshQ1S1F4A3;

	//Zur Aktivierung oder Deaktivierung von Handlungsanweisung als GameObject (dient als Wegleiter zur Teilaufgabe2)
	public GameObject MeshHandlungsanweisungQ1S1;

	//Zeige Quiz (Frage 1 und 3 Antwortmöglichkeiten der Frage 1), wenn der Spielende, mit dem Fragezeichen-Mesh kollidiert bzw. es berührt
	//using set.Active (true) oder (false);
	public void OnTriggerEnter (Collider other)
	{
		//Frage-Antowrtblock 1
		Q1S1F1.SetActive (true);
		MeshQ1S1F1A1.SetActive (true);
		MeshQ1S1F1A2.SetActive (true);
		MeshQ1S1F1A3.SetActive (true);
	}


	//Deaktivate, wenn Player nicht mehr im Triggerbereich (wenn er nicht mehr mit Fragezeichenmesh kollidiert)
	public void OnTriggerExit (Collider other)
	{
		//Jedes GameObject und jedes Prefab, dass im Quiz existiert -> deaktiviere das letzte Object was momentan aktive ist
		MeshHandlungsanweisungQ1S1.SetActive (false);
	//	Q1S1F3.SetActive (false);
	}


	// Update is called once per frame
	void Update () 
	{
		//Wenn Raycast hits eins der Objekt (jeweils die Antwortmöglichkeiten der vers. Fragen), dann tausche das Material und löse nach betätigen der Aktionstaste auf dem Kontroller eine Funktion aus
		// ... für Q1S1F1A1
		if (Q1S1F1A1 != null) //start Q1S1F1A1
		{
			var selectionRenderer = Q1S1F1A1.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ1S1F1A1;
			Q1S1F1A1 = null;
		}

		var rayQ1S1F1A1 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ1S1F1A1;

		if (Physics.Raycast (rayQ1S1F1A1, out hitQ1S1F1A1, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ1S1F1A1.transform;
			if (selection.CompareTag (SelectionQ1S1F1A1)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ1S1F1A1;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ1S1F1A1A2A3());
					}
				}

				Q1S1F1A1 = selection;
			}
		} //Ende Q1S1F1A1

		//-----

		if (Q1S1F1A2 != null) //start Q1S1F1A2
		{
			var selectionRenderer = Q1S1F1A2.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ1S1F1A2;
			Q1S1F1A2 = null;
		}

		var rayQ1S1F1A2 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ1S1F1A2;

		if (Physics.Raycast (rayQ1S1F1A2, out hitQ1S1F1A2, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ1S1F1A2.transform;
			if (selection.CompareTag (SelectionQ1S1F1A2)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ1S1F1A2;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ1S1F1A1A2A3());
					}
				}

				Q1S1F1A2 = selection;
			}
		} //Ende Q1S1F1A2

		//-----

		if (Q1S1F1A3 != null) //start Q1S1F1A3
		{
			var selectionRenderer = Q1S1F1A3.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ1S1F1A3;
			Q1S1F1A3 = null;
		}

		var rayQ1S1F1A3 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ1S1F1A3;

		if (Physics.Raycast (rayQ1S1F1A3, out hitQ1S1F1A3, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ1S1F1A3.transform;
			if (selection.CompareTag (SelectionQ1S1F1A3)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ1S1F1A3;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ1S1F1A1A2A3());
					}
				}

				Q1S1F1A3 = selection;
			}
		} //Ende Q1S1F1A3


		//-----
		if (Q1S1F2A1 != null) //start Q1S1F2A1
		{
			var selectionRenderer = Q1S1F2A1.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ1S1F2A1;
			Q1S1F2A1 = null;
		}

		var rayQ1S1F2A1 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ1S1F2A1;

		if (Physics.Raycast (rayQ1S1F2A1, out hitQ1S1F2A1, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ1S1F2A1.transform;
			if (selection.CompareTag (SelectionQ1S1F2A1)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ1S1F2A1;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ1S1F2A1A2A3());
					}
				}

				Q1S1F2A1 = selection;
			}
		} //Ende Q1S1F2A1


		//-----
		if (Q1S1F2A2 != null) //start Q1S1F2A2
		{
			var selectionRenderer = Q1S1F2A2.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ1S1F2A2;
			Q1S1F2A2 = null;
		}

		var rayQ1S1F2A2 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ1S1F2A2;

		if (Physics.Raycast (rayQ1S1F2A2, out hitQ1S1F2A2, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ1S1F2A2.transform;
			if (selection.CompareTag (SelectionQ1S1F2A2)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ1S1F2A2;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ1S1F2A1A2A3());
					}
				}

				Q1S1F2A2 = selection;
			}
		} //Ende Q1S1F2A2


		//-----
		if (Q1S1F2A3 != null) //start Q1S1F2A3
		{
			var selectionRenderer = Q1S1F2A3.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ1S1F2A3;
			Q1S1F2A3 = null;
		}

		var rayQ1S1F2A3 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ1S1F2A3;

		if (Physics.Raycast (rayQ1S1F2A3, out hitQ1S1F2A3, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ1S1F2A3.transform;
			if (selection.CompareTag (SelectionQ1S1F2A3)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ1S1F2A3;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ1S1F2A1A2A3());
					}
				}

				Q1S1F2A3 = selection;
			}
		} //Ende Q1S1F2A3


		//-----
		if (Q1S1F3A1 != null) //start Q1S1F3A1
		{
			var selectionRenderer = Q1S1F3A1.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ1S1F3A1;
			Q1S1F3A1 = null;
		}

		var rayQ1S1F3A1 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ1S1F3A1;

		if (Physics.Raycast (rayQ1S1F3A1, out hitQ1S1F3A1, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ1S1F3A1.transform;
			if (selection.CompareTag (SelectionQ1S1F3A1)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ1S1F3A1;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ1S1F3A1A2A3());//
					}
				}

				Q1S1F3A1 = selection;
			}
		} //Ende Q1S1F3A1


		//-----
		if (Q1S1F3A2 != null) //start Q1S1F3A2
		{
			var selectionRenderer = Q1S1F3A2.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ1S1F3A2;
			Q1S1F3A2 = null;
		}

		var rayQ1S1F3A2 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ1S1F3A2;

		if (Physics.Raycast (rayQ1S1F3A2, out hitQ1S1F3A2, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ1S1F3A2.transform;
			if (selection.CompareTag (SelectionQ1S1F3A2)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ1S1F3A2;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ1S1F3A1A2A3());
					}
				}

				Q1S1F3A2 = selection;
			}
		} //Ende Q1S1F3A2


		//-----
		if (Q1S1F3A3 != null) //start Q1S1F3A3
		{
			var selectionRenderer = Q1S1F3A3.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ1S1F3A3;
			Q1S1F3A3 = null;
		}

		var rayQ1S1F3A3 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ1S1F3A3;

		if (Physics.Raycast (rayQ1S1F3A3, out hitQ1S1F3A3, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ1S1F3A3.transform;
			if (selection.CompareTag (SelectionQ1S1F3A3)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ1S1F3A3;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ1S1F3A1A2A3());
					}
				}

				Q1S1F3A3 = selection;
			}
		} //Ende Q1S1F3A3


		//-----End Quiz-----
		if (Q1S1F4A1 != null) //start Q1S1F4A1
		{
			var selectionRenderer = Q1S1F4A1.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ1S1F4A1;
			Q1S1F4A1 = null;
		}

		var rayQ1S1F4A1 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ1S1F4A1;

		if (Physics.Raycast (rayQ1S1F4A1, out hitQ1S1F4A1, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ1S1F4A1.transform;
			if (selection.CompareTag (SelectionQ1S1F4A1)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ1S1F4A1;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ1S1MeshHandlungsanweisung());
					}
				}

				Q1S1F4A1 = selection;
			}
		} //Ende Q1S1F4A1


		//-----End Quiz-----
		if (Q1S1F4A2 != null) //start Q1S1F4A2
		{
			var selectionRenderer = Q1S1F4A2.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ1S1F4A2;
			Q1S1F4A2 = null;
		}

		var rayQ1S1F4A2 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ1S1F4A2;

		if (Physics.Raycast (rayQ1S1F4A2, out hitQ1S1F4A2, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ1S1F4A2.transform;
			if (selection.CompareTag (SelectionQ1S1F4A2)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ1S1F4A2;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ1S1MeshHandlungsanweisung());
					}
				}

				Q1S1F4A2 = selection;
			}
		} //Ende Q1S1F4A2


		//-----End Quiz-----
		if (Q1S1F4A3 != null) //start Q1S1F4A3
		{
			var selectionRenderer = Q1S1F4A3.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATQ1S1F4A3;
			Q1S1F4A3 = null;
		}

		var rayQ1S1F4A3 = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitQ1S1F4A3;

		if (Physics.Raycast (rayQ1S1F4A3, out hitQ1S1F4A3, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hitQ1S1F4A3.transform;
			if (selection.CompareTag (SelectionQ1S1F4A3)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highMATQ1S1F4A3;

					if (Input.GetKey (KeyCode.JoystickButton5)) 
					{
						StartCoroutine(RoutineQ1S1MeshHandlungsanweisung());
					}
				}

				Q1S1F4A3 = selection;
			}
		} //Ende Q1S1F4A3




	}//Ende Update


	//Antwortblock 2 für Frage 2
	IEnumerator RoutineQ1S1F1A1A2A3()
	{
		//active
		yield return new WaitForSeconds(0.2f);
		Q1S1F2.SetActive (true);
		MeshQ1S1F2A1.SetActive (true);
		MeshQ1S1F2A2.SetActive (true);
		MeshQ1S1F2A3.SetActive (true);
		//deactivate
		Q1S1F1.SetActive (false);
		MeshQ1S1F1A1.SetActive (false);
		MeshQ1S1F1A2.SetActive (false);
		MeshQ1S1F1A3.SetActive (false);
	}

	//Antwortblock 3 für Frage 3
	IEnumerator RoutineQ1S1F2A1A2A3()
	{
		//active
		yield return new WaitForSeconds(0.2f);
		Q1S1F3.SetActive (true);
		MeshQ1S1F3A1.SetActive (true);
		MeshQ1S1F3A2.SetActive (true);
		MeshQ1S1F3A3.SetActive (true);
		//deactivate
		Q1S1F2.SetActive (false);
		MeshQ1S1F2A1.SetActive (false);
		MeshQ1S1F2A2.SetActive (false);
		MeshQ1S1F2A3.SetActive (false);
	}

	//Antwortblock 4 für Frage 4
	IEnumerator RoutineQ1S1F3A1A2A3()
	{
		//active
		yield return new WaitForSeconds(0.2f);
		Q1S1F4.SetActive (true);
		MeshQ1S1F4A1.SetActive (true);
		MeshQ1S1F4A2.SetActive (true);
		MeshQ1S1F4A3.SetActive (true);
		//deactivate
		Q1S1F3.SetActive (false);
		MeshQ1S1F3A1.SetActive (false);
		MeshQ1S1F3A2.SetActive (false);
		MeshQ1S1F3A3.SetActive (false);
	}

	//Ende Quiz mit Handlungsanweisung
	IEnumerator RoutineQ1S1MeshHandlungsanweisung ()//
	{
		//active
		yield return new WaitForSeconds(0.2f);
		MeshHandlungsanweisungQ1S1.SetActive (true);
		//deactivate
		Q1S1F3.SetActive (false);
		Q1S1F4.SetActive (false);
		MeshQ1S1F4A1.SetActive (false);
		MeshQ1S1F4A2.SetActive (false);
		MeshQ1S1F4A3.SetActive (false);
	}





}//Ende Klasse
