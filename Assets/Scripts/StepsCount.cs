using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StepsCount : MonoBehaviour {
	public int steps;
	public int steps1;
	public int x;
	public Text stepsText;
	// Use this for initialization
	void Start () {
		stepsText = this.gameObject.GetComponent<Text> ();

	}

	void OnLevelWasLoaded(int level) {
		if (level == 1) {
			print ("level 0 - intro scene");
			steps = 0;
			x = 0;
		} else if (level == 2) {
			print ("level 1 - fastfood ");
			steps = 1000;
			x = 1;
		} else if (level == 3 && x == 1) {
			print ("level 2 - house + fastfood");
			steps = 2000;
		} else if (level == 3 && x == 0) {
			print ("level 2 - house + house");
			steps = 1000;
		} else if (level == 4 && x == 1) {
			print ("level 3 - store ");
			steps = 6000;
		}
		else if (level == 4 && x == 0) {
			print ("level 3 - store ");
			steps = 5000;
		}
		else if (level == 5 && x == 1) {
			print ("level 4 - grocerystore+apartment ");
			steps = 10000;
		}
		else if (level == 5 && x == 0) {
			print ("level 4 - grocerystore+apartment ");
			steps = 9000;
		}
	}

//	void OnGUI()
//	{
//		//GUI.Label(new Rect(10, 10, 100, 20), steps1.ToString());
//	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (steps);
		stepsText.text = "steps taken: " + steps1.ToString ();
		if ((Input.GetAxis ("Horizontal") != 0) || (Input.GetAxis ("Vertical") != 0)) { 
			steps=steps+1;
			steps1 = steps / 10;
		}
	}
}
