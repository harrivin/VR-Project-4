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

	string sarahLookTarget = "";
	string jayLookTarget = "";


	// Use this for initialization
	void Start () {
		sarahAnimation = sarah.GetComponent<Animation> ();
		sarahFFX = sarah.GetComponent<FaceFXControllerScript> ();
		sarahAudioSource = sarah.GetComponent<AudioSource> ();
		jayAnimation = jay.GetComponent<Animation> ();
		jayFFX = jay.GetComponent<FaceFXControllerScript> ();
		jayAudioSource = jay.GetComponent<AudioSource> ();
		setActualAnimations ();

		Invoke ("playAnimation", 2);

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
				sarahLookTarget = "player";
				jayLookTarget = "player";
				jayFFX.PlayAnim (jayAnimationNames [jayIndex], decisionQuestion);
				jayIndex++;
				
			} else {
				sarahAudioSource.clip = decisionQuestion;
				sarahAudioSource.Play ();
				sarahLookTarget = "player";
				jayLookTarget = "player";
				sarahFFX.PlayAnim (sarahAnimationNames [sarahIndex], decisionQuestion);
				sarahIndex++;
			}

			decisionAsked = true;
			
		}

		if (decisionAsked && !decisionMade) {
			StopCoroutine ("playSpeech");
			StartCoroutine ("askForDecision");
		}

		moveSarahHead ();
		moveJayHead ();

		

	}

	IEnumerator askForDecision(){
		if (Input.GetButton ("Fire1")) {
			sarahAudioSource.clip = sarahChoice;
			sarahAudioSource.Play ();
			sarahFFX.PlayAnim (sarahAnimationNames [sarahIndex], sarahChoice);
			sarahLookTarget = "player";
			DecisionManager.chooseHome = true;
			yield return new WaitForSeconds (2f);
			sarahLookTarget = "jay";
			jayLookTarget = "sarah";
		} else if (Input.GetButton ("Fire2")) {
			jayAudioSource.clip = jayChoice;
			jayAudioSource.Play ();
			jayFFX.PlayAnim (jayAnimationNames [jayIndex], jayChoice);
			jayLookTarget = "player";
			DecisionManager.chooseHome = false;
			yield return new WaitForSeconds (1.5f);
			jayLookTarget = "sarah";
			sarahLookTarget = "jay";
		}
	}

	void moveSarahHead(){
		if (sarahLookTarget == "jay") {
			sarahHeadLook.target = jayHead.transform.position;
		} else {
			sarahHeadLook.target = playerHead.transform.position;
		}
	}

	void moveJayHead(){
		if (jayLookTarget == "sarah") {
			jayHeadLook.target = sarahHead.transform.position;
		} else {
			jayHeadLook.target = playerHead.transform.position;
		}
	}

	void setActualAnimations(){
		//Debug.Log (vh1Animation.GetClipCount ());
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
					sarahLookTarget = "jay";
				} else {
					sarahLookTarget = "player";
				}
				jayLookTarget = "sarah";
				yield return new WaitForSeconds (sarahAudioSource.clip.length);

			} else if (currentVH.name == "jay" && jayIndex < jaySpeeches.Length) {
				jayAudioSource.clip = jaySpeeches [jayIndex];
				jayAudioSource.Play ();
				currentVH = sarah;
				jayFFX.PlayAnim(jayAnimationNames[jayIndex], jaySpeeches[jayIndex]);
				jayIndex++;

				if (rand > 0.5f) {
					jayLookTarget = "sarah";
				} else {
					jayLookTarget = "player";
				}
				sarahLookTarget = "jay";
				yield return new WaitForSeconds (jayAudioSource.clip.length);

			} else {
				atDecisionPoint = true;
			}
		}


	}

	bool canTakeTurn(){
		return !sarahAudioSource.isPlaying && !jayAudioSource.isPlaying;
	}

}
