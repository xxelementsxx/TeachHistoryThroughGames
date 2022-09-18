using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//selection MAnager for all keys
public class SelectManagerKey4 : MonoBehaviour {

	[SerializeField] private string selecableTagKey4 = "key4";

	[SerializeField] private Material highlightMaterial;
	[SerializeField] private Material defaultMATkey4;
	// Update is called once per frame

	public static Transform Key4Selection;

	public float force = 5;



	private void Update ()
	{

		if (Key4Selection != null) 
		{
			var selectionRenderer = Key4Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATkey4;
			Key4Selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		//beginn selection key 1
		if (Physics.Raycast (ray, out hit, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit.transform;
			if (selection.CompareTag (selecableTagKey4)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterial;


				}

				Key4Selection = selection;
			}
		}

	}

}