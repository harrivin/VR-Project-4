using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CharacterCreation : MonoBehaviour {

	private List<GameObject> models;
	private int selectionIndex=0;
	string currentGender = "female";

	bool buttonPressed = false;

	// Use this for initialization
	void Start () {
	
		models = new List<GameObject> ();
		foreach (Transform t in transform) {
			models.Add (t.gameObject);
			t.gameObject.SetActive (false);
		}

		models [selectionIndex].SetActive (true);
	}

	public void Select(int index){

//		if (index == selectionIndex)
//			return;
//		if (index < 0 || index>= models.Count)
//			return;
//
		models [selectionIndex].SetActive (false);
		selectionIndex = index;
		models [selectionIndex].SetActive (true);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("LeftBumper") | Input.GetButtonDown ("RightBumper")) {
			//buttonPressed = true;
			if (selectionIndex == 0) {
				Select (1);
				currentGender = "male";
				//buttonPressed = false;
			} else {
				Select (0);
				currentGender = "female";
				//buttonPressed = false;
			}
		}
			
			
		if (Input.GetMouseButton (0))
			transform.Rotate (new Vector3 (0.0f, Input.GetAxis ("Mouse X"), 0.0f));


		if (Input.GetButton ("Fire1")) {
			Invoke ("loadScene", 0.3f);
		}
	}

	void loadScene(){
		DecisionManager.gender = currentGender;
		SceneManager.LoadScene ("stevieHouse");
	}
}
