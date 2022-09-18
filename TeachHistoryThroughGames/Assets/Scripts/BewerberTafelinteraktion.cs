using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BewerberTafelinteraktion : MonoBehaviour {

	public string SelektionsTag = "Bewerbertafel"; //Ermöglicht Zugriff auf das GameObject mit dem Tagname "Bewerbertafel"
	[SerializeField] private Material highlightBewerbertafelMAT; //Entspricht Material, was gerendert wird, wenn die Bewerbertafel mit dem Ray (Strahl) getroffen wird
	[SerializeField] private Material defaultBewerbertafelMAT; //Standardmaterial der Bewerbertafel (Selektion -> highlight MAT und keine Selektion -> default MAT)
	public static Transform SelektionBT; //Selektion der Bewerbertafel
	public GameObject InteraktionAlfredUdoHolztGUI;
	public Collider ExitGUI; //deklariert Collider, der in der Methode OnTriggerExit angesprochen werden soll

	void OnTriggerExit (Collider other)
	{
		StartCoroutine(GUIBewerbertafelDeactivate());
	}


	void Update () {

		//Wenn 5 Wissensdiamanten, dann nachfolgendes ausführen
		if (ScoringSystem.theScore == 5) 
		{
			//entspricht Grundprinzip der Selektion aus Kapitelabschnitt: Basisfunktionalität der Implementierung
			if (SelektionBT != null) 
			{
				var selectionRenderer = SelektionBT.GetComponent<Renderer> ();
				selectionRenderer.material = defaultBewerbertafelMAT;
				SelektionBT = null;
			}

			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100.0f)) 
			{ //var not returned and how far the ray will go = 100.0f
				var selection = hit.transform;
				if (selection.CompareTag (SelektionsTag)) 
				{
					var selectionRenderer = selection.GetComponent<Renderer> ();
					if (selectionRenderer != null) 
					{
						selectionRenderer.material = highlightBewerbertafelMAT;

						if (Input.GetKey(KeyCode.JoystickButton5))
						{
							ShowGUIBewerbertafel ();
							BelohungBewerbertafel ();
						}
					}
					SelektionBT = selection;
				}
			}
		} //ende if, Dia = 3
	}//ende Update


	void ShowGUIBewerbertafel ()
	{
		InteraktionAlfredUdoHolztGUI.SetActive (true);
	}


	IEnumerator GUIBewerbertafelDeactivate()
	{
		yield return new WaitForSeconds(0.1f);
		InteraktionAlfredUdoHolztGUI.SetActive (false);
	}

	//Wenn GUIText des Bewerbers Alfred Udo Holzt aufblendet, dann belohne den Spielenden, indem 1 Wissensdiamant erhalten wird
	void BelohungBewerbertafel ()
	{
		if (ScoringMBT.istStand == 3) 
		{
			ScoringSystem.theScore++;
		}
	}
}
