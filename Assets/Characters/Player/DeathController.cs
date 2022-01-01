
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public Material skyboxMaterial;
    public bool isDead;
    public float lerpModifier;
    public void ExecuteDeathRoutine()
    {
        skyboxMaterial = RenderSettings.skybox;
    }
    public void Update()
    {
        if (isDead)
        {
            skyboxMaterial.SetFloat("_Exposure", Mathf.Lerp(skyboxMaterial.GetFloat("_Exposure"), 500f, lerpModifier*
                Time.deltaTime));
           

        }
    }
}
