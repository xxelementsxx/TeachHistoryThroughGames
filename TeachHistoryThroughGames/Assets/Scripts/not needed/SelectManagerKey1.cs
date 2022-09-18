using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//selection MAnager for all keys
public class SelectManagerKey1 : MonoBehaviour {

	[SerializeField] private string selecableTagKey1 = "key1";

	[SerializeField] private Material highlightMaterial;
	[SerializeField] private Material defaultMATkey1;
		// Update is called once per frame

	public static Transform Key1Selection;

	public float force = 5;
	Rigidbody rb;


	private void Update ()
	{

		if (Key1Selection != null) 
		{
			var selectionRenderer = Key1Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATkey1;
			Key1Selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		//beginn selection key 1
		if (Physics.Raycast (ray, out hit, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit.transform;
			if (selection.CompareTag (selecableTagKey1)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterial;


				}

				Key1Selection = selection;
			}
		}

	}

}