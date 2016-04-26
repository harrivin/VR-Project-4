using UnityEngine;
using System.Collections;

public class StepsCountApartmentTwo : MonoBehaviour {
	int steps=4000;
	int steps1=0;
	// Use this for initialization
	void Start () {

	}

	void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 100, 20), steps1.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (steps);
		if ((Input.GetAxis ("Horizontal") != 0) || (Input.GetAxis ("Vertical") != 0)) { 
			steps=steps+1;
			steps1 = steps / 10;
		}
	}
}
