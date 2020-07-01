using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class ExplosionScript : MonoBehaviour
{
    public Vector3 collisionLocation;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        transform.SetPositionAndRotation(collisionLocation, new Quaternion(0, 0, 0, 0));
    }
    void LateStart()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.localScale *= .9f;
        if (time > 3)
        {
            Destroy(gameObject);
        }
        
    }
}
