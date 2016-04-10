using UnityEngine;
using System.Collections;

public class ObjectAppearance : MonoBehaviour {

	private int currentyear = 0;
	[SerializeField] private GameObject[] y0, y1, y2, y3, y4, y5, y6, y7, y8, y9;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			if (currentyear == 9)
				currentyear = 0;
			else
				currentyear++;
		}

		if (currentyear == 0) {
			for (int i = 0; i < y0.Length; i++) {
				y0 [i].SetActive (true);
			}
		}

		else if(currentyear == 1){
			for (int i = 0; i < y0.Length; i++) {
				y0 [i].SetActive (false);
			}
			for (int i = 0; i < y1.Length; i++) {
				y1 [i].SetActive (true);
			}
		}

		else if(currentyear == 2){
			for (int i = 0; i < y1.Length; i++) {
				y1 [i].SetActive (false);
			}
			for (int i = 0; i < y2.Length; i++) {
				y2 [i].SetActive (true);
			}
		}

		else if(currentyear == 3){
			for (int i = 0; i < y2.Length; i++) {
				y2 [i].SetActive (false);
			}
			for (int i = 0; i < y3.Length; i++) {
				y3 [i].SetActive (true);
			}
		}

		else if(currentyear == 4){
			for (int i = 0; i < y3.Length; i++) {
				y3 [i].SetActive (false);
			}
			for (int i = 0; i < y4.Length; i++) {
				y4 [i].SetActive (true);
			}
		}

		else if(currentyear == 5){
			for (int i = 0; i < y4.Length; i++) {
				y4 [i].SetActive (false);
			}
			for (int i = 0; i < y5.Length; i++) {
				y5 [i].SetActive (true);
			}
		}

		else if(currentyear == 6){
			for (int i = 0; i < y5.Length; i++) {
				y5 [i].SetActive (false);
			}
			for (int i = 0; i < y6.Length; i++) {
				y6 [i].SetActive (true);
			}
		}

		else if(currentyear == 7){
			for (int i = 0; i < y6.Length; i++) {
				y6 [i].SetActive (false);
			}
			for (int i = 0; i < y7.Length; i++) {
				y7 [i].SetActive (true);
			}
		}

		else if(currentyear == 8){
			for (int i = 0; i < y7.Length; i++) {
				y7 [i].SetActive (false);
			}
			for (int i = 0; i < y8.Length; i++) {
				y8 [i].SetActive (true);
			}
		}

		else if(currentyear == 9){
			for (int i = 0; i < y8.Length; i++) {
				y8 [i].SetActive (false);
			}
			for (int i = 0; i < y9.Length; i++) {
				y9 [i].SetActive (true);
			}
		}
	}
}
