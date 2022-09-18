using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//Spielerentscheidung anhand seiner Aufnahmepräfernz durch dieses Skript möglich
public class SQ01TriggerForAction : MonoBehaviour {

	//public Rigidbody2D Gamer;
	public GameObject Entscheidung01Lesen01; //GameObject für die Entscheidung einen Text lesen
	public GameObject Entscheidung01Hören01; //GameObject für die Entscheidung einen Text hören
	public GameObject TriggerFürEntscheidung01; //Wenn Spieler im Triggerbereich, dann ist eine Entscheidung (Lesen oder Hören) möglich
	public GameObject GOshowGUI; //Ermöglicht das ein GUI angezeigt wird, der den Inhaltstext anzeigt

	//for selections
	[SerializeField] public string selectEntscheidung01Lesen = "01Lesen"; //dient dem Finden über einen Tag mit dem Namen "01Lesen"
	[SerializeField] public string selectEntscheidung01Hören = "01Hören"; //dient dem Finden über einen Tag mit dem Namen "01Hören"
	[SerializeField] public Material highlightMaterialLesen; //rendert bei Raycasttreffer ein Highlightmaterial für das GameObject Lesen 
	[SerializeField] public Material highlightMaterialHören; //rendert bei Raycasttreffer ein Highlightmaterial für das GameObject Lesen
	[SerializeField] public Material defaultMATLesen; //rendert GameObject zugehöriges Standardmaterial
	[SerializeField] public Material defaultMATHören; //rendert GameObject zugehöriges Standardmaterial
	[SerializeField] public static Transform SelektionLesen01; //Transform
	[SerializeField] public static Transform SelektionHören01; //Transform

	public static float force = 5; //definiert Geschwindigkeit des Rays
	 
	public GameObject Hörtext1; //ermöglicht Zuordnung des zu spielenden Audiotextes

	//Wenn Spieler im Triggerbereich
	void OnTriggerEnter (Collider other)
	{
		//Entscheidung01Lesen01.SetActive (true);
		//Entscheidung01Hören01.SetActive (true);
		if (other.gameObject.tag == "Player")
		{
			StartCoroutine(Entscheidung1 ());
			StartCoroutine(Entscheidung2 ());		
		}
	}

	//Wenn Spieler nicht im Triggerbereich
	void OnTriggerExit (Collider other)
	{
		Entscheidung01Lesen01.SetActive (false);
		Entscheidung01Hören01.SetActive (false);
		GOshowGUI.SetActive (false); //deaktiviert die Visability des Lesetextes, wenn Spieler Triggerbereich verlässt.
	}


	//Coroutinefunktion, für Entscheidung 1 Lesen01
	IEnumerator Entscheidung1 ()
	{
		yield return new WaitForSeconds(0.01f);
		Entscheidung01Lesen01.SetActive (true); //lässt das GameObject für Lesen01 aufblenden
		Update ();
	}
		

	//Coroutinefunktion, für Entscheidung 2 Hören01
	IEnumerator Entscheidung2 ()
	{
		yield return new WaitForSeconds(0.01f);
		Entscheidung01Hören01.SetActive (true); //lässt das GameObject für Hören01 aufblenden
		Update ();
	}


	private void Update ()
	{
		//Selektion und Aktion von Entscheidung zu Hören
		if (SelektionHören01 != null) {
			var selectionRenderer = SelektionHören01.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATHören;
			SelektionHören01 = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 100.0f)) {
			var selection = hit.transform;
			if (selection.CompareTag (selectEntscheidung01Hören)) {

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) {
					selectionRenderer.material = highlightMaterialHören;
				
					if (Input.GetKey (KeyCode.JoystickButton5)) {
						//Wenn selektiert und R1 auf Kontroller gedrückt, dann wird die Audio (Hörtext1 abgespielt)
						Hörtext1.SetActive (true);
					}
				}
				SelektionHören01 = selection;
			}
		} //Ende Entscheidung Hören


		//Selektion und Aktion von Entscheidung zu Lesen
		if (SelektionLesen01 != null) {
			var selectionRenderer = SelektionLesen01.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATLesen;
			SelektionLesen01 = null;
		}

		if (Physics.Raycast (ray, out hit, 100.0f)) { //var not returned and how far the ray will go = 100.0f
			var selection = hit.transform;
			if (selection.CompareTag (selectEntscheidung01Lesen)) {

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) {
					selectionRenderer.material = highlightMaterialLesen;

					if (Input.GetKey (KeyCode.JoystickButton5)) {
						CallStoryPart1 ();
					}
				}

				SelektionLesen01 = selection;
			}
		}//Ende Entscheidung Lesen
	}//end update

	//Zeigt ein GUI mit der Storyline für dem ersten Inhaltsteil
	void CallStoryPart1 ()//Wenn GameObject für Lesen selektiert, kollidet und ausgewählt, dann erschein GUI mit Textinhalt
	{
		GOshowGUI.SetActive (true);
	}
		
		
}//class End