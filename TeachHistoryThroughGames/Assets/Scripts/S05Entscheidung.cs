using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//Spielerentscheidung anhand seiner Aufnahmepräfernz durch dieses Skript möglich
public class S05Entscheidung : MonoBehaviour {

	//public Rigidbody2D Gamer;
	public GameObject Entscheidung07Lesen07; //GameObject für die Entscheidung einen Text lesen
	public GameObject Entscheidung07Hören07; //GameObject für die Entscheidung einen Text hören
	public GameObject TriggerFürEntscheidung07; //Wenn Spieler im Triggerbereich, dann ist eine Entscheidung (Lesen oder Hören) möglich
	public GameObject GOshowGUI; //Ermöglicht das ein GUI angezeigt wird, der den Inhaltstext anzeigt

	//for selections
	[SerializeField] public string selectEntscheidung07Lesen = "07Lesen"; //dient dem Finden über einen Tag mit dem Namen "07Lesen"
	[SerializeField] public string selectEntscheidung07Hören = "07Hören"; //dient dem Finden über einen Tag mit dem Namen "07Hören"
	[SerializeField] public Material highlightMaterialLesen07; //rendert bei Raycasttreffer ein Highlightmaterial für das GameObject Lesen 
	[SerializeField] public Material highlightMaterialHören07; //rendert bei Raycasttreffer ein Highlightmaterial für das GameObject Lesen
	[SerializeField] public Material defaultMATLesen07; //rendert GameObject zugehöriges Standardmaterial
	[SerializeField] public Material defaultMATHören07; //rendert GameObject zugehöriges Standardmaterial
	[SerializeField] public static Transform SelektionLesen07; //Transform
	[SerializeField] public static Transform SelektionHören07; //Transform

	public static float force = 20; //definiert Länge des Rays
	public GameObject HörtextS05; //ermöglicht Zuordnung des zu spielenden Audiotextes

	void OnTriggerExit (Collider other)
	{
		GOshowGUI.SetActive (false);
	}


	private void Update ()
	{
		//Wenn 6 Wissensdiamanten gesammelt worden, dann ist der Jahreswechselschalter aktive

		if (ScoringSystem.theScore >= 6)
		{
			Entscheidung07Lesen07.SetActive (true);
			Entscheidung07Hören07.SetActive (true);

			//Selektion und Aktion von Entscheidung zu Hören
			if (SelektionHören07 != null) {
				var selectionRenderer = SelektionHören07.GetComponent<Renderer> ();
				selectionRenderer.material = defaultMATHören07;
				SelektionHören07 = null;
			}

			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100.0f)) {
				var selection = hit.transform;
				if (selection.CompareTag (selectEntscheidung07Hören)) {

					var selectionRenderer = selection.GetComponent<Renderer> ();
					if (selectionRenderer != null) {
						selectionRenderer.material = highlightMaterialHören07;

						if (Input.GetKey (KeyCode.JoystickButton5)) {
							//Wenn selektiert und R1 auf Kontroller gedrückt, dann wird die Audio (Hörtext1 abgespielt)
							HörtextS05.SetActive (true);
						}
					}
					SelektionHören07 = selection;
				}
			} //Ende Entscheidung Hören


			//Selektion und Aktion von Entscheidung zu Lesen
			if (SelektionLesen07 != null) {
				var selectionRenderer = SelektionLesen07.GetComponent<Renderer> ();
				selectionRenderer.material = defaultMATLesen07;
				SelektionLesen07 = null;
			}

			if (Physics.Raycast (ray, out hit, 100.0f)) { //var not returned and how far the ray will go = 100.0f
				var selection = hit.transform;
				if (selection.CompareTag (selectEntscheidung07Lesen)) {

					var selectionRenderer = selection.GetComponent<Renderer> ();
					if (selectionRenderer != null) {
						selectionRenderer.material = highlightMaterialLesen07;

						if (Input.GetKey (KeyCode.JoystickButton5)) {
							CallStoryPart1 ();
						}
					}
					SelektionLesen07 = selection;
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