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

	HeadLookController sarahHeadLook, jayHeadLook;

	GameObject sarahHead, jayHead, playerHead;

	public AudioClip decisionQuestion;
	public AudioClip sarahChoice;
	public AudioClip jayChoice;

	public bool decisionMade = false;
	public bool atDecisionPoint = false;
	bool decisionAsked = false;
	public GameObject currentVH;

	int sarahIndex = 0;
	int jayIndex = 0;

	public AnimationClip[] talkingAnimations;


	// Use this for initialization
	void Start () {
		sarahAnimation = sarah.GetComponent<Animation> ();
		sarahFFX = sarah.GetComponent<FaceFXControllerScript> ();
		sarahAudioSource = sarah.GetComponent<AudioSource> ();

		jayAnimation = jay.GetComponent<Animation> ();
		jayFFX = jay.GetComponent<FaceFXControllerScript> ();
		jayAudioSource = jay.GetComponent<AudioSource> ();

		setActualAnimations ();
		currentVH = sarah;

		sarahHead = GameObject.FindGameObjectWithTag ("sarahHead");
		jayHead = GameObject.FindGameObjectWithTag ("jayHead");
		playerHead = GameObject.FindGameObjectWithTag ("playerHead");
		sarahHeadLook = sarah.gameObject.GetComponent<HeadLookController> ();
		jayHeadLook = jay.gameObject.GetComponent<HeadLookController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (canTakeTurn ()) {
			StartCoroutine ("playSpeech");
		}
		if (atDecisionPoint & canTakeTurn() & !decisionAsked) {
			if (currentVH.name == "sarah") {
				jayAudioSource.clip = decisionQuestion;
				jayAudioSource.Play ();
				jayHeadLook.target = playerHead.transform.position;
				jayFFX.PlayAnim (jayAnimationNames [jayIndex], decisionQuestion);
				
			} else {
				sarahAudioSource.clip = decisionQuestion;
				sarahAudioSource.Play ();
				sarahHeadLook.target = playerHead.transform.position;
				sarahFFX.PlayAnim (sarahAnimationNames [sarahIndex], decisionQuestion);
			}

			decisionAsked = true;
			
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

		temp = new List<string> ();
		foreach(AnimationState state in jayAnimation)
		{
			if (state.name.Contains ("Default")) {
				//Debug.Log (state.name);
				temp.Add (state.name);
			}
		}

		jayAnimationNames = temp.ToArray ();
	}

	IEnumerator playSpeech(){
		float rand = Random.value;
		if (!atDecisionPoint & !decisionMade) {
			Debug.Log ("playing speech of " + currentVH.name);
			if (currentVH.name == "sarah" && sarahIndex < sarahSpeeches.Length) {
				sarahAudioSource.clip = sarahSpeeches [sarahIndex];
				sarahAudioSource.Play ();
				currentVH = jay;
				sarahFFX.PlayAnim(sarahAnimationNames[sarahIndex], sarahSpeeches[sarahIndex]);
				sarahIndex++;
				if (rand > 0.5f) {
					sarahHeadLook.target = jayHead.transform.position;
				} else {
					sarahHeadLook.target = playerHead.transform.position;
				}
				jayHeadLook.target = sarahHead.transform.position;
				yield return new WaitForSeconds (sarahAudioSource.clip.length);

			} else if (currentVH.name == "jay" && jayIndex < jaySpeeches.Length) {
				jayAudioSource.clip = jaySpeeches [jayIndex];
				jayAudioSource.Play ();
				currentVH = sarah;
				jayFFX.PlayAnim(jayAnimationNames[jayIndex], jaySpeeches[jayIndex]);
				jayIndex++;

				if (rand > 0.5f) {
					jayHeadLook.target = sarahHead.transform.position;
				} else {
					jayHeadLook.target = playerHead.transform.position;
				}
				sarahHeadLook.target = jayHead.transform.position;
				yield return new WaitForSeconds (jayAudioSource.clip.length);

			} else {
				atDecisionPoint = true;
			}
		}


	}

	bool canTakeTurn(){
		return !sarahAudioSource.isPlaying && !jayAudioSource.isPlaying;
	}


	void playAnimation(){
		//Debug.Log (sarahAnimationNames [0]);
		sarahAnimation.Play(sarahAnimationNames[0]);
		sarahAudioSource.clip = sarahSpeeches[0];
		sarahAudioSource.Play ();
		sarahFFX.PlayAnim(sarahAnimationNames[0], sarahSpeeches[0]);
	}
}
