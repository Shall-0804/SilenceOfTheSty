using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController_Motor : MonoBehaviour {

	[SerializeField] float normalspeed = 3.0f;
    float sprintSpeed = 7f;
    [SerializeField] float sensitivity = 30.0f;
    [SerializeField] float WaterHeight = 15.5f;
	CharacterController character;
    [SerializeField] GameObject cam;
	float moveFB, moveLR;
	float rotX, rotY;
    [SerializeField] bool webGLRightClickRotation = true;
	float gravity = -9.8f;
	[SerializeField] Animator PlayerAnimation;

	void Start()
	{
        // マウスカーソルを非表示にし、位置を固定
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;



        //LockCursor ();
        character = GetComponent<CharacterController> ();
		if (Application.isEditor) {
			webGLRightClickRotation = false;
			sensitivity = sensitivity * 1.5f;
		}
	}


	void CheckForWaterHeight(){
		if (transform.position.y < WaterHeight) {
			gravity = 0f;			
		} else {
			gravity = -9.8f;
		}
	}



	void Update(){

        float speed = Input.GetKey(KeyCode.LeftControl) ? sprintSpeed : normalspeed;

        moveFB = Input.GetAxis ("Horizontal") * speed;
		moveLR = Input.GetAxis ("Vertical") * speed;

		rotX = Input.GetAxis ("Mouse X") * sensitivity;
		rotY = Input.GetAxis ("Mouse Y") * sensitivity;

		//rotX = Input.GetKey (KeyCode.Joystick1Button4);
		//rotY = Input.GetKey (KeyCode.Joystick1Button5);

		CheckForWaterHeight ();

       

        Vector3 movement = new Vector3 (moveFB, gravity, moveLR);



		if (webGLRightClickRotation) {
			if (Input.GetKey (KeyCode.Mouse0)) {
				CameraRotation (cam, rotX, rotY);
			}
		} else if (!webGLRightClickRotation) {
			CameraRotation (cam, rotX, rotY);
		}

		movement = transform.rotation * movement;
		character.Move (movement * Time.deltaTime);


		PlayerAnimation.SetFloat("Work", (moveFB + moveLR));

        

    }


	void CameraRotation(GameObject cam, float rotX, float rotY){		
		transform.Rotate (0, rotX * Time.deltaTime, 0);
		cam.transform.Rotate (-rotY * Time.deltaTime, 0, 0);
	}




}
