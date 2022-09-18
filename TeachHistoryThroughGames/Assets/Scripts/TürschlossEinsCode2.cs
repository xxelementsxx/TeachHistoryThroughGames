using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//selection MAnager for keyscode 2
public class TürschlossEinsCode2 : MonoBehaviour {

	[SerializeField] private string selecableTagCode2 = "Türschloss2";

	[SerializeField] private Material highlightMaterialTürschloss2; //Rendert nach Selektion das HighlightMAT
	[SerializeField] private Material defaultMATCode2; //das Material, was das Mesh oginal besitzt
	// Update is called once per frame

	public static Transform Türschloss2Selection;

	public float force = 5;
	Rigidbody rb;


	private void Update ()
	{

		if (Türschloss2Selection != null) 
		{
			var selectionRenderer = Türschloss2Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATCode2;
			Türschloss2Selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		//beginn selection key 2
		if (Physics.Raycast (ray, out hit, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit.transform;
			if (selection.CompareTag (selecableTagCode2)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterialTürschloss2;


				}

				Türschloss2Selection = selection;
			}
		}

	}

}