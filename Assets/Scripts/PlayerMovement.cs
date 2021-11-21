using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    #region Fields

    Animator animator;
    Rigidbody rb;

    [Header("Components")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayerMask;


    float runSpeed = 1000; // Default values, set by UI
    float jumpHeight = 40000;
    float turnRate = 0.5f;

    bool isMoving = false;

    #endregion

    #region Methods
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
    #endregion


    #region Properties

    public float RunSpeed
    {
        get { return runSpeed; }
        set
        {
            if(value >= 0)
                runSpeed = value;
        }
    }
    public float JumpHeight
    {
        get { return jumpHeight; }
        set
        {
            if (value >= 0)
                jumpHeight = value;
        }
    }
    public float TurnRate
    {
        get { return turnRate; }
        set
        {
            if (value >= 0)
                turnRate = value;
        }
    }

    #endregion
}
