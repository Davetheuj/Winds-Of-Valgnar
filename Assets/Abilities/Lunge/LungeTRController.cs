using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LungeTRController : MonoBehaviour
{


    // public bool isLooping; haven't added this yet dont worry about it
    public float startDelay; //how long it will take before the camera motion starts
    public List<Vector3> positionList; //list of positions for the camera to interpolate between
    public List<float> positionLerpSpeedList; //a factor controling the spped at which the camera will interpolate (positional)
    public List<Vector3> rotationList; //list of rotations for the camera to interpolate between
    public List<float> rotationLerpSpeedList; //a factor controlling the speed at which the camera will interpolate (rotational)
    public List<float> transitionTimeList; //the time spent lerping towards each position/rotation/intensity/smoothness
    private Transform parentObject; //set automatically in MonoBehaviour.Start()
    private int counter; //a counter to tell which properties to lerp towards.
    public bool isFinished;

    private Vector3 initialPosition;
    private Vector3 initialRotation;
    public float resetTime; //how much time is spent transitioning between the 2nd to final and final rotation and position
    public float finalPositionLerpSpeed;
    public float finalRotationLerpSpeed;

    private bool initialized;

    public Animator animator;


    
    void Update()
    {
        if (!initialized)
        {
            setInitialValues();
            initialized = true;
        }

        if (transitionTimeList[transitionTimeList.Count - 1] <= 0) //if the final transition timer has expired
        {
            animator.SetBool("ShouldAnimate", true);
            Destroy(this.gameObject);
            return;
        }

        if (startDelay <= 0)
        {
            //sets the camera position
            parentObject.localPosition = Vector3.Lerp(parentObject.localPosition, initialPosition+positionList[counter], positionLerpSpeedList[counter] * Time.deltaTime);
            //sets the camera rotatiom
            parentObject.localRotation = Quaternion.Euler(Vector3.Lerp(parentObject.localRotation.eulerAngles, initialRotation+rotationList[counter], rotationLerpSpeedList[counter] * Time.deltaTime));
            //keeping track of time
            transitionTimeList[counter] -= Time.deltaTime;
            //checking to see if property change is needed
            if (transitionTimeList[counter] <= 0)
            {
                counter++;
            }

        }
        startDelay -= Time.deltaTime;
    }
    private void setInitialValues()
    {
 
        parentObject = this.gameObject.transform.parent;
        initialPosition = parentObject.localPosition;
        initialRotation = parentObject.localRotation.eulerAngles;

        positionList.Add(initialPosition);
        rotationList.Add(initialRotation);
        transitionTimeList.Add(resetTime);
        positionLerpSpeedList.Add(finalPositionLerpSpeed);
        rotationLerpSpeedList.Add(finalRotationLerpSpeed);

        animator = this.gameObject.GetComponentInParent<Animator>();
        animator.SetBool("ShouldAnimate", false);

    }
}
