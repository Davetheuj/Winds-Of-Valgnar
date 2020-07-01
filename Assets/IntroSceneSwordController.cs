using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSceneSwordController : MonoBehaviour
{

    public float yEnd;
    public float yStart;
    public float speed;
    public float scale;
    private Transform transform;
    private float time;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        transform = this.gameObject.transform;
        transform.position = new Vector3(transform.position.x, yStart, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (transform.position.y > yEnd && (time >= startTime))
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y,yEnd,speed*Time.deltaTime ), transform.position.z);
        }
        }
}
