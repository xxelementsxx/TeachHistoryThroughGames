using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;//schreiben in eine Datei


public class ScoringSystem : MonoBehaviour {

	public GameObject ScoreText;
	public static int theScore;


	void Update()
	{
		ScoreText.GetComponent<Text> ().text = " " + theScore;
		System.IO.File.WriteAllText("D:/MA/Game/states.txt", theScore.ToString("aktuelle Wissensdiamanten: " + theScore));//schreibe in datei, wie hoch der Score ist.

	}



}
