using UnityEngine;
using System.Collections;

public class WindLoop : MonoBehaviour {

	public AudioSource wind;

	void Start () 
	{
		wind.Play ();
	}

	void Update () 
	{
		if (wind.time >= 10) 
		{
			wind.Stop ();
			wind.Play ();
		}
	}
}
