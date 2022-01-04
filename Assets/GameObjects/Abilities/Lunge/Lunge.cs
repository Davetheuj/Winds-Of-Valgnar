using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunge : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {



        //Send message to main hand's Equipment Controller to compute damage, select a weapon animation to play,
        GameObject.Find("Hand_R").GetComponentInChildren<Equipment>().SelectAndEnableRandomAnimation();
        //Destroy this gameobject
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }



    IEnumerator WaitAndDestroy()
    {

        yield return new WaitForSecondsRealtime(.025f);
        Destroy(gameObject);
    }
}
