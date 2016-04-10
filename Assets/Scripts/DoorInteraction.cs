using UnityEngine;
using System.Collections;
//using VRStandardAssets.Utils;

public class DoorInteraction : MonoBehaviour {

	public GameObject player;
	public GameObject textOpen, textLocked;
	public AudioSource sound;

	private int wait;

	void Start () 
	{
	
	}
	

	public void Update () 
	{
		/*if (IsOver) {
			text.SetActive (true);
		} else {
			text.SetActive (false);
		}*/

		if (Time.frameCount - wait > 100) 
		{
			textLocked.SetActive (false);
		}

		if (Vector3.Distance (player.transform.position, transform.position) < 10) {

			if (textLocked.activeSelf == false) {
				textOpen.SetActive (true);
			} else 
			{
				textOpen.SetActive (false);
			}

			if (Input.GetKeyDown ("t")) 
			{
				sound.Play ();
				textOpen.SetActive (false);
				textLocked.SetActive (true);
				wait = Time.frameCount;
			}

		} else {
			textOpen.SetActive (false);
		}
	}
}
