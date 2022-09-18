using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Selektionsmanager für den Keycode 1 (auf dem Keypad)
public class TürschlossEinsCode1 : MonoBehaviour {

	[SerializeField] private string selecableTagCode1 = "Türschloss1";
	[SerializeField] private Material highlightMaterialTürschloss1; //Rendert nach Selektion das HighlightMAT
	[SerializeField] private Material defaultMATCode1; //das Material, was das Mesh oginal besitzt

	public static Transform Türschloss1Selection;
	public float force = 5; //definiert die Geschwindigkeit mit der, der Raycast vom Ursprung auf das zu kollidende Objekt trifft


	private void Update ()
	{

		if (Türschloss1Selection != null) 
		{
			var selectionRenderer = Türschloss1Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATCode1; //rendert das Material was das GameObject (Keycode1) orginal zugewiesen bekommen hat
			Türschloss1Selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition); //deklarieren der Variable ray (Strahl, ausgehen von Mitte des Screens)
		RaycastHit hit; //deklarieren der Variable hit, die angibt das ein Objekt getroffen wird

		//beginn selection key 1
		if (Physics.Raycast (ray, out hit, 100.0f)) //Strahlen-und Trefferfunktion + die Länge des Strahls (Ray)
		{
			var selection = hit.transform;
			if (selection.CompareTag (selecableTagCode1)) //Nachstehende Fkt. wird ausgelöst, wenn GameObject mit oben definierten Tag erhält
			{
				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) //Wenn Ray GameObject mit korrektem Tag trifft, dann wird das obige definierte Highlightmaterial gerendet
				{
					selectionRenderer.material = highlightMaterialTürschloss1;
				}
				Türschloss1Selection = selection;
			}
		}
	}

}