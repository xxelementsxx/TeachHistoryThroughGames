using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//selection MAnager for keyscode 4
public class TürschlossEinsCode4 : MonoBehaviour {

	[SerializeField] private string selecableTagCode4 = "Türschloss4";

	[SerializeField] private Material highlightMaterialTürschloss4; //Rendert nach Selektion das HighlightMAT
	[SerializeField] private Material defaultMATCode4; //das Material, was das Mesh oginal besitzt
	// Update is called once per frame

	public static Transform Türschloss4Selection;

	public float force = 5;
	Rigidbody rb;


	private void Update ()
	{

		if (Türschloss4Selection != null) 
		{
			var selectionRenderer = Türschloss4Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATCode4;
			Türschloss4Selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		//beginn selection key 4
		if (Physics.Raycast (ray, out hit, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit.transform;
			if (selection.CompareTag (selecableTagCode4)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterialTürschloss4;


				}

				Türschloss4Selection = selection;
			}
		}

	}

}