using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDia : MonoBehaviour {

 

	void OnTriggerEnter (Collider other)
	{
		ScoringSystem.theScore += 1;
		Destroy (gameObject);
	}
		





}
