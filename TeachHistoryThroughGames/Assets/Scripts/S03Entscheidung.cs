using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//Spielerentscheidung anhand seiner Aufnahmepräfernz durch dieses Skript möglich
public class S03Entscheidung : MonoBehaviour {

	//public Rigidbody2D Gamer;
	public GameObject Entscheidung05Lesen05; //GameObject für die Entscheidung einen Text lesen
	public GameObject Entscheidung05Hören05; //GameObject für die Entscheidung einen Text hören
	public GameObject TriggerFürEntscheidung05; //Wenn Spieler im Triggerbereich, dann ist eine Entscheidung (Lesen oder Hören) möglich
	public GameObject GOshowGUI; //Ermöglicht das ein GUI angezeigt wird, der den Inhaltstext anzeigt

	//for selections
	[SerializeField] public string selectEntscheidung05Lesen = "05Lesen"; //dient dem Finden über einen Tag mit dem Namen "05Lesen"
	[SerializeField] public string selectEntscheidung05Hören = "05Hören"; //dient dem Finden über einen Tag mit dem Namen "05Hören"
	[SerializeField] public Material highlightMaterialLesen05; //rendert bei Raycasttreffer ein Highlightmaterial für das GameObject Lesen 
	[SerializeField] public Material highlightMaterialHören05; //rendert bei Raycasttreffer ein Highlightmaterial für das GameObject Lesen
	[SerializeField] public Material defaultMATLesen05; //rendert GameObject zugehöriges Standardmaterial
	[SerializeField] public Material defaultMATHören05; //rendert GameObject zugehöriges Standardmaterial
	[SerializeField] public static Transform SelektionLesen05; //Transform
	[SerializeField] public static Transform SelektionHören05; //Transform

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
			Entscheidung05Lesen05.SetActive (true);
			Entscheidung05Hören05.SetActive (true);

			//Selektion und Aktion von Entscheidung zu Hören
			if (SelektionHören05 != null) {
				var selectionRenderer = SelektionHören05.GetComponent<Renderer> ();
				selectionRenderer.material = defaultMATHören05;
				SelektionHören05 = null;
			}

			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100.0f)) {
				var selection = hit.transform;
				if (selection.CompareTag (selectEntscheidung05Hören)) {

					var selectionRenderer = selection.GetComponent<Renderer> ();
					if (selectionRenderer != null) {
						selectionRenderer.material = highlightMaterialHören05;

						if (Input.GetKey (KeyCode.JoystickButton5)) {
							//Wenn selektiert und R1 auf Kontroller gedrückt, dann wird die Audio (Hörtext1 abgespielt)
							HörtextS03.SetActive (true);
						}
					}
					SelektionHören05 = selection;
				}
			} //Ende Entscheidung Hören


			//Selektion und Aktion von Entscheidung zu Lesen
			if (SelektionLesen05 != null) {
				var selectionRenderer = SelektionLesen05.GetComponent<Renderer> ();
				selectionRenderer.material = defaultMATLesen05;
				SelektionLesen05 = null;
			}

			if (Physics.Raycast (ray, out hit, 100.0f)) { //var not returned and how far the ray will go = 100.0f
				var selection = hit.transform;
				if (selection.CompareTag (selectEntscheidung05Lesen)) {

					var selectionRenderer = selection.GetComponent<Renderer> ();
					if (selectionRenderer != null) {
						selectionRenderer.material = highlightMaterialLesen05;

						if (Input.GetKey (KeyCode.JoystickButton5)) {
							CallStoryPart1 ();
						}
					}
					SelektionLesen05 = selection;
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