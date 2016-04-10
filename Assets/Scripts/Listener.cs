using UnityEngine;
using System.Collections;

public class Listener : MonoBehaviour {
	public GameObject thisObject;
	[SerializeField] public float[] yearsActive;
	public float beginningRange, endRange;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void receiveMessage(float year){
		Debug.Log ("Inside rec message");

		thisObject.SetActive (true);
		if (yearsActive.Length > 0) {
			for (int i = 0; i < yearsActive.Length; i++) {
				if (year == yearsActive [i]) {
					//Debug.Log ("Setting fridge inactive");
					return;
				}
					
			
			}
			//thisObject.SetActive (false);
		} 
			if (year < beginningRange || year > endRange) {
				thisObject.SetActive (false);
			}

	}
}
