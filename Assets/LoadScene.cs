using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
	public float waitTime;
	public string nextScene;

	// Use this for initialization
	void Start () {
		Invoke ("LoadNextScene", waitTime);
	
	}

	void LoadNextScene(){
		SceneManager.LoadScene (nextScene);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
