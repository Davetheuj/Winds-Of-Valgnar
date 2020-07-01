using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalCamera : MonoBehaviour
{

    public float CameraMoveSpeed = 120.0f;
    public GameObject CameraFollowObject;
    Vector3 followPos;
    public float clampAngle = 80.0f;
    public float inputSensitivity = 150.0f;
    public GameObject CameraObj;
    public GameObject PlayerObj;
    public float camDistXToPlayer;
    public float camDistYToPlayer;
    public float camDistZToPlayer;
    public float mouseX;
    public float mouseY;
  
    public float smoothX;
    public float smoothY;

    private float rotY = 0.0f;
    private float rotX =0.0f;

    private Vector3 rot;


    // Start is called before the first frame update
    void Start()
    {
         rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
       
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)||Input.GetMouseButton(1))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            
            
            mouseX = Input.GetAxisRaw("Mouse X");
            mouseY = Input.GetAxisRaw("Mouse Y");

            rotY += mouseX * inputSensitivity * Time.deltaTime;
            rotX -= mouseY * inputSensitivity/1.2f * Time.deltaTime;

            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

            Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
            transform.rotation = localRotation;

        }//end of hold control
        else
        {
            //Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //transform.rotation = Quaternion.Euler(PlayerObj.transform.localRotation.eulerAngles);
            rot = transform.localRotation.eulerAngles;
            rotY = rot.y;
            //rotX = rot.x;
            //rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl) || Input.GetMouseButtonUp(1))
        {
            Cursor.visible = true;
        }
        }

    void LateUpdate()
    {
        CameraUpdater();


    }

    void CameraUpdater()
    {
        Transform target = CameraFollowObject.transform;

        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
      
        
    }
}
