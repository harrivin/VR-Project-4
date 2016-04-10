using UnityEngine;
using System.Collections;

public class SkyboxController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	void Start()
	{
		//offset = transform.position - player.transform.position;

		offset = new Vector3(1.0f, 0.0f, 1.0f);
	}

	void LateUpdate()
	{
		//transform.position = player.transform.position + offset;
		transform.position = Vector3.Scale(player.transform.position,offset);
	}
}
