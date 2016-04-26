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

		Invoke ("playSpeech",0.5f);
		StartCoroutine ("playAnimation");
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
	

	void playSpeech(){
		
		if (DecisionManager.chooseHome) {
			if (DecisionManager.chooseGroceryStore) {
				docAudioSource.clip = doctorSpeeches [0];
				docAudioSource.Play ();
				docFFX.PlayAnim(animationNames[0], doctorSpeeches [0]);
				DecisionManager.predictedFuture = "good";
				
			} else {
				docAudioSource.clip = doctorSpeeches [1];
				docAudioSource.Play ();
				docFFX.PlayAnim(animationNames[1], doctorSpeeches [1]);
				DecisionManager.predictedFuture = "ok";
			}
		} else {
			if (DecisionManager.chooseGroceryStore) {
				docAudioSource.clip = doctorSpeeches [2];
				docAudioSource.Play ();
				docFFX.PlayAnim(animationNames[2], doctorSpeeches [2]);
				DecisionManager.predictedFuture = "ok";
				
			} else {
				docAudioSource.clip = doctorSpeeches [3];
				docAudioSource.Play ();
				docFFX.PlayAnim(animationNames[3], doctorSpeeches [3]);
				DecisionManager.predictedFuture = "bad";
			}
		}
	}
}
