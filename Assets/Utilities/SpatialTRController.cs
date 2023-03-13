using Assets.Utilities.Math;
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
    public List<Vector4> rotationList; //list of rotations for the camera to interpolate between
    public List<float> rotationLerpSpeedList; //a factor controlling the speed at which the camera will interpolate (rotational)
    [SerializeField]
    private List<float> transitionTimeList; //the time spent lerping towards each position/rotation/intensity/smoothness
    private List<float> realTransitionTimeList = new List<float>();
    private int counter; //a counter to tell which properties to lerp towards.
    public bool isFinished;
    public float resetTime; //how much time is spent transitioning between the 2nd to final and final rotation and position
    private bool initialized;



    



    void Update()
    {
        if (!initialized)
        {
            setInitialValues();
            initialized = true;
        }

        if (realTransitionTimeList[realTransitionTimeList.Count - 1] <= 0) //if the final transition timer has expired
        {
           
            this.enabled = false;
            initialized = false;
            //parentObject.localPosition = initialPosition;
            //parentObject.localRotation = Quaternion.Euler(initialRotation);
            return;
        }

        if (startDelay <= 0)
        {
            //sets the camera position
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, positionList[counter], positionLerpSpeedList[counter] * Time.deltaTime);
            //sets the camera rotatiom
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternions.FromVector4(rotationList[counter]), rotationLerpSpeedList[counter] * Time.deltaTime);
            //keeping track of time
            realTransitionTimeList[counter] -= Time.deltaTime;
            //checking to see if property change is needed
            if (realTransitionTimeList[counter] <= 0)
            {
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

        transform.localPosition = positionList[0];
        transform.localRotation = Quaternions.FromVector4(rotationList[0]);
        counter = 1;
    }
}
