using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    float horizontalMove = 0f;
    bool jump = false;

    bool moveLeft = false;
    bool moveRight = false;

    public float runSpeed = 40f;
    // Update is called once per frame
    void Update()
    {

        //get the direction key -1 if l and 1 if r
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //android config
        if (moveLeft == true)
        {
            horizontalMove = -1 * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }
        if(moveRight == true)
        {
            horizontalMove = 1 * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }

        //jump checkk
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jump", jump);
            UnityEngine.Debug.Log("Jumped!");
        }
    }
    
    public void Onlanding()
    {
        animator.SetBool("Jump", false);
    }


    void FixedUpdate()
    {
        //move our character

        //delta time ensures that it is constant no matter how many times it is called
        //UnityEngine.Debug.Log("Move triggered!!"+horizontalMove.ToString());
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
    
    public void setMoveLeft()
    {
        moveLeft = true;
        moveRight = false;
    }
    public void setMoveRight()
    {
        moveRight = true;
        moveLeft = false;
    }

    public void stop()
    {
        moveLeft = false;
        moveRight = false;
        horizontalMove = 0f;
    }

    public void jumping()
    {
        jump = true;
    }
}
