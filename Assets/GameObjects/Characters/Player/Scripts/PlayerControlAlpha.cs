using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerControlAlpha : MonoBehaviour
{

	public float playerSpeed;
	public float jumpSpeed;
	public CharacterController controller;
	public float gravityScale;
    
    public GameObject camera;
	

	public Vector3 moveDirection;

    public AudioSource audio;

	// Start is called before the first frame update

        void Start()
    {
        audio.Play();
        audio.Pause();
      
        
    }

	// Update is called once per frame
	void Update() //update will run on all units, not just the local ones
	{


        
		// moveDirection = new Vector3(Input.GetAxis("Horizontal") * playerSpeed, moveDirection.y, Input.GetAxis("Vertical")*playerSpeed);

		float yStore = moveDirection.y;

        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetMouseButton(1))
            {
                //camera.transform.rotation = Quaternion.Euler(camera.transform.localRotation.eulerAngles.x, camera.transform.localRotation.eulerAngles.y - 140 * Time.deltaTime, 0);
                transform.rotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y - 140 * Time.deltaTime, 0); //Makes the camera less jittery on character totation.

               
            }
            else
            {
                camera.transform.rotation = Quaternion.Euler(camera.transform.localRotation.eulerAngles.x, camera.transform.localRotation.eulerAngles.y - 140 * Time.deltaTime, 0);
                transform.rotation = Quaternion.Euler(0, camera.transform.localRotation.eulerAngles.y, 0);
            }
            moveDirection = (transform.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetMouseButton(1))
            {
                //camera.transform.rotation = Quaternion.Euler(camera.transform.localRotation.eulerAngles.x, camera.transform.localRotation.eulerAngles.y - 140 * Time.deltaTime, 0);
                transform.rotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y + 140 * Time.deltaTime, 0); //Makes the camera less jittery on character totation.


            }
            else
            {
                camera.transform.rotation = Quaternion.Euler(camera.transform.localRotation.eulerAngles.x, camera.transform.localRotation.eulerAngles.y + 140 * Time.deltaTime, 0);
                transform.rotation = Quaternion.Euler(0, camera.transform.localRotation.eulerAngles.y, 0);
            }
            moveDirection = (transform.forward);
        }

        if (Input.GetMouseButton(1) && Input.GetMouseButton(0)) // allows for players to move with just mouse buttons so they can free up left hand
        {
            transform.rotation = Quaternion.Euler(0, camera.transform.localRotation.eulerAngles.y, 0);
            moveDirection = (transform.forward);
        }
        else
        {

            moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")); //+ (transform.right * Input.GetAxisRaw("Horizontal"));
        }
		moveDirection = moveDirection.normalized * playerSpeed; //normalization so axis aren't added outright (for cheaters like SEAN)

		moveDirection.y = yStore;

		if (controller.isGrounded)
		{
			moveDirection.y = 0;
			if (Input.GetButtonDown("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
            if((Mathf.Abs(moveDirection.x) >0 || Mathf.Abs(moveDirection.z) > 0) && !audio.isPlaying)
            {
                
                audio.UnPause();
                Debug.Log("Playing walking audio");
            }
            else
            {
                if (audio.isPlaying)
                {
                    Debug.Log("Stopping walking audio");
                    audio.Pause();
                }
            }
		}
       

        moveDirection.y = moveDirection.y + Physics.gravity.y * gravityScale * Time.deltaTime;
        Debug.Log($"Move: {moveDirection * Time.deltaTime}");
        
		controller.Move(moveDirection * Time.deltaTime);
        
	}
}
