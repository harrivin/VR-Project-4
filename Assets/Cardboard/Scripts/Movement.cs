using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

//	public float RotationSpeed = 180;
//	private bool sound = false;
//	public AudioSource footstep;
//	private bool secondworld = false;
//	public GameObject pointlight, dn, de, ds, dw;
//	private Light lpl, ldn, lde, lds, ldw;
//	public GameObject rooster;
	public float forwardSpeed, horizontalSpeed;
	private Rigidbody rb;
	Vector3 limiter = new Vector3(1.0f, 0.0f, 1.0f);

	void Start(){
		rb.GetComponent<Rigidbody> ();
	}

	void Update () {
		Move ();
		//Adjustment ();
		//Footsound ();
//		if (secondworld == false) {
//			EnterSecond ();
//		}
	}

	void Move () {
//		transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed);
//		transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed, 0, 0);
//		transform.Rotate(Input.GetAxis("LookUp") * Time.deltaTime * RotationSpeed, 0, 0);
//		transform.Rotate(0, Input.GetAxis("RightStick") * Time.deltaTime * RotationSpeed, 0);
		//rb.MovePosition (transform.position + Vector3.Scale (Camera.main.transform.right, limiter) * Input.GetAxis ("Horizontal") * horizontalSpeed);
		//rb.MovePosition (transform.position + Vector3.Scale (Camera.main.transform.forward, limiter) * Input.GetAxis ("Horizontal") * horizontalSpeed);
		//rb.MovePosition (transform.position + Vector3.Scale (Camera.main.transform.forward, limiter) * Input.GetAxis ("Vertical") * forwardSpeed);
		Vector3.Scale (Camera.main.transform.right, limiter);
	}
//
//	void Adjustment () {
//		if (secondworld == false) {
//			transform.position = new Vector3 (
//				Mathf.Clamp (transform.position.x, -20f, 66f),
//				transform.position.y,
//				Mathf.Clamp (transform.position.z, -570f, -530f)
//			);
//		}
//		if (secondworld == true) {
//			transform.position = new Vector3 (
//				Mathf.Clamp (transform.position.x, -400f, 400f),
//				transform.position.y,
//				Mathf.Clamp (transform.position.z, -400f, 400f)
//			);
//		}
//	}
//
//	void Footsound () {
//		if ((sound==false) && ((Input.GetAxis("Vertical")!=0)||(Input.GetAxis("Horizontal")!=0))) {
//			footstep.Play ();
//			sound = true;
//		}
//		if ((sound==true) && ((Input.GetAxis("Vertical")==0)&&(Input.GetAxis("Horizontal")==0))) {
//			footstep.Stop ();
//			sound = false;
//		}
//	}
//
//	void EnterSecond () {
//		if ((secondworld==false) && (transform.position.x==66f)) {
//			secondworld = true;
//			transform.position = new Vector3 (-380f, 60f, -380f); //camera height
//			StartCoroutine (Tosecond ());
//		}
//	}
//
//	IEnumerator Tosecond () {
//		lpl = pointlight.GetComponents<Light> ()[0];
//		lpl.intensity = 8f;
//		ldn = dn.GetComponents<Light> ()[0];
//		ldn.intensity = 3.3f;
//		lde = de.GetComponents<Light> ()[0];
//		lde.intensity = 3.3f;
//		lds = ds.GetComponents<Light> ()[0];
//		lds.intensity = 3.3f;
//		ldw = dw.GetComponents<Light> ()[0];
//		ldw.intensity = 3.3f;
//		yield return new WaitForSeconds (1f);
//		rooster.GetComponent<AudioSource> ().Play ();
//		for (int i=0; i<56; i++) {
//			yield return new WaitForSeconds (0.05f);
//			lpl.intensity -= 0.1f;
//			ldn.intensity -= 0.05f;
//			lde.intensity -= 0.05f;
//			lds.intensity -= 0.05f;
//			ldw.intensity -= 0.05f;
//		}
//	}
}
