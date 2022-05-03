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

    Rigidbody2D EllenRigidBody;
    Animator AnimationControl;

    private void Start() 
    {
        EllenRigidBody = GetComponent<Rigidbody2D>();
        AnimationControl = GetComponent<Animator>();
    }

    private void Update() 
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        jump = Input.GetAxisRaw("Jump");
    }

    private void FixedUpdate() 
    {
        Flip();
        grounded = Physics2D.OverlapCircle(groundPoint.position, groundRadius, whatIsGround);
        Move();
        Jump();

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
}
