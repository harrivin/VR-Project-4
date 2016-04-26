using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSpeakingController : MonoBehaviour {


	public GameObject sarah, jay;
	public AudioClip[] sarahSpeeches, jaySpeeches;
	AudioSource sarahAudioSource, jayAudioSource;
	string[] sarahAnimationNames, jayAnimationNames;
	Animation sarahAnimation, jayAnimation;
	public FaceFXControllerScript sarahFFX, jayFFX;

	public Image x;
	public Image a;
	public Text home;
	public Text goout;

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
	public AnimationClip[] idleAnimations;

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

		for (int i = 0; i < talkingAnimations.Length; i++){
			sarahAnimation.AddClip (talkingAnimations [i], talkingAnimations [i].name);
			jayAnimation.AddClip (talkingAnimations [i], talkingAnimations [i].name);
		}
		for (int i = 0; i < idleAnimations.Length; i++) {
			sarahAnimation.AddClip (idleAnimations [i], idleAnimations [i].name);
			jayAnimation.AddClip (idleAnimations [i], idleAnimations [i].name);
		}


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

		if (decisionMade) {
			StopCoroutine ("askForDecision");
			StartCoroutine ("loadNextScene");
		}

	}

	IEnumerator askForDecision(){
		x.gameObject.SetActive (true);
		a.gameObject.SetActive (true);
		home.gameObject.SetActive (true);
		goout.gameObject.SetActive (true);
		if (Input.GetButton ("Fire1")) {
			sarahAudioSource.clip = sarahChoice;
			sarahAudioSource.Play ();
			sarahFFX.PlayAnim (sarahAnimationNames [sarahIndex], sarahChoice);
			sarahLookTarget = "player";
			DecisionManager.chooseHome = true;
			yield return new WaitForSeconds (2f);
			sarahLookTarget = "jay";
			jayLookTarget = "sarah";
			decisionMade = true;
			x.gameObject.SetActive (false);
			a.gameObject.SetActive (false);
			home.gameObject.SetActive (false);
			goout.gameObject.SetActive (false);
		} else if (Input.GetButton ("Fire2")) {
			jayAudioSource.clip = jayChoice;
			jayAudioSource.Play ();
			jayFFX.PlayAnim (jayAnimationNames [jayIndex], jayChoice);
			jayLookTarget = "player";
			DecisionManager.chooseHome = false;
			yield return new WaitForSeconds (1.5f);
			jayLookTarget = "sarah";
			sarahLookTarget = "jay";
			decisionMade = true;
			x.gameObject.SetActive (false);
			a.gameObject.SetActive (false);
			home.gameObject.SetActive (false);
			goout.gameObject.SetActive (false);
		}
	}

	IEnumerator loadNextScene(){
		if (DecisionManager.chooseHome) {
			Debug.Log ("moving to next house scene");
			yield return new WaitForSeconds (10f);
			SceneManager.LoadScene ("stevieHouse2");
		} else {
			yield return new WaitForSeconds (6f);
			SceneManager.LoadScene ("stevieBuilding2");
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
		int rand2;
		if (!atDecisionPoint & !decisionMade) {
			//Debug.Log ("playing speech of " + currentVH.name);
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

				rand2 = Random.Range (0, talkingAnimations.Length+1);
				if(rand2 < talkingAnimations.Length){
					//Debug.Log ("play talking animation");
					sarahAnimation.clip = talkingAnimations [rand2];
					sarahAnimation.Play ();
				}

				if (rand2 != 0) {
					Invoke ("playJayIdleAnimation", (float)rand2 * 2);
				} else {
					Invoke ("playJayIdleAnimation", 3f);
				}

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

				rand2 = Random.Range (0, talkingAnimations.Length+1);
				if(rand2 < talkingAnimations.Length){
					Debug.Log ("play talking animation");
					jayAnimation.clip = talkingAnimations [rand2];
					jayAnimation.Play ();
				}

				if (rand2 != 0) {
					Invoke ("playSarahIdleAnimation", (float)rand2 * 2);
				} else {
					Invoke ("playSarahIdleAnimation", 3f);
				}

				yield return new WaitForSeconds (jayAudioSource.clip.length);

			} else {
				atDecisionPoint = true;
			}
		}


	}

	void playJayIdleAnimation(){
		int rand2 = Random.Range (0, idleAnimations.Length+1);
		if(rand2 < idleAnimations.Length){
			jayAnimation.clip = idleAnimations [rand2];
			jayAnimation.Play ();
		}
	}

	void playSarahIdleAnimation(){
		int rand2 = Random.Range (0, idleAnimations.Length+1);
		if(rand2 < idleAnimations.Length){
			sarahAnimation.clip = idleAnimations [rand2];
			sarahAnimation.Play ();
		}
	}

	bool canTakeTurn(){
		return !sarahAudioSource.isPlaying && !jayAudioSource.isPlaying;
	}

}
