using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class damageText : MonoBehaviour
{
    private float time;
    public Camera cam;
    public  float ySpeed;
    private float xSpeed;
    public float ySpeedModifier;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        xSpeed = ((Random.value * 20) - 10f);


    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.localPosition = new Vector3(transform.localPosition.x - xSpeed * Time.deltaTime, transform.localPosition.y + ySpeed *Time.deltaTime, 0);
        ySpeed -=  ySpeedModifier;
        
       
        transform.LookAt(cam.transform);
        transform.Rotate(new Vector3(0, 180, 0));

        gameObject.GetComponent<TMP_Text>().fontSize -= Time.deltaTime*gameObject.GetComponent<TMP_Text>().fontSize;
        

        if (time > 1.5f)
        {
            Destroy(this.gameObject);

        }


    }
}
