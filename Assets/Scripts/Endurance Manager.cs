//using UnityEngine;
//using System.Collections;
//
//public class EnduranceManager : MonoBehaviour {
//	float stamina=5, maxStamina=5;
//	FPSController fpc;
//
//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//}


//using UnityEngine;
//using System.Collections;
//
//public class Sprinter : MonoBehaviour {
//	float stamina=5, maxStamina=5;
//	float walkSpeed, runSpeed;
//	//CharacterMotor cm;
//	bool isRunning;
//
//	Rect staminaRect;
//	Texture2D staminaTexture;
//
//	// Use this for initialization
//	void Start () {
//		cm = gameObject.GetComponent<CharacterMotor> ();
//		walkSpeed = cm.movement.maxForwardSpeed;
//		runSpeed = walkSpeed * 4;
//
//		staminaRect = new Rect (Screen.width / 10, Screen.height * 9 / 10,
//			Screen.width / 3, Screen.height / 50);
//		staminaTexture = new Texture2D (1, 1);
//		staminaTexture.SetPixel (0, 0, Color.white);
//		staminaTexture.Apply ();
//	}
//
//	void SetRunning(bool isRunning)
//	{
//		this.isRunning = isRunning;
//		cm.movement.maxForwardSpeed = isRunning ? runSpeed : walkSpeed;
//	}
//
//	// Update is called once per frame
//	void Update () {
//		if (Input.GetKeyDown (KeyCode.LeftShift))
//			SetRunning (true);
//		if (Input.GetKeyUp (KeyCode.LeftShift))
//			SetRunning (false);
//
//		if (isRunning) {
//			stamina -= Time.deltaTime;
//			if (stamina < 0) {
//				stamina = 0;
//				SetRunning (false);
//			}
//		} 
//		else if (stamina < maxStamina) 
//		{
//			stamina += Time.deltaTime;
//		}
//
//	}
//
//	void OnGUI()
//	{
//		float radio = stamina / maxStamina;
//		float rectWidth = ratio * Screen.width / 3;
//		staminaRect.width = rectWidth;
//		GUI.DrawTexture (staminaRect, staminaTexture);
//	}
//
//}﻿