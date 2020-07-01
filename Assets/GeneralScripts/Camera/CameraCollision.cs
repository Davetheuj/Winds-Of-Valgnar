using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 30;
    Vector3 dollyDir;
    public Vector3 dollyDirAdjusted;
    public float distance;


    // Start is called before the first frame update
    void Awake()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        maxDistance -= Input.GetAxisRaw("Mouse ScrollWheel")*2;
        maxDistance = Mathf.Clamp(maxDistance, minDistance + .01f,100);

        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);

        RaycastHit hit;

        if (Physics.Linecast(transform.parent.position, desiredCameraPos + (desiredCameraPos - transform.parent.position)/4, out hit))
        {
            distance = Mathf.Clamp((hit.distance * .3f), minDistance,maxDistance);
        }
        else
        {
            distance = maxDistance;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
        
    }
}
