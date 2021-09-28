using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpatialTRController : MonoBehaviour
{
    

    // public bool isLooping; haven't added this yet dont worry about it
    public float startDelay; //how long it will take before the camera motion starts
    public List<Vector3> positionList; //list of positions for the camera to interpolate between
    public List<float> positionLerpSpeedList; //a factor controling the spped at which the camera will interpolate (positional)
    public List<Vector3> rotationList; //list of rotations for the camera to interpolate between
    public List<float> rotationLerpSpeedList; //a factor controlling the speed at which the camera will interpolate (rotational)
    public List<float> transitionTimeList; //the time spent lerping towards each position/rotation/intensity/smoothness
    private Transform gameObject; //set automatically in MonoBehaviour.Start()
    private int counter; //a counter to tell which properties to lerp towards.
    public bool isFinished;
    void Update()
    {
        if (transitionTimeList[transitionTimeList.Count - 1] <= 0) //if the final transition timer has expired
        {
            Destroy(this);
            return;
        }

        if (startDelay < 0)
        {
            //sets the camera position
            gameObject.position = Vector3.Lerp(gameObject.position, positionList[counter], positionLerpSpeedList[counter] * Time.deltaTime);
            //sets the camera rotatiom
            gameObject.rotation = Quaternion.Euler(Vector3.Lerp(gameObject.rotation.eulerAngles, rotationList[counter], rotationLerpSpeedList[counter] * Time.deltaTime));
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
    private void Start()
    {
        //setting some initial properties. Shader properties are saved at runtime so will be altered usually.
        gameObject = this.gameObject.transform;
    }
}
