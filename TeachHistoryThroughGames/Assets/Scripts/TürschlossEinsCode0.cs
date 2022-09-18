using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//selection MAnager for keyscode 0
public class TürschlossEinsCode0 : MonoBehaviour {

	[SerializeField] private string selecableTagCode0 = "Türschloss0";

	[SerializeField] private Material highlightMaterialTürschloss0; //Rendert nach Selektion das HighlightMAT
	[SerializeField] private Material defaultMATCode0; //das Material, was das Mesh oginal besitzt
	// Update is called once per frame

	public static Transform Türschloss0Selection;

	public float force = 5;
	Rigidbody rb;


	private void Update ()
	{

		if (Türschloss0Selection != null) 
		{
			var selectionRenderer = Türschloss0Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATCode0;
			Türschloss0Selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		//beginn selection key 0
		if (Physics.Raycast (ray, out hit, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit.transform;
			if (selection.CompareTag (selecableTagCode0)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterialTürschloss0;


				}

				Türschloss0Selection = selection;
			}
		}

	}

}