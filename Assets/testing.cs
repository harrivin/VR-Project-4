using UnityEngine;
using System.Collections;


public class testing : MonoBehaviour {
	public static int x;
	// Use this for initialization
	void Start () {
		int x = 1;
		print ("testing");
	}

	void Awake(){
		DontDestroyOnLoad (this);
		int x = 1;
		print ("testing1");
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
