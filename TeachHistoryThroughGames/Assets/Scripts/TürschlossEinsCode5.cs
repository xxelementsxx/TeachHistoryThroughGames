using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//selection MAnager for keyscode 5
public class TürschlossEinsCode5 : MonoBehaviour {

	[SerializeField] private string selecableTagCode5 = "Türschloss5";

	[SerializeField] private Material highlightMaterialTürschloss5; //Rendert nach Selektion das HighlightMAT
	[SerializeField] private Material defaultMATCode5; //das Material, was das Mesh oginal besitzt
	// Update is called once per frame

	public static Transform Türschloss5Selection;

	public float force = 5;
	Rigidbody rb;


	private void Update ()
	{

		if (Türschloss5Selection != null) 
		{
			var selectionRenderer = Türschloss5Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATCode5;
			Türschloss5Selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		//beginn selection key 5
		if (Physics.Raycast (ray, out hit, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit.transform;
			if (selection.CompareTag (selecableTagCode5)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterialTürschloss5;


				}

				Türschloss5Selection = selection;
			}
		}

	}

}