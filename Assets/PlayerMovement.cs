﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    // Start is called before the first frame update
     public float runSpeed = 80f;
    float horizontalMove = 0f;
    // Update is called once per frame
    bool jump = false;
    bool crouch = false;
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if(Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if(Input.GetButtonDown("Crouch")){
            crouch = true;
        }else if(Input.GetButtonUp("Crouch")){
            crouch = false;
        }
    }

    public void OnLanding(){
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching){
        animator.SetBool("IsCrouching", isCrouching);
        Debug.Log(isCrouching);
    }
     void FixedUpdate (){
         controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
         jump = false;
         
    }
}
