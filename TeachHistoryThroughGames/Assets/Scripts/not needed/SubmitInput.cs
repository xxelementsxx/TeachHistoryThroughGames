using UnityEngine;
using System.Collections;

/*public class SubmitInput : MonoBehaviour {

	public string curPassword = "12345";
	public string input;
	public bool onTrigger;
	public bool doorOpen;

	public Transform doorHinge;

	void OnTriggerEnter(Collider other)
	{
		onTrigger = true;
	}

	void OnTriggerExit(Collider other)
	{
		onTrigger = false;
	
		input = "";
	}

	void Update()
	{
		if(input == curPassword)
		{
			doorOpen = true;
		}

		if(doorOpen)
		{
			var newRot = Quaternion.RotateTowards(doorHinge.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 250);
			doorHinge.rotation = newRot;
		}
	}
		
}*/