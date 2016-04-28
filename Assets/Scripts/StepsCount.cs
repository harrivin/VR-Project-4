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
		stepsText.text = "steps taken: " + steps1.ToString ();

	}

	void OnLevelWasLoaded(int level) {
		if (level == 1) {

			print ("level 1 - house");
			steps1 = 0;
			steps = 0;
			testing.x = 0;
		
		} else if (level == 2) {

			print ("level 2 - fastfood ");
			steps1 = 1000;
			steps = 10000;
			testing.x = 1;
		
		} else if (level == 3 && testing.x == 1) {
			print (testing.x);
			print ("level 3 - house2 + fastfood");
			steps1 = 2000;
			steps = 20000;

		} else if (level == 3 && testing.x != 1) {
			print (testing.x);
			print ("level 3 - house2 + house");
			steps1 = 500;
			steps = 5000;
		
		} else if (level == 4 && testing.x == 1) {
			print (testing.x);
			print ("level 4 - store + fastfood ");
			steps1 = 6000;
			steps = 60000;

		}
		else if (level == 4 && testing.x != 1) {
			print (testing.x);
			print ("level 4 - store + house ");
			steps1 = 4500;
			steps = 45000;
	
		}
		else if (level == 5 && testing.x == 1) {
			print (testing.x);
			print ("level 4 - grocerystore + fastfood ");
			steps1 = 10000;
			steps = 100000;

		}
		else if (level == 5 && testing.x != 1) {
			print (testing.x);
			print ("level 4 - grocerystore + house ");
			steps1 = 8500;
			steps = 85000;

		}
	}

//	void OnGUI()
//	{
//		//GUI.Label(new Rect(10, 10, 100, 20), steps1.ToString());
//	}
	
	// Update is called once per frame
	void Update () {
	//	Debug.Log (steps);
		stepsText.text = "steps taken: " + steps1.ToString ();
		if ((Input.GetAxis ("Horizontal") != 0) || (Input.GetAxis ("Vertical") != 0)) { 
			steps=steps+1;
			steps1 = steps / 10;
		}
	}
}
