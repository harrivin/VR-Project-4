using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoctorSpeechController : MonoBehaviour {

	public AudioClip[] doctorSpeeches;
	string[] animationNames;
	Animation docAnimation;
	AudioSource docAudioSource;
	FaceFXControllerScript docFFX;

	public GameObject[] maleCharacters;
	public GameObject[] femaleCharacters;

	public AnimationClip[] talkAnimations;

	GameObject playerHead;

	HeadLookController docHeadLook;

	public GameObject currentAvatar; 

	// Use this for initialization
	void Start () {
		docAnimation = this.gameObject.GetComponent<Animation> ();
		docAudioSource = this.gameObject.GetComponent<AudioSource> ();
		docFFX = this.gameObject.GetComponent<FaceFXControllerScript> ();

		List<string> temp = new List<string> ();
		foreach(AnimationState state in docAnimation)
		{
			if (state.name.Contains ("Default")) {
				//Debug.Log (state.name);
				temp.Add (state.name);
			}
		}

		animationNames = temp.ToArray ();


		playerHead = GameObject.FindGameObjectWithTag ("playerHead");
		docHeadLook = this.gameObject.GetComponent<HeadLookController> ();

		StartCoroutine ("playSpeech");
		StartCoroutine ("playAnimation");


		if (DecisionManager.gender == "female") {
			Debug.Log ("is female");
			currentAvatar.SetActive (false);
			femaleCharacters [0].SetActive (true);
			femaleCharacters[0].transform.position = currentAvatar.transform.position;
			currentAvatar = femaleCharacters [0];
		}
	}

	void Update(){
		docHeadLook.target = playerHead.transform.position;
	}

	int rand2;
	IEnumerator playAnimation(){
		rand2 = Random.Range (0, 5);
		yield return new WaitForSeconds ((float)rand2);
		rand2 = Random.Range (0, talkAnimations.Length);
		if(rand2 < talkAnimations.Length){
			Debug.Log ("play animation");
			docAnimation.clip = talkAnimations [rand2];
			docAnimation.Play ();
		}
		rand2 = Random.Range (5,10);
		yield return new WaitForSeconds ((float)rand2);
		rand2 = Random.Range (0, talkAnimations.Length);
		if(rand2 < talkAnimations.Length){
			Debug.Log ("play animation");
			docAnimation.clip = talkAnimations [rand2];
			docAnimation.Play ();
		}
		rand2 = Random.Range (10,15);
		yield return new WaitForSeconds ((float)rand2);
		rand2 = Random.Range (0, talkAnimations.Length);
		if(rand2 < talkAnimations.Length){
			Debug.Log ("play animation");
			docAnimation.clip = talkAnimations [rand2];
			docAnimation.Play ();
		}
		rand2 = Random.Range (15, 20);
		yield return new WaitForSeconds ((float)rand2);
		rand2 = Random.Range (0, talkAnimations.Length);
		if(rand2 < talkAnimations.Length){
			Debug.Log ("play animation");
			docAnimation.clip = talkAnimations [rand2];
			docAnimation.Play ();
		}
		rand2 = Random.Range (20, 25);
		yield return new WaitForSeconds ((float)rand2);
		rand2 = Random.Range (0, talkAnimations.Length);
		if(rand2 < talkAnimations.Length){
			Debug.Log ("play animation");
			docAnimation.clip = talkAnimations [rand2];
			docAnimation.Play ();
		}


	}
	

	IEnumerator playSpeech(){
		yield return new WaitForSeconds (0.5f);
		
		if (DecisionManager.chooseHome) {
			if (DecisionManager.chooseGroceryStore) {
				docAudioSource.clip = doctorSpeeches [0];
				docAudioSource.Play ();
				docFFX.PlayAnim(animationNames[0], doctorSpeeches [0]);
				DecisionManager.predictedFuture = "good";
				yield return new WaitForSeconds (37f);
				if (isFemale ()) {
					currentAvatar.SetActive (false);
					femaleCharacters [1].SetActive (true);
					femaleCharacters [1].transform.position = currentAvatar.transform.position;
					currentAvatar = femaleCharacters [1];
				} else {
					currentAvatar.SetActive (false);
					maleCharacters [1].SetActive (true);
					maleCharacters [1].transform.position = currentAvatar.transform.position;
					currentAvatar = maleCharacters [1];
				}
				
			} else {
				docAudioSource.clip = doctorSpeeches [1];
				docAudioSource.Play ();
				docFFX.PlayAnim(animationNames[1], doctorSpeeches [1]);
				DecisionManager.predictedFuture = "ok";
				yield return new WaitForSeconds (35f);
				if (isFemale ()) {
					currentAvatar.SetActive (false);
					femaleCharacters [2].SetActive (true);
					femaleCharacters [2].transform.position = currentAvatar.transform.position;
					currentAvatar = femaleCharacters [2];
				} else {
					currentAvatar.SetActive (false);
					maleCharacters [2].SetActive (true);
					maleCharacters [2].transform.position = currentAvatar.transform.position;
					currentAvatar = maleCharacters [2];
				}
			}
		} else {
			if (DecisionManager.chooseGroceryStore) {
				docAudioSource.clip = doctorSpeeches [2];
				docAudioSource.Play ();
				docFFX.PlayAnim(animationNames[2], doctorSpeeches [2]);
				DecisionManager.predictedFuture = "ok";
				yield return new WaitForSeconds (33f);
				if (isFemale ()) {
					currentAvatar.SetActive (false);
					femaleCharacters [2].SetActive (true);
					femaleCharacters [2].transform.position = currentAvatar.transform.position;
					currentAvatar = femaleCharacters [2];
				} else {
					currentAvatar.SetActive (false);
					maleCharacters [2].SetActive (true);
					maleCharacters [2].transform.position = currentAvatar.transform.position;
					currentAvatar = maleCharacters [2];
				}
				
			} else {
				docAudioSource.clip = doctorSpeeches [3];
				docAudioSource.Play ();
				docFFX.PlayAnim(animationNames[3], doctorSpeeches [3]);
				DecisionManager.predictedFuture = "bad";

				yield return new WaitForSeconds (42f);
				if (isFemale ()) {
					currentAvatar.SetActive (false);
					femaleCharacters [2].SetActive (true);
					femaleCharacters [2].transform.position = currentAvatar.transform.position;
					currentAvatar = femaleCharacters [2];
				} else {
					currentAvatar.SetActive (false);
					maleCharacters [2].SetActive (true);
					Debug.Log (maleCharacters [2].name);
					maleCharacters [2].transform.position = currentAvatar.transform.position;
					currentAvatar = maleCharacters [2];
				}
			}
		}
	}


			bool isFemale(){
				return DecisionManager.gender == "female";
			}
}
