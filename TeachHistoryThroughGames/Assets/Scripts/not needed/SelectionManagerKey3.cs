using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//selection MAnager for all keys
public class SelectionManagerKey3 : MonoBehaviour {

	[SerializeField] private string selecableTagKey3 = "key3";

	[SerializeField] private Material highlightMaterial;
	[SerializeField] private Material defaultMATkey3;
	// Update is called once per frame

	public static Transform Key3Selection;

	public float force = 5;



	private void Update ()
	{

		if (Key3Selection != null) 
		{
			var selectionRenderer = Key3Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATkey3;
			Key3Selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		//beginn selection key 1
		if (Physics.Raycast (ray, out hit, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit.transform;
			if (selection.CompareTag (selecableTagKey3)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterial;


				}

				Key3Selection = selection;
			}
		}

	}

}