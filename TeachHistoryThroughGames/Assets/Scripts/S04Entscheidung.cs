using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//Spielerentscheidung anhand seiner Aufnahmepräfernz durch dieses Skript möglich
public class S04Entscheidung : MonoBehaviour {

	//public Rigidbody2D Gamer;
	public GameObject Entscheidung06Lesen06; //GameObject für die Entscheidung einen Text lesen
	public GameObject Entscheidung06Hören06; //GameObject für die Entscheidung einen Text hören
	public GameObject TriggerFürEntscheidung06; //Wenn Spieler im Triggerbereich, dann ist eine Entscheidung (Lesen oder Hören) möglich
	public GameObject GOshowGUI; //Ermöglicht das ein GUI angezeigt wird, der den Inhaltstext anzeigt

	//for selections
	[SerializeField] public string selectEntscheidung06Lesen = "06Lesen"; //dient dem Finden über einen Tag mit dem Namen "06Lesen"
	[SerializeField] public string selectEntscheidung06Hören = "06Hören"; //dient dem Finden über einen Tag mit dem Namen "06Hören"
	[SerializeField] public Material highlightMaterialLesen06; //rendert bei Raycasttreffer ein Highlightmaterial für das GameObject Lesen 
	[SerializeField] public Material highlightMaterialHören06; //rendert bei Raycasttreffer ein Highlightmaterial für das GameObject Lesen
	[SerializeField] public Material defaultMATLesen06; //rendert GameObject zugehöriges Standardmaterial
	[SerializeField] public Material defaultMATHören06; //rendert GameObject zugehöriges Standardmaterial
	[SerializeField] public static Transform SelektionLesen06; //Transform
	[SerializeField] public static Transform SelektionHören06; //Transform

	public static float force = 20; //definiert Länge des Rays
	public GameObject HörtextS03; //ermöglicht Zuordnung des zu spielenden Audiotextes

	void OnTriggerExit (Collider other)
	{
		GOshowGUI.SetActive (false);
	}


	private void Update ()
	{
		//Wenn 3 Wissensdiamanten gesammelt worden, dann ist der Jahreswechselschalter aktive

		if (ScoringSystem.theScore >= 4)
		{
			Entscheidung06Lesen06.SetActive (true);
			Entscheidung06Hören06.SetActive (true);

			//Selektion und Aktion von Entscheidung zu Hören
			if (SelektionHören06 != null) {
				var selectionRenderer = SelektionHören06.GetComponent<Renderer> ();
				selectionRenderer.material = defaultMATHören06;
				SelektionHören06 = null;
			}

			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100.0f)) {
				var selection = hit.transform;
				if (selection.CompareTag (selectEntscheidung06Hören)) {

					var selectionRenderer = selection.GetComponent<Renderer> ();
					if (selectionRenderer != null) {
						selectionRenderer.material = highlightMaterialHören06;

						if (Input.GetKey (KeyCode.JoystickButton5)) {
							//Wenn selektiert und R1 auf Kontroller gedrückt, dann wird die Audio (Hörtext1 abgespielt)
							HörtextS03.SetActive (true);
						}
					}
					SelektionHören06 = selection;
				}
			} //Ende Entscheidung Hören


			//Selektion und Aktion von Entscheidung zu Lesen
			if (SelektionLesen06 != null) {
				var selectionRenderer = SelektionLesen06.GetComponent<Renderer> ();
				selectionRenderer.material = defaultMATLesen06;
				SelektionLesen06 = null;
			}

			if (Physics.Raycast (ray, out hit, 100.0f)) { //var not returned and how far the ray will go = 100.0f
				var selection = hit.transform;
				if (selection.CompareTag (selectEntscheidung06Lesen)) {

					var selectionRenderer = selection.GetComponent<Renderer> ();
					if (selectionRenderer != null) {
						selectionRenderer.material = highlightMaterialLesen06;

						if (Input.GetKey (KeyCode.JoystickButton5)) {
							CallStoryPart1 ();
						}
					}
					SelektionLesen06 = selection;
				}
			}//Ende Entscheidung Lesen
		}//end ersetzt Trigger und if-Bedingung Wissensdiamanten (4)
	}//end update

	//Zeigt ein GUI mit der Storyline für dem ersten Inhaltsteil
	void CallStoryPart1 ()//Wenn GameObject für Lesen selektiert, kollidet und ausgewählt, dann erschein GUI mit Textinhalt
	{
		GOshowGUI.SetActive (true);
	}


}//class End