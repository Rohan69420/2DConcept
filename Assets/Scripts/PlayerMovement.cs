using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    bool jump = false;

    public float runSpeed = 40f;
    // Update is called once per frame
    void Update()
    {

        //get the direction key -1 if l and 1 if r
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;   

        //jump checkk
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            UnityEngine.Debug.Log("Jumped!");
        }
    }
    void FixedUpdate()
    {
        //move our character

        //delta time ensures that it is constant no matter how many times it is called
        //UnityEngine.Debug.Log("Move triggered!!"+horizontalMove.ToString());
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
