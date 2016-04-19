using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterSpeakingController : MonoBehaviour {
	public GameObject sarah, jay;
	public AudioClip[] sarahSpeeches, jaySpeeches;
	AudioSource sarahAudioSource, jayAudioSource;
	string[] sarahAnimationNames, jayAnimationNames;
	Animation sarahAnimation, jayAnimation;
	public FaceFXControllerScript sarahFFX, jayFFX;

	public bool decisionMade = false;
	public bool atDecisionPoint = false;
	public GameObject currentVH;

	int sarahIndex = 0;
	int jayIndex = 0;


	// Use this for initialization
	void Start () {
		sarahAnimation = sarah.GetComponent<Animation> ();
		sarahFFX = sarah.GetComponent<FaceFXControllerScript> ();
		sarahAudioSource = sarah.GetComponent<AudioSource> ();

		jayAnimation = jay.GetComponent<Animation> ();
		jayFFX = jay.GetComponent<FaceFXControllerScript> ();
		jayAudioSource = jay.GetComponent<AudioSource> ();

		//setActualAnimations ();
		Invoke ("takeTurn", 2);
	}
	
	// Update is called once per frame
	void Update () {
		if (!sarahAudioSource.isPlaying && !jayAudioSource.isPlaying) {
			Invoke ("takeTurn", 3);
		}
	}

	void setActualAnimations(){
		Debug.Log (sarahAnimation.GetClipCount ());
		List<string> temp = new List<string> ();
		foreach(AnimationState state in sarahAnimation)
		{
			if (state.name.Contains ("Default")) {
				//Debug.Log (state.name);
				temp.Add (state.name);
			}
		}

		sarahAnimationNames = temp.ToArray ();
	}

	void takeTurn(){
		if (!atDecisionPoint & !decisionMade) {
			if (currentVH.name == "sarah" && (sarahIndex < sarahSpeeches.Length - 3)) {
				sarahAudioSource.clip = sarahSpeeches [sarahIndex];
				sarahAudioSource.Play ();
				sarahIndex++;
				currentVH = jay;

			} else if (currentVH.name == "jay" && (jayIndex <= jaySpeeches.Length - 2)) {
				jayAudioSource.clip = jaySpeeches [jayIndex];
				jayAudioSource.Play ();
				jayIndex++;
				currentVH = sarah;
			} else {
				Debug.Log ("time to make a decision");
				atDecisionPoint = true;
			}
		}
	}

	void playAnimation(){
		//Debug.Log (sarahAnimationNames [0]);
		//sarahAnimation.Play(sarahAnimationNames[0]);
		sarahAudioSource.clip = sarahSpeeches[0];
		sarahAudioSource.Play ();
		//sarahFFX.PlayAnim(sarahAnimationNames[0], sarahSpeeches[0]);
	}
}
