using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PELevelUp : MonoBehaviour
{

    public ParticleSystem.VelocityOverLifetimeModule particleSys;

    public float maxRadial;
    public float minRadial;
    public float lerpConstant;
    private float currentSize;

    private bool isGrowing;

    // Start is called before the first frame update
    void Start()
    {
        
        isGrowing = true;
        particleSys = this.gameObject.GetComponent<ParticleSystem>().velocityOverLifetime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrowing)
        {
            particleSys.radial = particleSys.radial.constant + (Time.deltaTime * lerpConstant);
            if (currentSize >= maxRadial)
            {
                isGrowing = false;
            }
        }
        else if (!isGrowing)
        {
            particleSys.radial = particleSys.radial.constant - (Time.deltaTime*lerpConstant*lerpConstant );
            if (currentSize <= minRadial)
            {
                //Destroy(this.gameObject);
                isGrowing = true;
            }
        }
        currentSize = particleSys.radial.constant;
    }
}
