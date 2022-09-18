using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PasswortKeypadEins : MonoBehaviour {

	public static int theScore; //auf score referenzieren
	public float force = 100; //definiert die Geschwindigkeit mit der, der Raycast vom Ursprung auf das zu kollidende Objekt trifft
	public static string curPassword = "7905";//Diese Passwortangabe steht in Abhängigkeit mit den Highlightmaterialien aus dem Q1
	public static string input; //Eingabe
	public bool onTrigger; //Löscht Eingabe wenn nicht mehr im Triggerbereich
	public bool TüröffnungTrueFalseHörsaaltür1; //Zeigt an ob Tür geöffnet (Haken in der Checkbox) oder geschlossen (kein Haken) ist
	public bool TüröffnungTrueFalseHörsaaltür2; //Zeigt an ob Tür geöffnet (Haken in der Checkbox) oder geschlossen (kein Haken) ist
	public Transform ScharniereTürschlossEins; //Schraniere wird als Transform definiert, weil Transform eine Positions- und Rotationsfunktion ermöglicht
	public Transform ScharniereTürschlossZwei; //Weitere Scharnierortation, zum Türöffnen hinzufügen

	void OnTriggerEnter(Collider other)
	{
		onTrigger = true;
	}

	void OnTriggerExit(Collider other)
	{
		onTrigger = false;
		input = "";
	}



	void OnGUI() //Zeigt ein Inputfeld, indem die eingegebenen Keycodes angezeigt werden
	{
		if(ScoringSystem.theScore >= 2)
		{
			if (onTrigger == true) //Fix - disable GUI-Anzeige, wenn nicht mehr im Trigger(BoxCollider)-bereich
			{
				//Inputfeld wird definiert
				GUI.Box(new Rect(230, 50, 150, 20), input);
			}
		}
	}




	void Update()
	{//Update open

		if (input == curPassword) { //Wenn die Eingabe (input) = curPassword(festgelegtes Passwort), dann geht die Tür auf
			TüröffnungTrueFalseHörsaaltür1 = true; //führt unten stehende Funktion aus
			TüröffnungTrueFalseHörsaaltür2 = true; //führt unten stehende Funktion aus
		}

		//Wenn das eingegebene Passwort korrekt ist, dann wird ein Scharnier, beidem die zu öffnende Tür als Child gilt, um z.B. wie hier, um 90Grad gedreht (zur Folge: Tür öffnet sich).
		if (TüröffnungTrueFalseHörsaaltür1 && TüröffnungTrueFalseHörsaaltür2) { //öffnet die Tür(en), indem das Tür Scharnier (door hinge), um 90 Grad gedreht wird
			var newRotTür01 = Quaternion.RotateTowards (ScharniereTürschlossEins.rotation, Quaternion.Euler (0.0f, -90.0f, 0.0f), Time.deltaTime * 250);
			var newRotTür02 = Quaternion.RotateTowards (ScharniereTürschlossZwei.rotation, Quaternion.Euler (0.0f, -90.0f, 0.0f), Time.deltaTime * 250); //Öffnen einer weiteren Tür eingebunden
			ScharniereTürschlossEins.rotation = newRotTür01;
			ScharniereTürschlossZwei.rotation = newRotTür02;
		}


		//Wenn der Spieler 1 Wissensdiamanten eingesammelt hat, dann können die Keycodes selektiert werden (d.h. ein HighlighMaterial wird solange gerendet, wie der Raycast das Objekt trifft) und nachstehende Funktionen für den Input ausgeführt werden (in Abhängigkeit mit der vom Spieler ausgeführten Selektion).
		if (ScoringSystem.theScore == 2) 
		{
			if (TürschlossEinsCode1.Türschloss1Selection) 
			{//Ist die Selektion für den Keycode [1] wahr (Selektionsfunktion befindet sich im Skript) und wird die Aktionstaste auf dem Kontroller gedrückt, so wird als Input 1 ins Inputfeld eingetragen.
				if (Input.GetKeyDown (KeyCode.JoystickButton5) && GameObject.FindGameObjectWithTag ("Türschloss1")) 
				{
					input = input += "1";
				}
			}//End: key1


			if (TürschlossEinsCode2.Türschloss2Selection) 
			{
				if (Input.GetKeyDown (KeyCode.JoystickButton5) && GameObject.FindGameObjectWithTag ("Türschloss2")) 
				{
					input = input += "2";
				}					
			}//End: key2

			if (TürschlossEinsCode3.Türschloss3Selection)
			{
				if (Input.GetKeyDown (KeyCode.JoystickButton5) && GameObject.FindGameObjectWithTag ("Türschloss3")) 
				{
					input = input += "3";
				}
			}//End: key3
				
			if (TürschlossEinsCode4.Türschloss4Selection)
			{
				if (Input.GetKeyDown (KeyCode.JoystickButton5) && GameObject.FindGameObjectWithTag ("Türschloss4")) 
				{
					input = input += "4";
				}
			}//End: key4
				
			if (TürschlossEinsCode5.Türschloss5Selection)
			{
				if (Input.GetKeyDown (KeyCode.JoystickButton5) && GameObject.FindGameObjectWithTag ("Türschloss5")) 
				{
					input = input += "5";
				}
			}//End: key5
				
			if (TürschlossEinsCode6.Türschloss6Selection)
			{
				if (Input.GetKeyDown (KeyCode.JoystickButton5) && GameObject.FindGameObjectWithTag ("Türschloss6")) 
				{
					input = input += "6";
				}
			}//End: key6
				
			if (TürschlossEinsCode7.Türschloss7Selection)
			{
				if (Input.GetKeyDown (KeyCode.JoystickButton5) && GameObject.FindGameObjectWithTag ("Türschloss7")) 
				{
					input = input += "7";
				}
			}//End: key7
				
			if (TürschlossEinsCode8.Türschloss8Selection)
			{
				if (Input.GetKeyDown (KeyCode.JoystickButton5) && GameObject.FindGameObjectWithTag ("Türschloss8")) 
				{
					input = input += "8";
				}
			}//End: key8
				
			if (TürschlossEinsCode9.Türschloss9Selection)
			{
				if (Input.GetKeyDown (KeyCode.JoystickButton5) && GameObject.FindGameObjectWithTag ("Türschloss9")) 
				{
					input = input += "9";
				}
			}//End: key9
				
			if (TürschlossEinsCode0.Türschloss0Selection)
			{
				if (Input.GetKeyDown (KeyCode.JoystickButton5) && GameObject.FindGameObjectWithTag ("Türschloss0")) 
				{
					input = input += "0";
				}
			}//End: key0
				

		} //end Selektions- und Inputionsfunktion
	}//close update



}//end class





