using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//selection MAnager for keyscode 3
public class TürschlossEinsCode3 : MonoBehaviour {

	[SerializeField] private string selecableTagCode3 = "Türschloss3";

	[SerializeField] private Material highlightMaterialTürschloss3; //Rendert nach Selektion das HighlightMAT
	[SerializeField] private Material defaultMATCode3; //das Material, was das Mesh oginal besitzt
	// Update is called once per frame

	public static Transform Türschloss3Selection;

	public float force = 5;
	Rigidbody rb;


	private void Update ()
	{

		if (Türschloss3Selection != null) 
		{
			var selectionRenderer = Türschloss3Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATCode3;
			Türschloss3Selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		//beginn selection key 3
		if (Physics.Raycast (ray, out hit, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit.transform;
			if (selection.CompareTag (selecableTagCode3)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterialTürschloss3;


				}

				Türschloss3Selection = selection;
			}
		}

	}

}