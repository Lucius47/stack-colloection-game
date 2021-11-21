using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayerMask;

    float runSpeed = 10;
    float jumpHeight = 400;

    bool isMoving = false;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Run"))
        {
            isMoving = !isMoving;
        }

        Turn(turnAmount);
        if(isMoving)
        {
            rb.AddForce(transform.forward * runSpeed);
            animator.SetBool("isIdle", false);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isIdle", true);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(transform.up *  jumpHeight);
        }
        if (!IsGrounded())
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }



    }
    void Turn(float turnAmount)
    {
        transform.Rotate(transform.up, turnAmount);
        
        //print(Vector3.Angle(transform.forward, dirToFace));
        //while (Vector3.Angle(transform.forward, dirToFace) > 0)
        {
            //animator.SetBool("isTurning", true);
            //transform.Rotate(new Vector3(0, 1, 0));
        }
        //else
        {
            //animator.SetBool("isTurning", false);
        }
    }

    bool IsGrounded()
    {
        
        if(Physics.CheckSphere(groundCheck.position, 0.05f, groundLayerMask))
        {
            return true;
        }
        return false;
    }
    
}
