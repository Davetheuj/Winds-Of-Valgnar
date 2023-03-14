using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{

    public bool isGrounded;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            Debug.Log("Hit floor!");
            isGrounded = true;
        }
     
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Left Floor!");
            isGrounded = false;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody>().velocity=(new Vector3(0, 10, 0));
        }
    }
}
