using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//Spielerentscheidung anhand seiner Aufnahmepräfernz durch dieses Skript möglich
public class SE01Entscheidung : MonoBehaviour {

	//public Rigidbody2D Gamer;
	public GameObject Entscheidung04Lesen04; //GameObject für die Entscheidung einen Text lesen
	public GameObject Entscheidung04Hören04; //GameObject für die Entscheidung einen Text hören
	public GameObject TriggerFürEntscheidung04; //Wenn Spieler im Triggerbereich, dann ist eine Entscheidung (Lesen oder Hören) möglich
	public GameObject GOshowGUI; //Ermöglicht das ein GUI angezeigt wird, der den Inhaltstext anzeigt

	//for selections
	[SerializeField] public string selectEntscheidung04Lesen = "04Lesen"; //dient dem Finden über einen Tag mit dem Namen "04Lesen"
	[SerializeField] public string selectEntscheidung04Hören = "04Hören"; //dient dem Finden über einen Tag mit dem Namen "04Hören"
	[SerializeField] public Material highlightMaterialLesen04; //rendert bei Raycasttreffer ein Highlightmaterial für das GameObject Lesen 
	[SerializeField] public Material highlightMaterialHören04; //rendert bei Raycasttreffer ein Highlightmaterial für das GameObject Lesen
	[SerializeField] public Material defaultMATLesen04; //rendert GameObject zugehöriges Standardmaterial
	[SerializeField] public Material defaultMATHören04; //rendert GameObject zugehöriges Standardmaterial
	[SerializeField] public static Transform SelektionLesen04; //Transform
	[SerializeField] public static Transform SelektionHören04; //Transform

	public static float force = 20; //definiert Länge des Rays
	public GameObject HörtextS04; //ermöglicht Zuordnung des zu spielenden Audiotextes

	void OnTriggerExit (Collider other)
	{
		GOshowGUI.SetActive (false);
	}


	private void Update ()
	{
		//Wenn n Wissensdiamanten gesammelt worden, dann ist der Jahreswechselschalter aktive
		if (ScoringSystem.theScore >= 5)
		{
			Entscheidung04Lesen04.SetActive (true);
			Entscheidung04Hören04.SetActive (true);
		
			//Selektion und Aktion von Entscheidung zu Hören
			if (SelektionHören04 != null) {
				var selectionRenderer = SelektionHören04.GetComponent<Renderer> ();
				selectionRenderer.material = defaultMATHören04;
				SelektionHören04 = null;
			}

			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100.0f)) {
				var selection = hit.transform;
				if (selection.CompareTag (selectEntscheidung04Hören)) {

					var selectionRenderer = selection.GetComponent<Renderer> ();
					if (selectionRenderer != null) {
						selectionRenderer.material = highlightMaterialHören04;

						if (Input.GetKey (KeyCode.JoystickButton5)) {
							//Wenn selektiert und R1 auf Kontroller gedrückt, dann wird die Audio (Hörtext1 abgespielt)
							HörtextS04.SetActive (true);
						}
					}
					SelektionHören04 = selection;
				}
			} //Ende Entscheidung Hören


			//Selektion und Aktion von Entscheidung zu Lesen
			if (SelektionLesen04 != null) {
				var selectionRenderer = SelektionLesen04.GetComponent<Renderer> ();
				selectionRenderer.material = defaultMATLesen04;
				SelektionLesen04 = null;
			}

			if (Physics.Raycast (ray, out hit, 100.0f)) { //var not returned and how far the ray will go = 100.0f
				var selection = hit.transform;
				if (selection.CompareTag (selectEntscheidung04Lesen)) {

					var selectionRenderer = selection.GetComponent<Renderer> ();
					if (selectionRenderer != null) {
						selectionRenderer.material = highlightMaterialLesen04;

						if (Input.GetKey (KeyCode.JoystickButton5)) {
							CallStoryPart1 ();
						}
					}
					SelektionLesen04 = selection;
				}
			}//Ende Entscheidung Lesen
		}//end ersetzt Trigger und if-Bedingung Wissensdiamanten (5)
	}//end update

	//Zeigt ein GUI mit der Storyline für dem ersten Inhaltsteil
	void CallStoryPart1 ()//Wenn GameObject für Lesen selektiert, kollidet und ausgewählt, dann erschein GUI mit Textinhalt
	{
		GOshowGUI.SetActive (true);
	}


}//class End