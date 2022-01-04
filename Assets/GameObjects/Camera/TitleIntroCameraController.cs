using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleIntroCameraController : MonoBehaviour
{
    /*@ Created by David Underwood-Jett / Third Partition Development
     * Last updated 1/29/20
     * ThirdPartitionDevelopment@gmail.com
     * 
     * ---HOW TO USE----
     * 1. Assign this script to the camera in the Unity Editor.
     * 2. Make sure the material is using Unity Standard Diffuse shader or a shader with a "_Glossiness" property (will show as smoothness in editor)
     * 3. Assign missing objects (light, material)
     * 4. Fill out the lists, (use the same length for all lists, if you dont want something to change, just use the same values)
     * 5. Test and tweak. 
     * 6. Enjoy!
     * 7. Email me if you have any troubles!
     * @*/

   // public bool isLooping; haven't added this yet dont worry about it
    public float startDelay; //how long it will take before the camera motion starts
    public Material material; //the material that will be altered
    public Light directionalLight; //the light that will be altered
    public float initialMetallic; //you probably want to set this to 1 but it's up to you!
    public List<Vector3> positionList; //list of positions for the camera to interpolate between
    public List<float> positionLerpSpeedList; //a factor controling the spped at which the camera will interpolate (positional)
    public List<Vector3> rotationList; //list of rotations for the camera to interpolate between
    public List<float> rotationLerpSpeedList; //a factor controlling the speed at which the camera will interpolate (rotational)
   
    public List<float> transitionTimeList; //the time spent lerping towards each position/rotation/intensity/smoothness
    private Transform cameraTrans; //set automatically in MonoBehaviour.Start()
 
   
   
    public List<float> lightIntensityList; //list of light intensities for the light to interpolate between
    public List<float> lightIntensitySpeedList;//a factor controlling the speed at which the intensity interpolates.
    public List<float> materialSmoothnessList;//list of smoothness floats for the Standard Diffuse Unity Shader. Will work with other shaders as well, but you pay have to change the name of the shader property below from "_Glossiness"
    public List<float> materialSmoothnessLerpSpeedList;//a factor controlling the speed at which "_Glossiness" property interpolates.
    
    private float intensity;
    private float smoothness; // this actually refers to (Smoothness within material, _Glossiness within shader)
    private float realMetallic = 1; // this does refer to "_Metallic" property within shader
    private int counter; //a counter to tell which properties to lerp towards.
    void Update()
    {
        if(transitionTimeList[materialSmoothnessLerpSpeedList.Count -1] <= 0) //if the final transition timer has expired
        {
            SceneManager.LoadSceneAsync("GameStart");
            return;
        }

        if (startDelay < 0)
        {
            //sets the camera position
            cameraTrans.position = Vector3.Lerp(cameraTrans.position, positionList[counter], positionLerpSpeedList[counter] * Time.deltaTime);
            //sets the camera rotatiom
            cameraTrans.rotation = Quaternion.Euler(Vector3.Lerp(cameraTrans.rotation.eulerAngles, rotationList[counter], rotationLerpSpeedList[counter] * Time.deltaTime));
            //sets the smoothness or _Glossiness
            smoothness = Mathf.Lerp(smoothness, materialSmoothnessList[counter], materialSmoothnessLerpSpeedList[counter] * Time.deltaTime);
            material.SetFloat("_Smoothness", smoothness);
            //sets the light intensity
            intensity = Mathf.Lerp(intensity, lightIntensityList[counter], lightIntensitySpeedList[counter] * Time.deltaTime);
            directionalLight.intensity = intensity;
            //keeping track of time
            transitionTimeList[counter] -= Time.deltaTime;
            //checking to see if property change is needed
            if (transitionTimeList[counter] <= 0)
            {
                counter++;
            }
           
           //this is hard coded you could remove this metallic stuff if you dont want it.
           //it is making the text fade to black in the end and fade into view in the beginning
            if(counter >= materialSmoothnessLerpSpeedList.Count - 1)
            {
                realMetallic = Mathf.Lerp(realMetallic, 1f, Time.deltaTime * 10f);
            }
            else
            {
                realMetallic = Mathf.Lerp(realMetallic, .72f, Time.deltaTime * .09f);
            }
            material.SetFloat("_Metallic", realMetallic);
        }
        startDelay -= Time.deltaTime;
    }
    private void Start()
    {
        //setting some initial properties. Shader properties are saved at runtime so will be altered usually.
        material.SetFloat("_Metallic", initialMetallic);
        cameraTrans = this.gameObject.transform;
        smoothness = material.GetFloat("_Smoothness");
        intensity = directionalLight.intensity;
    }
}
