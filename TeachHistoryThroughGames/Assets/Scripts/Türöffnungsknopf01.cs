using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Türöffnungsknopf01 : MonoBehaviour {

	public static Transform SelektionTüropen01; //Ermöglicht Materialienaustausch
	//public Material DoorIsActiveMAT; //Wenn n Wissens-Diamanten gesammelt sind, MAT von rot nach grün
	public Material HighlightMATifSelectedTüropen01;
	public Material defaultMATTür01;
	[SerializeField] public string SelektTüropen01 = "01Türopen";


	//Türöffnungsmechanismus
	public bool Türöffnung01;
	public Transform ScharniereTüropen01;


	
	// Update is called once per frame
	private void Update ()
	{
		if (ScoringSystem.theScore == 1) //BALANCING
		{
			//Selektion und Aktion von Entscheidung zu Hören
			if (SelektionTüropen01 != null) {
				var selectionRenderer = SelektionTüropen01.GetComponent<Renderer> ();
				selectionRenderer.material = defaultMATTür01;
				SelektionTüropen01 = null;
		}

			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100.0f)) { //var not returned and how far the ray will go = 100.0f
				var selection = hit.transform;
				if (selection.CompareTag (SelektTüropen01)) {

					var selectionRenderer = selection.GetComponent<Renderer> ();
					if (selectionRenderer != null) 
					{
						selectionRenderer.material = HighlightMATifSelectedTüropen01;

						if (Input.GetKey (KeyCode.JoystickButton5)) 
						{

							if (Input.GetKey (KeyCode.JoystickButton5))
								{ //öffnet die Tür, indem das Tür Scharnier (door hinge), um n Grad gedreht wird
									var newRot = Quaternion.RotateTowards (ScharniereTüropen01.rotation, Quaternion.Euler (0.0f, 106f, 0.0f), Time.deltaTime * 250);
									ScharniereTüropen01.rotation = newRot;
								}
							//PlayAudioclip after pressing JoystickButton5
							//Hörtext1.SetActive (true); //play Türöffnungssound
							//AudioHören01.Play (); //play Türöffnungssound
							//open door, um 90 grad drehen
							//Debug.Log ("ok");//Spiele S1,Q1 und T1 ab
						}
					}
					SelektionTüropen01 = selection;
				}
			}//Ende Entscheidung 01Tür offnen in Abhängigkeit der Dias
		}
	}


}
