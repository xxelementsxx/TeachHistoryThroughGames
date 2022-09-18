using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RayOpening : MonoBehaviour {



	[SerializeField] private string selecableTag = "choice";
	[SerializeField] private Material highlightMaterial;
	[SerializeField] private Material defaultMaterial;

	// Update is called once per frame

	private Transform _selection;
	public float force = 5;
	Rigidbody rb;

	public string curPasswordKey = "1";

	public string input;

	public bool onTrigger;
	public bool doorOpen;
	public bool keypadScreen;
	public Transform doorHinge;

	public static int theScore;

	//referenz to keys on the pad
	public GameObject number1;
	public GameObject number2;
	public GameObject number3;

	//public GameObject number2;
//	public GameObject number3;

	void OnTriggerEnter(Collider other)
	{
		onTrigger = true;
	}

	void OnTriggerExit(Collider other)
	{
		onTrigger = false;
		keypadScreen = false;
		//input = "";
	}


	private void Update ()
	{

		if (input == curPasswordKey) {
			doorOpen = false;
		}




		if (doorOpen) {
			var newRot = Quaternion.RotateTowards (doorHinge.rotation, Quaternion.Euler (0.0f, -90.0f, 0.0f), Time.deltaTime * 250);
			doorHinge.rotation = newRot;
		}
	




		if (_selection != null) {
			var selectionRenderer = _selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMaterial;
			_selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 100.0f)) { //var not returned and how far the ray will go = 100.0f
			var selection = hit.transform;
			if (selection.CompareTag (selecableTag)) {

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) {

					//Wenn 3 Diamanten eingesammelt sind dann kann DoorOpener benutzt werden
					if (ScoringSystem.theScore == 3) {
						selectionRenderer.material = highlightMaterial;

				
						{	

							if (Input.GetKeyDown (KeyCode.JoystickButton5)) {

								gameObject.GetComponent("number1");
								input += "1";
								print ("yes");
							}
							//if (name.EndsWith ("1"))
							//if (Input.GetKeyDown (KeyCode.JoystickButton5) || name.Equals (number1)) 
							//if(number1  = GameObject.Find("number1"))
							//if(GameObject[0].FindGameObjectsWithTag("numb1"))
							//if(number1 = GameObject.ReferenceEquals ("number1"))
						}
					}
				}
			}
		}
	}
}
	
	
	

	//Wenn Zahl gedrückt, dann wird diese als Eingabe gezählt
	/*void OnMouseDown ()
	{
		//if (number1 = transform.Find ("keypad/Skripthalter/number1").gameObject)
		if (number1 = GameObject.Find ("number1"))
		{
			print ("yo");
			//input = input += "1";
			input += "1";
		}

		//if (number2 = transform.Find ("keypad/Skripthalter/number2").gameObject)
			
		if (number2 = GameObject.Find ("number2"))
			print ("W");
			
		//if (GameObject.Find("number2"))
		//if (number2.gameObject == number2.gameObject)
		{
			//input = input += "2";
			input += "2";
		}

	}*/

/*	void OnMouseUp()
	{
		//OnMouseDown ();
		//if(GUI.Button(new Rect(5, 35, 100, 100), "1"))
		if (number1.activeInHierarchy)
		{
			print ("yo");
			//input = input += "1";
			input += "1";
		}

		if (number2.activeInHierarchy)
		//if (number2 = gameObject) 
		{
			print ("no");
			//input = input += "1";
			input += "2";
		}


	} */





