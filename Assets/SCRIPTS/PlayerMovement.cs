using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D control;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    void Update(){
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
       animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

       if(Input.GetButtonDown("Jump")){
           jump = true;
           animator.SetBool("isJump", true);
       }
       if(Input.GetButtonDown("Crouch")){
           crouch = true;
       }else if(Input.GetButtonUp("Crouch")){
           crouch = false;
       }
    }
    public void OnLanding(){
        animator.SetBool("isJump", false);
    }
    void FixedUpdate(){
        control.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
