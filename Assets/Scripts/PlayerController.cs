using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float horizontal;
    public float speed;
    
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

    public int extraJumps = 2; //for triple jump
    int jumpCount = 0;
    float jumpCoolDown;


    private void Start() 
    {
        EllenRigidBody = GetComponent<Rigidbody2D>();
        AnimationControl = GetComponent<Animator>();
        
        DontDestroyOnLoad(gameObject);
    }

    private void Update() 
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        CheckGrounded();

        crouch = Input.GetAxisRaw("Crouch");
        CrouchFunction();
    }

    private void FixedUpdate() 
    {

        Flip();
        grounded = Physics2D.OverlapCircle(groundPoint.position, groundRadius, whatIsGround);
        ceiling = Physics2D.OverlapCircle(ceilingPoint.position, groundRadius, whatIsGround);
        Move();
        

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
        if (grounded || jumpCount < extraJumps)
        {
        EllenRigidBody.velocity = new Vector2(EllenRigidBody.velocity.x, jumpForce);
        jumpCount++;
        }
    }

    void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(groundPoint.position, groundRadius, whatIsGround))
        {
            grounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.2f;
        }
        else if (Time.time < jumpCoolDown)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
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

    private void OnLevelWasLoaded(int level)
    {
        FindStartPos();
    }

    void FindStartPos()
    {
        transform.position = GameObject.FindWithTag("Respawn").transform.position;
    }

}
