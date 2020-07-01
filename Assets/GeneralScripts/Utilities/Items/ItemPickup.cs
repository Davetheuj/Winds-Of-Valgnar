using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Transform target { get; set; }
    private bool hasArrived = false;
    public bool isStarted { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        isStarted = false;
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted) {
           
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target.position, .3f);
                gameObject.transform.Rotate(new Vector3(0, 1, 0), 1000 * Time.deltaTime);
            gameObject.transform.localScale = gameObject.transform.localScale / 1.1f;
            if ((gameObject.transform.position - target.position).magnitude < .1f)
                {
                    Debug.Log("Object has reached target. destroying.");
                    Destroy(gameObject);
                }

                
            
        }
        
    }

  
}
