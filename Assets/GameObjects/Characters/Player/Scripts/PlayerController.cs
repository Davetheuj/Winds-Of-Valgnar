using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed;
    public float jumpSpeed;
    public CharacterController controller;
    public float gravityScale;

    public GameObject mainCamera;


    public Vector3 moveDirection;

    public AudioSource audio;

    private bool canJump = false;
    private float audioDelay;
    [SerializeField]
    private float audioDelayModifier;
    private float audioTimer;

    public float clampAngle = 80.0f;
    public float inputSensitivity = 150.0f;

    public float mouseX;
    public float mouseY;

    private float rotY = 0.0f;
    private float rotX = 0.0f;

    private Vector3 rot;

    bool canRotate = true;

    // Start is called before the first frame update

    void Start()
    {
        audio.Play();
        audio.Pause();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;


    }


    void Update()
    {

        float yStore = moveDirection.y; //get this from the old Update's moveDirection so we can continue to accelerate
        moveDirection = new Vector3(0, yStore, 0);

        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMouseRestriction();
        }

        else
        {
            if (canRotate)
            {
                mouseX = Input.GetAxis("Mouse X");
                mouseY = Input.GetAxis("Mouse Y");

                rotY += mouseX * inputSensitivity * Time.deltaTime;
                rotX -= mouseY * inputSensitivity / 1.2f * Time.deltaTime;

                rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

                Quaternion localRotation = Quaternion.Euler(0, rotY, 0.0f);
                transform.rotation = localRotation;
                mainCamera.transform.rotation = Quaternion.Euler(rotX, rotY, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1 * transform.right;
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveDirection = transform.right;
            }
            if ((Input.GetMouseButton(1) && Input.GetMouseButton(0)) || Input.GetKey(KeyCode.W)) // allows for players to move with just mouse buttons so they can free up left hand
            {
                moveDirection = (transform.forward);
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveDirection = -1 * transform.forward;
            }
        }


        moveDirection = moveDirection.normalized * playerSpeed; //normalization so axis aren't added outright (for cheaters like SEAN)

        moveDirection.y = yStore;

        if (controller.isGrounded && !canJump)
        {
            canJump = true;
        }

        if (canJump)
        {
            //moveDirection.y = 0;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
                canJump = false;
            }
            audioDelay = audioDelayModifier / playerSpeed;
            if ((Mathf.Abs(moveDirection.x) > .1f || Mathf.Abs(moveDirection.z) > .1f) && !audio.isPlaying && (audioTimer >= audioDelay))
            {

                audio.Play();
                audioTimer = 0;
                ////Debug.Log("Playing walking audio");
            }

        }


        moveDirection.y = Mathf.Clamp(moveDirection.y + Physics.gravity.y * gravityScale * Time.deltaTime, -100, 100);
        // //Debug.Log($"Move: {moveDirection * Time.deltaTime}");

        controller.Move(moveDirection * Time.deltaTime);
        audioTimer += Time.deltaTime;

        

    }

    public void ToggleMouseRestriction()
    {
        Cursor.visible = !Cursor.visible;
        if (Cursor.lockState == CursorLockMode.Confined)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        canRotate = !canRotate;
    }

    
    






}
