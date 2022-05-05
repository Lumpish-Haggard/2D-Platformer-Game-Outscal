using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontal;
    public float speed;
    public float jump;
    public float jumpForce;


    public bool grounded;
    public bool facingRight = true;

    public LayerMask whatIsGround;
    public float groundRadius;
    public Transform groundPoint;

    private Rigidbody2D EllenRigidBody;
    private Animator AnimationControl;


    public Transform ceilingPoint;
    private bool ceiling;

    private float crouch;
    public bool crouching;

    private void Start() 
    {
        EllenRigidBody = GetComponent<Rigidbody2D>();
        AnimationControl = GetComponent<Animator>();
    }

    private void Update() 
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        jump = Input.GetAxisRaw("Jump");
        crouch = Input.GetAxisRaw("Crouch");

        CrouchFunction();
    }

    private void FixedUpdate() 
    {

        Flip();
        grounded = Physics2D.OverlapCircle(groundPoint.position, groundRadius, whatIsGround);
        ceiling = Physics2D.OverlapCircle(ceilingPoint.position, groundRadius, whatIsGround);
        Move();
        Jump();

        AnimationControl.SetBool("Crouch", crouching);
        AnimationControl.SetFloat("Speed", Mathf.Abs(EllenRigidBody.velocity.x));
        AnimationControl.SetBool("Grounded", grounded);
        AnimationControl.SetFloat("Jumping", EllenRigidBody.velocity.y);
    }


    private void Move()
    {
        EllenRigidBody.velocity = new Vector2(horizontal * speed, EllenRigidBody.velocity.y);
    }

    private void Jump()

    {
        if(grounded)
        EllenRigidBody.velocity = new Vector2(EllenRigidBody.velocity.x, jump * jumpForce);
    }

    private void Flip()
    {
        if((horizontal<0 && facingRight == true) || (horizontal>0 && facingRight == false))
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }


    void CrouchFunction()

    {
        if ((crouch != 0 || ceiling == true) && (grounded == true))
        {
            crouching = true;
        }
        else
        {
            crouching = false;
        }

    }

}
