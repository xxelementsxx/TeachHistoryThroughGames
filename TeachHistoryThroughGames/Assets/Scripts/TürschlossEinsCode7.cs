using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//selection MAnager for keyscode 7
public class TürschlossEinsCode7 : MonoBehaviour {

	[SerializeField] private string selecableTagCode7 = "Türschloss7";

	[SerializeField] private Material highlightMaterialTürschloss7; //Rendert nach Selektion das HighlightMAT
	[SerializeField] private Material defaultMATCode7; //das Material, was das Mesh oginal besitzt
	// Update is called once per frame

	public static Transform Türschloss7Selection;

	public float force = 5;
	Rigidbody rb;


	private void Update ()
	{

		if (Türschloss7Selection != null) 
		{
			var selectionRenderer = Türschloss7Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATCode7;
			Türschloss7Selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		//beginn selection key 7
		if (Physics.Raycast (ray, out hit, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit.transform;
			if (selection.CompareTag (selecableTagCode7)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterialTürschloss7;


				}

				Türschloss7Selection = selection;
			}
		}

	}

}