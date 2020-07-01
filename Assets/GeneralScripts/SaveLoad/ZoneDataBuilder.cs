using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneDataBuilder : MonoBehaviour
{
    public List<string> NPCTransformNames;
    
    public List<float> NPCPositionX;
    public List<float> NPCPositionY;
    public List<float> NPCPositionZ;
    
    public List<float> NPCRotationX;
    public List<float> NPCRotationY;
    public List<float> NPCRotationZ;

    public List<string> NPCTalkOptionNames;
    public ZoneDataBuilder(Scene scene)
    {

    }
}
