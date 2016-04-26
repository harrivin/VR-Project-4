using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class EnduranceManager : MonoBehaviour {
	float stamina=500 , maxStamina=500;
	float walkSpeed, runSpeed;
	float staminaf = 1,staminar = 1;
	Rect staminaRect;
	Texture2D staminaTexture;


	FirstPersonController fpc; 

	bool isWalking;
	// Use this for initialization
	void Start () {
		fpc = GameObject.FindObjectOfType<FirstPersonController>();
		walkSpeed = fpc.m_WalkSpeed;
		runSpeed = walkSpeed * 2;
		staminaRect = new Rect (Screen.width/10 , Screen.height/10 , Screen.width/5 , Screen.height/50);
		staminaTexture = new Texture2D (1, 1);
		staminaTexture.SetPixel(0, 0, Color.white);
		staminaTexture.Apply();
	}

	void SetWalking(bool isWalking){
		this.isWalking = isWalking;
		fpc.m_WalkSpeed = isWalking ? walkSpeed : 0;
		fpc.m_RunSpeed = isWalking ? runSpeed : 0;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (stamina);
		if ((Input.GetAxis ("Horizontal") != 0) || (Input.GetAxis ("Vertical") != 0)) { 
			SetWalking (true);
		}
		else if ((Input.GetAxis ("Horizontal") == 0) || (Input.GetAxis ("Vertical") == 0)){
			SetWalking (false);
		}
		if (isWalking) {
			stamina = stamina - staminaf;
		
			if (stamina < 0) {
				stamina = 0;
				SetWalking (false);
					}
			} else if (stamina < maxStamina) {
				stamina = stamina + staminar;
			}
	}

	void OnGUI(){
		float ratio = stamina / maxStamina;
		float rectWidth = ratio * Screen.width / 5;
		staminaRect.width = rectWidth;
		GUI.DrawTexture (staminaRect, staminaTexture);
	}
}
