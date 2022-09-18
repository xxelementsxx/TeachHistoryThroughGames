using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//selection MAnager for keyscode 9
public class TürschlossEinsCode9 : MonoBehaviour {

	[SerializeField] private string selecableTagCode9 = "Türschloss9";

	[SerializeField] private Material highlightMaterialTürschloss9; //Rendert nach Selektion das HighlightMAT
	[SerializeField] private Material defaultMATCode9; //das Material, was das Mesh oginal besitzt
	// Update is called once per frame

	public static Transform Türschloss9Selection;

	public float force = 5;
	Rigidbody rb;


	private void Update ()
	{

		if (Türschloss9Selection != null) 
		{
			var selectionRenderer = Türschloss9Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATCode9;
			Türschloss9Selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		//beginn selection key 9
		if (Physics.Raycast (ray, out hit, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit.transform;
			if (selection.CompareTag (selecableTagCode9)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterialTürschloss9;


				}

				Türschloss9Selection = selection;
			}
		}

	}

}