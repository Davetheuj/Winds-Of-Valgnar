using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunge : MonoBehaviour
{
    public AudioClipController clipController;


    // Start is called before the first frame update
    void Start()
    {
        clipController = gameObject.GetComponent<AudioClipController>();



    }

    // Update is called once per frame
    void Update()
    {

        clipController.PlayInteractionClip(0, 1, false, 0, false, true,true);
        //Send message to main hand's Equipment Controller to compute damage, select a weapon animation to play,
        GameObject.Find("Hand_R").GetComponentInChildren<Weapon>().SelectAndEnableRandomAnimation();
        //Destroy this gameobject
        Destroy(gameObject);

    }



    IEnumerator WaitAndDestroy()
    {

        yield return new WaitForSecondsRealtime(.025f);
        Destroy(gameObject);
    }
}
