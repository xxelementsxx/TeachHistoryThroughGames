using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//selection MAnager for keyscode 8
public class TürschlossEinsCode8 : MonoBehaviour {

	[SerializeField] private string selecableTagCode8 = "Türschloss8";

	[SerializeField] private Material highlightMaterialTürschloss8; //Rendert nach Selektion das HighlightMAT
	[SerializeField] private Material defaultMATCode8; //das Material, was das Mesh oginal besitzt
	// Update is called once per frame

	public static Transform Türschloss8Selection;

	public float force = 5;
	Rigidbody rb;


	private void Update ()
	{

		if (Türschloss8Selection != null) 
		{
			var selectionRenderer = Türschloss8Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATCode8;
			Türschloss8Selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		//beginn selection key 8
		if (Physics.Raycast (ray, out hit, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit.transform;
			if (selection.CompareTag (selecableTagCode8)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterialTürschloss8;


				}

				Türschloss8Selection = selection;
			}
		}

	}

}