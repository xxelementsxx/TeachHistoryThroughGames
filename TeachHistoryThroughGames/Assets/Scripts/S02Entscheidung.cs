using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//Spielerentscheidung anhand seiner Aufnahmepräfernz durch dieses Skript möglich
public class S02Entscheidung : MonoBehaviour {

	//public Rigidbody2D Gamer;
	public GameObject Entscheidung03Lesen03; //GameObject für die Entscheidung einen Text lesen
	public GameObject Entscheidung03Hören03; //GameObject für die Entscheidung einen Text hören
	//public GameObject TriggerFürEntscheidung03; //Wenn Spieler im Triggerbereich, dann ist eine Entscheidung (Lesen oder Hören) möglich
	public GameObject GOshowGUI; //Ermöglicht das ein GUI angezeigt wird, der den Inhaltstext anzeigt

	//for selections
	[SerializeField] public string selectEntscheidung03Lesen = "03Lesen"; //dient dem Finden über einen Tag mit dem Namen "03Lesen"
	[SerializeField] public string selectEntscheidung03Hören = "03Hören"; //dient dem Finden über einen Tag mit dem Namen "03Hören"
	[SerializeField] public Material highlightMaterialLesen03; //rendert bei Raycasttreffer ein Highlightmaterial für das GameObject Lesen 
	[SerializeField] public Material highlightMaterialHören03; //rendert bei Raycasttreffer ein Highlightmaterial für das GameObject Lesen
	[SerializeField] public Material defaultMATLesen03; //rendert GameObject zugehöriges Standardmaterial
	[SerializeField] public Material defaultMATHören03; //rendert GameObject zugehöriges Standardmaterial
	[SerializeField] public static Transform SelektionLesen03; //Transform
	[SerializeField] public static Transform SelektionHören03; //Transform

	public static float force = 20; //definiert Länge des Rays

	public GameObject Hörtext2; //ermöglicht Zuordnung des zu spielenden Audiotextes

	void OnTriggerExit ()
	{
		GOshowGUI.SetActive (false);
	}

	private void Update ()
	{
		//Wenn 3 Wissensdiamanten gesammelt worden, dann ist der Jahreswechselschalter aktive
		if (ScoringSystem.theScore == 3)
		{
			//Selektion und Aktion von Entscheidung zu Hören
			if (SelektionHören03 != null) {
				var selectionRenderer = SelektionHören03.GetComponent<Renderer> ();
				selectionRenderer.material = defaultMATHören03;
				SelektionHören03 = null;
			}

			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
				
			if (Physics.Raycast (ray, out hit, 100.0f)) {
				var selection = hit.transform;
				if (selection.CompareTag (selectEntscheidung03Hören)) {

					var selectionRenderer = selection.GetComponent<Renderer> ();
					if (selectionRenderer != null) {
						selectionRenderer.material = highlightMaterialHören03;

						if (Input.GetKey (KeyCode.JoystickButton5)) {
						//Wenn selektiert und R1 auf Kontroller gedrückt, dann wird die Audio (Hörtext1 abgespielt)
							Hörtext2.SetActive (true);
						}
					}
					SelektionHören03 = selection;
				}
			} //Ende Entscheidung Hören


			//Selektion und Aktion von Entscheidung zu Lesen
			if (SelektionLesen03 != null) {
				var selectionRenderer = SelektionLesen03.GetComponent<Renderer> ();
				selectionRenderer.material = defaultMATLesen03;
				SelektionLesen03 = null;
			}

			if (Physics.Raycast (ray, out hit, 100.0f)) { //var not returned and how far the ray will go = 100.0f
				var selection = hit.transform;
				if (selection.CompareTag (selectEntscheidung03Lesen)) {

					var selectionRenderer = selection.GetComponent<Renderer> ();
					if (selectionRenderer != null) {
						selectionRenderer.material = highlightMaterialLesen03;

						if (Input.GetKey (KeyCode.JoystickButton5)) {
							CallStoryPart1 ();
						}
					}
					SelektionLesen03 = selection;
				}
			}//Ende Entscheidung Lesen
		}//if-Bedingung Wissensdiamanten (3)
	}//end update

	//Zeigt ein GUI mit der Storyline für dem ersten Inhaltsteil
	void CallStoryPart1 ()//Wenn GameObject für Lesen selektiert, kollidet und ausgewählt, dann erschein GUI mit Textinhalt
	{
		GOshowGUI.SetActive (true);
	}


}//class End