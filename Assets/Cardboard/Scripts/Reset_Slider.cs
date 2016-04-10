using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Reset_Slider : MonoBehaviour {
	//public Slider slider;
	//public GameObject prevSlider, nextSlider;
	// Use this for initialization
	public GameObject slider;
	public Slider s;
	void Start () {
		
	}
	
	/*public void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			if (nextSlider.activeSelf) {
				nextSlider.SetActive (false);
			} else {
				nextSlider.SetActive (true);
			}
			if (prevSlider.activeSelf) {
				prevSlider.SetActive (false);
			} else {
				prevSlider.SetActive (true);
			}
			//slider.value = 1967.00f;
		}
	}*/

	public void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
			slider.SetActive (true);
		}
	}

	public void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			s.value = 1967.00f;
			slider.SetActive (false);
		}
	}
}
