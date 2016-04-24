using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CharacterSpeakingController2 : MonoBehaviour {


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

		//Invoke ("playAnimation", 2);

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
			
			jayAudioSource.clip = decisionQuestion;
			jayAudioSource.Play ();
			sarahLookTarget = "player";
			jayLookTarget = "player";
			jayFFX.PlayAnim (jayAnimationNames [jayIndex], decisionQuestion);
			jayIndex++;
			decisionAsked = true;

		}

		if (decisionAsked && !decisionMade) {
			StopCoroutine ("playSpeech");
			StartCoroutine ("askForDecision");
		}

		moveSarahHead ();
		moveJayHead ();

		if (decisionMade) {
			StopCoroutine ("askForDecision");
			StartCoroutine ("loadNextScene");
		}

	}

	IEnumerator askForDecision(){
		if (Input.GetButton ("Fire1")) {
			sarahAudioSource.clip = sarahChoice;
			sarahAudioSource.Play ();
			sarahFFX.PlayAnim (sarahAnimationNames [sarahIndex], sarahChoice);
			sarahLookTarget = "player";
			DecisionManager.chooseGroceryStore = false;
			yield return new WaitForSeconds (2f);
			sarahLookTarget = "jay";
			jayLookTarget = "sarah";
			decisionMade = true;
		} else if (Input.GetButton ("Fire2")) {
			jayAudioSource.clip = jayChoice;
			jayAudioSource.Play ();
			jayFFX.PlayAnim (jayAnimationNames [jayIndex], jayChoice);
			jayLookTarget = "player";
			DecisionManager.chooseGroceryStore = true;
			yield return new WaitForSeconds (1.5f);
			jayLookTarget = "sarah";
			sarahLookTarget = "jay";
			decisionMade = true;
		}
	}

	IEnumerator loadNextScene(){
		if (DecisionManager.chooseHome) {
			Debug.Log ("moving to next house scene");
			yield return new WaitForSeconds (10f);
			SceneManager.LoadScene ("stevieHouse2");
		} else {
			yield return new WaitForSeconds (6f);
			SceneManager.LoadScene ("stevieBuildings");
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
				bool longSpeech = sarahAnimationNames [sarahIndex].Contains ("whats_coming");
				sarahAudioSource.clip = sarahSpeeches [sarahIndex];
				sarahAudioSource.Play ();
				currentVH = jay;
				sarahFFX.PlayAnim(sarahAnimationNames[sarahIndex], sarahSpeeches[sarahIndex]);
				sarahIndex++;
				if (rand > 0.5f & !longSpeech) {
					sarahLookTarget = "player";
				} else {
					sarahLookTarget = "jay";
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
