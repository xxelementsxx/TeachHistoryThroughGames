using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//selection MAnager for all keys
public class SelectManagerKey2 : MonoBehaviour {

	[SerializeField] private string selecableTagKey2 = "key2";

	[SerializeField] private Material highlightMaterial;
	[SerializeField] private Material defaultMATkey2;
	// Update is called once per frame

	public static Transform Key2Selection;

	public float force = 5;



	private void Update ()
	{

		if (Key2Selection != null) 
		{
			var selectionRenderer = Key2Selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMATkey2;
			Key2Selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		//beginn selection key 1
		if (Physics.Raycast (ray, out hit, 100.0f)) 
		{ //var not returned and how far the ray will go = 100.0f
			var selection = hit.transform;
			if (selection.CompareTag (selecableTagKey2)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterial;


				}

				Key2Selection = selection;
			}
		}

	}

}