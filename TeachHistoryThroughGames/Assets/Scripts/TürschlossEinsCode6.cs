using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//selection MAnager for keyscode 6
public class TürschlossEinsCode6 : MonoBehaviour {

	[SerializeField] private string selecableTagCode6 = "Türschloss6";

	[SerializeField] private Material highlightMaterialTürschloss6; //Rendert nach Selektion das HighlightMAT
	[SerializeField] private Material defaultMATCode6; //das Material, was das Mesh oginal besitzt
	// Update is called once per frame

	public static Transform Türschloss6Selection;

	public float force = 5;
	Rigidbody rb;


	private void Update ()
	{

		if (Türschloss6Selection != null) 
		{
			var selectionRenderer = Türschloss6Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATCode6;
			Türschloss6Selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		//beginn selection key 6
		if (Physics.Raycast (ray, out hit, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit.transform;
			if (selection.CompareTag (selecableTagCode6)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterialTürschloss6;


				}

				Türschloss6Selection = selection;
			}
		}

	}

}