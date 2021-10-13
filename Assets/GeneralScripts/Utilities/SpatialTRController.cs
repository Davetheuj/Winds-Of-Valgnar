using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpatialTRController : MonoBehaviour
{
    [SerializeField]
    private string animationName;
    // public bool isLooping; haven't added this yet dont worry about it
    public float startDelay; //how long it will take before the camera motion starts
    public float initialStartDelay;
    public List<Vector3> positionList; //list of positions for the camera to interpolate between
    public List<float> positionLerpSpeedList; //a factor controling the spped at which the camera will interpolate (positional)
    public List<Vector3> rotationList; //list of rotations for the camera to interpolate between
    public List<float> rotationLerpSpeedList; //a factor controlling the speed at which the camera will interpolate (rotational)
    [SerializeField]
    private List<float> transitionTimeList; //the time spent lerping towards each position/rotation/intensity/smoothness
    private List<float> realTransitionTimeList = new List<float>();
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

        if (realTransitionTimeList[realTransitionTimeList.Count - 1] <= 0) //if the final transition timer has expired
        {
            animator.SetBool("ShouldAnimate", true);
            this.enabled = false;
            initialized = false;
            
            try //attempt to disable the trigger from the weapon this is attached to if we have one
            {
                gameObject.GetComponent<Weapon>().isAttacking = false;
            }
            catch (Exception e)
            {
                Debug.Log("No collider component attached to this gameobject (in SpatialTRController.cs)");
            }

            parentObject.localPosition = positionList[positionList.Count - 1];
            parentObject.localRotation = Quaternion.Euler(rotationList[rotationList.Count - 1]);


            positionList.RemoveAt(positionList.Count-1);
            rotationList.RemoveAt(rotationList.Count - 1);
            realTransitionTimeList.RemoveAt(realTransitionTimeList.Count - 1);
            positionLerpSpeedList.RemoveAt(positionLerpSpeedList.Count - 1);
            rotationLerpSpeedList.RemoveAt(rotationLerpSpeedList.Count - 1);

            return;
        }

        if (startDelay <= 0)
        {
            //sets the camera position
            parentObject.localPosition = Vector3.Lerp(parentObject.localPosition, initialPosition + positionList[counter], positionLerpSpeedList[counter] * Time.deltaTime);
            //sets the camera rotatiom
            parentObject.localRotation = Quaternion.Euler(Vector3.Lerp(parentObject.localRotation.eulerAngles, initialRotation + rotationList[counter], rotationLerpSpeedList[counter] * Time.deltaTime));
            //keeping track of time
           realTransitionTimeList[counter] -= Time.deltaTime;
            //checking to see if property change is needed
            if (realTransitionTimeList[counter] <= 0)
            {
                Debug.Log($"Finished {counter} transition");
                
                counter++;
            }
            return;
        }
        startDelay -= Time.deltaTime;
    }
    private void setInitialValues()
    {
       
        realTransitionTimeList.Clear();
        realTransitionTimeList.AddRange(transitionTimeList);
        startDelay = initialStartDelay;
        counter = 0;
        parentObject = this.gameObject.transform;
        initialPosition = parentObject.localPosition;
        initialRotation = parentObject.localRotation.eulerAngles;

        positionList.Add(initialPosition);
        foreach (Vector3 f in positionList)
        {
            Debug.Log($"{f}");
        }
        rotationList.Add(initialRotation);
        realTransitionTimeList.Add(resetTime);
        positionLerpSpeedList.Add(finalPositionLerpSpeed);
        rotationLerpSpeedList.Add(finalRotationLerpSpeed);

        animator = this.gameObject.GetComponentInParent<Animator>();
        animator.SetBool("ShouldAnimate", false);

    }
}
