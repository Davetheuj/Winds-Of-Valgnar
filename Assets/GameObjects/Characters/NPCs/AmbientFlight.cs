using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientFlight : MonoBehaviour
{
    private Vector3 initLocation;
    private Vector3 moveDirection;
    private float time;
    public float speed;
    public float roamRadius;

    void Start()
    {
        initLocation = gameObject.transform.position;
        moveDirection = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= moveDirection * speed * Time.deltaTime * (Mathf.Sin(time)/2 + .5f);
        time += Time.deltaTime;
        if (time > 5) {
            if ((transform.position - initLocation).magnitude > roamRadius)
            {
                gameObject.transform.LookAt(new Vector3(initLocation.x + Random.value*3, initLocation .y, initLocation.z + Random.value *3));
                gameObject.transform.Rotate(new Vector3(0, 1, 0), 180);
                moveDirection = transform.forward;

            }

                time = 0;
                    }

    }
}
