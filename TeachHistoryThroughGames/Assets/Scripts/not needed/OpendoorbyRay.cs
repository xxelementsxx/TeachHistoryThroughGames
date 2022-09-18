using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpendoorbyRay : MonoBehaviour {

	public string curPassword = "12345";
	public string input;
	public bool onTrigger;
	public bool doorOpen;
	public bool keypadScreen;
	public Transform doorHinge;

	[SerializeField] private string selecableTag = "choice";
	[SerializeField] private Material highlightMaterial;
	[SerializeField] private Material defaultMaterial;
	// Update is called once per frame

	private Transform _selection;
	public float force = 5;
	Rigidbody rb;


	private void Update () 

	{
		 
			if(input == curPassword)
			{
				doorOpen = true;
			}

			if(doorOpen)
			{
				var newRot = Quaternion.RotateTowards(doorHinge.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 250);
				doorHinge.rotation = newRot;
			}



		if (_selection != null) 
		{
			var selectionRenderer = _selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMaterial;
			_selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 100.0f)) //var not returned and how far the ray will go = 100.0f
		{
			var selection = hit.transform;
			if (selection.CompareTag (selecableTag)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterial;

					if (Input.GetKeyDown(KeyCode.JoystickButton5)) 
					{
						
						if (!doorOpen) 
						{
							if (onTrigger) 
							{
								GUI.Box (new Rect (0, 0, 200, 25), "Press 'R1' to open keypad");

								if (Input.GetKeyDown(KeyCode.JoystickButton5)) {
									keypadScreen = true;
									onTrigger = false;
								}
							}



							if (keypadScreen) 
							{
								OnGUI();
							}
						}//PrintName (hit.transform.gameObject);
						//hier kommt hin was passieren soll -> aufrufen der Methode von unten
					}
					//PrintName (hit.transform.gameObject); //print name after selection
					//LaunchIntoAir (rb);

					//Rigidbody rb;

					//	if (rb = hit.transform.GetComponent<Rigidbody> ()) 
					//	{
					//		PrintName (hit.transform.gameObject);
					//		LaunchIntoAir(rb);
					//	}
				}

				_selection = selection;
			}

		}
	}





	void OnTriggerEnter(Collider other)
	{
		onTrigger = true;
	}

	void OnTriggerExit(Collider other)
	{
		onTrigger = false;
		keypadScreen = false;
		input = "";
	}

	private void OnGUI ()
	{
		if (!doorOpen) {
			if (onTrigger) {
				GUI.Box (new Rect (0, 0, 200, 25), "Press 'R1' to open keypad");

				if (Input.GetKeyDown(KeyCode.JoystickButton5)) {
					keypadScreen = true;
					onTrigger = false;
				}
			}

			if (keypadScreen) {
				GUI.Box (new Rect (0, 0, 320, 455), "");
				GUI.Box (new Rect (5, 5, 310, 25), input);

				if (GUI.Button (new Rect (5, 35, 100, 100), "1")) {
					input = input + "1";
				}

				if (GUI.Button (new Rect (110, 35, 100, 100), "2")) {
					input = input + "2";
				}

				if (GUI.Button (new Rect (215, 35, 100, 100), "3")) {
					input = input + "3";
				}

				if (GUI.Button (new Rect (5, 140, 100, 100), "4")) {
					input = input + "4";
				}

				if (GUI.Button (new Rect (110, 140, 100, 100), "5")) {
					input = input + "5";
				}

				if (GUI.Button (new Rect (215, 140, 100, 100), "6")) {
					input = input + "6";
				}

				if (GUI.Button (new Rect (5, 245, 100, 100), "7")) {
					input = input + "7";
				}

				if (GUI.Button (new Rect (110, 245, 100, 100), "8")) {
					input = input + "8";
				}

				if (GUI.Button (new Rect (215, 245, 100, 100), "9")) {
					input = input + "9";
				}

				if (GUI.Button (new Rect (110, 350, 100, 100), "0")) {
					input = input + "0";
				}
			}
		}
	}}
//}}


