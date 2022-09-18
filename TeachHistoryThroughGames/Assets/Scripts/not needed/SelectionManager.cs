using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour {

	[SerializeField] private string selecableTag = "Selectable";
	[SerializeField] private Material highlightMaterial;
	[SerializeField] private Material defaultMaterial; //use default MAT key1
	// Update is called once per frame

	private Transform _selection;
	public float force = 5;
	Rigidbody rb;


	private void Update () 
	{

		if (_selection != null) 
		{
			var selectionRenderer = _selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMaterial; //RenderMAT für Key1
			_selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 100.0f)) //var not returned and how far the ray will go = 100.0f
		{
			var selection = hit.transform;
			if (selection.CompareTag (selecableTag)) 
			{

				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterial;

						if (Input.GetKeyDown(KeyCode.JoystickButton5)) 
							{
								//CollectDia (hit.transform.gameObject);
								//hier kommt hin was passieren soll -> aufrufen der Methode von unten
							}
					//PrintName (hit.transform.gameObject); //print name after selection
					//LaunchIntoAir (rb);

					//Rigidbody rb;

				//	if (rb = hit.transform.GetComponent<Rigidbody> ()) 
				//	{
				//		PrintName (hit.transform.gameObject);
				//		LaunchIntoAir(rb);
				//	}
				}

				_selection = selection;
			}

		}
	}


	//private void CollectDia(GameObject go)
	//{
	//	print (go.name); //function print name
	//}
		

}