using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{

    Animator animator;
    Rigidbody rb;
    [Header("Components")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayerMask;

    [Header("Movement")]
    [SerializeField] float runSpeed = 100;
    [SerializeField] float jumpHeight = 400;
    [Range(0.2f, 1)]
    [SerializeField] float turnRate;

    bool isMoving = false;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }


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
            rb.AddForce(transform.forward * runSpeed * Time.deltaTime);
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
            rb.AddForce(transform.up *  jumpHeight * Time.deltaTime);
        }
        if (!IsGrounded())
        {
            animator.SetBool("isJumping", true); // Jumping animation is not added yet.
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }


    void Turn(float turnAmount)
    {
        transform.Rotate(transform.up, turnAmount * turnRate);
        
        /*print(Vector3.Angle(transform.forward, dirToFace));
        while (Vector3.Angle(transform.forward, dirToFace) > 0)
        {
            animator.SetBool("isTurning", true);
            transform.Rotate(new Vector3(0, 1, 0));
        }
        else
        {
            animator.SetBool("isTurning", false);
        }*/
    }

    bool IsGrounded()
    {
        
        if(Physics.CheckSphere(groundCheck.position, 0.05f, groundLayerMask)) //0.05 is radius of ground check sphere.
        {
            return true;
        }
        return false;
    }
    
}
