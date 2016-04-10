using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float forwardSpeed, horizontalSpeed;
//	public GameObject jumpText, launchPad, launchPlane, boat, parachuteText, rings;
	public AudioSource walking; 

	private Rigidbody rb;
//	private bool isFlying = false;
//	private bool parachute = false;
//	private bool canJump = true;
	//private int wait;

	Vector3 limiter = new Vector3(1.0f, 0.0f, 1.0f);
//	Vector3 simGrav = new Vector3(0.0f,-.1f,0.0f);

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		//rings.SetActive (false);
	}

	void FixedUpdate()
	{
//		if (Time.frameCount - wait > 15) 
//		{
//			canJump = true;
//		}
//
//		if (!isFlying && !parachute) {
//
		if ((Input.GetKey ("w") || Input.GetKey ("a") || Input.GetKey ("s") || Input.GetKey ("d")||Input.GetAxis("Vertical")!=0.0f || Input.GetAxis("Horizontal")!=0.0f)&& !walking.isPlaying) 
			{
				walking.Play ();
			}

			//rb.MovePosition (transform.position + new Vector3 (-Input.GetAxis ("Horizontal") * horizontalSpeed, 0.0f, -Input.GetAxis ("Vertical") * forwardSpeed));
			//rb.transform.rotation.y = Camera.main.transform.rotation.y;
		//rb.MovePosition (transform.position + Vector3.Scale (Camera.main.transform.right, limiter)* Input.GetAxis ("Horizontal") * horizontalSpeed);
		//Debug.Log ("Current psotition"+transform.position);
		//Debug.Log( "New position"+(transform.position + Vector3.Scale (Camera.main.transform.right, limiter)* Input.GetAxis ("Horizontal") * horizontalSpeed));
			
			//rb.MovePosition (transform.position + Vector3.Scale (Camera.main.transform.forward, limiter) * Input.GetAxis ("Horizontal") * horizontalSpeed);
		rb.MovePosition (transform.position + Vector3.Scale (Camera.main.transform.forward, limiter) * Input.GetAxis ("Vertical") * forwardSpeed+Vector3.Scale (Camera.main.transform.right, limiter)* Input.GetAxis ("Horizontal") * horizontalSpeed);
		} 

//		if(isFlying) 
//		{
//			//rb.MovePosition (transform.position + Vector3.Scale (Camera.main.transform.right, limiter) * Input.GetAxis ("Horizontal") * horizontalSpeed);
//			rb.MovePosition ((transform.position  + Vector3.Scale (Camera.main.transform.forward, limiter) * 4 * forwardSpeed) + simGrav);
//		}
//
//		if (parachute) 
//		{
//			
//			Vector3 between = boat.transform.position - transform.position;
//			rb.MovePosition (transform.position + between*Time.deltaTime*parachuteSpeed);
//
//			if (Vector3.Distance(transform.position,boat.transform.position) < 1) 
//			{
//				parachute = false;
//				landing.Play ();
//			}
//		}
//
//		if(Input.GetKeyDown("space")&& canJump)
//		{
//			rb.MovePosition(transform.position + transform.up *jumpSpeed *Time.deltaTime);
//			canJump = false;
//			wait = Time.frameCount;
//		}
//
//		if (Vector3.Distance (transform.position, launchPad.transform.position) < 2) 
//		{
//			if (!isFlying) 
//			{
//				jumpText.SetActive (true);
//			}
//
//			if (Input.GetKeyDown ("t") && !isFlying) 
//			{
//				isFlying = true;
//				launchPlane.SetActive (false);
//				rings.SetActive(true);
//				jumpText.SetActive (false);
//				rb.useGravity = false;
//				wind.volume = 1.0f;
//			}
//
//		} else 
//		{
//			jumpText.SetActive (false);
//		}
//
//		if (isFlying || parachute) 
//		{
//			wind.volume = wind.volume - 0.00022f;
//		}
//
//		if (Vector3.Distance (transform.position, boat.transform.position) < 300) 
//		{
//			if (!parachute) 
//			{
//				parachuteText.SetActive (true);
//			} 
//			if(Input.GetKeyDown("t") && !parachute && isFlying) 
//			{
//				parachute = true;
//				isFlying = false;
//				parachuteText.SetActive (false);
//			}
//
//
//		} 
//		else 
//		{
//			parachuteText.SetActive (false);
//		}
//	}

}