using UnityEngine;
using System.Collections;

public class SarahController : MonoBehaviour {

	AudioSource sarahAS;
	public AudioClip[] sarahSpeeches;

	// Use this for initialization
	void Start () {
		sarahAS = this.gameObject.GetComponent<AudioSource> ();
		if (DecisionManager.predictedFuture == "good") {
			sarahAS.clip = sarahSpeeches [0];
		} else {
			sarahAS.clip = sarahSpeeches [1];
		}

		sarahAS.Play ();
	
	}
	

}
