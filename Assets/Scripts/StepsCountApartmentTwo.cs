using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StepsCountApartmentTwo : MonoBehaviour {
	int steps;
	int steps1;
	Text stepsTaken; 
	// Use this for initialization
	void Start () {
		steps=4000;
		steps1=0;
		stepsTaken =  this.gameObject.GetComponent<Text>();
		stepsTaken.text = "steps taken: " + steps.ToString();
	}

	
	// Update is called once per frame
	void Update () {
		Debug.Log (steps1);
		if ((Input.GetAxis ("Horizontal") != 0) || (Input.GetAxis ("Vertical") != 0)) { 
			steps=steps+1;
			steps1 = steps / 10;

		}

	}

	void updateSteps(){
		stepsTaken.text = "steps taken: " + steps.ToString();
	}
}
