using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterSpeakingController : MonoBehaviour {
	public GameObject vh1;
	public AudioClip[] vh1Speeches;
	AudioSource vh1AudioSource;
	string[] vh1AnimationNames;
	Animation vh1Animation;
	public FaceFXControllerScript vh1FFX;

	// Use this for initialization
	void Start () {
		vh1Animation = vh1.GetComponent<Animation> ();
		vh1FFX = vh1.GetComponent<FaceFXControllerScript> ();
		vh1AudioSource = vh1.GetComponent<AudioSource> ();
		setActualAnimations ();
		Invoke ("playAnimation", 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void setActualAnimations(){
		Debug.Log (vh1Animation.GetClipCount ());
		List<string> temp = new List<string> ();
		foreach(AnimationState state in vh1Animation)
		{
			if (state.name.Contains ("Default")) {
				//Debug.Log (state.name);
				temp.Add (state.name);
			}
		}

		vh1AnimationNames = temp.ToArray ();
	}

	void playAnimation(){
		Debug.Log (vh1AnimationNames [0]);
		//vh1Animation.Play(vh1AnimationNames[0]);
		vh1AudioSource.clip = vh1Speeches[0];
		vh1AudioSource.Play ();
		vh1FFX.PlayAnim(vh1AnimationNames[0], vh1Speeches[0]);
	}
}
