using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    public Animator animator;
    public PlayerControlAlpha playerControl;

    void Start()
    {
        playerControl = gameObject.GetComponent<PlayerControlAlpha>();
        animator = GetComponentInChildren<Animator>();
    }

   
    void Update()
    {
        float speedPercent = new Vector3(playerControl.moveDirection.x, 0, playerControl.moveDirection.z).magnitude;
        animator.SetFloat("SpeedPercent", speedPercent, .02f, Time.deltaTime);
       
       

        
    }
}
