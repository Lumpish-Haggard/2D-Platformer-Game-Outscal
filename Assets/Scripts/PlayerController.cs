using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D ellenkibody; //for fall after the jump

    //public Sprite[] standing; //for crouching
    //public Sprite[] crouching;
    //private BoxCollider2D collide2D;
    //private Transform skin;
    //private SpriteRenderer characterRenderer;
    //private SpriteRenderer skinRenderer;

    //public CharacterController PlayerHeight; //crouch
    //public float normalHeight, crouchHeight;


    private void Awake() //Starting the script
    {
        Debug.Log("Player Contoller Awake");
        ellenkibody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision: " + collision.gameObject.name); //Printing the collider
    }

    private void Update() //input logic to make player move
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
 
        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);

        //if (Input.GetKeyDown(KeyCode.C)) //crouch
        //{
        //    PlayerHeight.height = crouchHeight;
        //}
        //if (Input.GetKeyUp(KeyCode.C))
        //{
        //    PlayerHeight.height = normalHeight;
        //}

    }

    private void MoveCharacter(float horizontal, float vertical) //character moving function
    {
        //horizontal movements
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime; // [1 / frames per second]
        transform.position = position;

        //vertical movements
        if(vertical > 0)
        {
            ellenkibody.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0) //rotating it for the left animation (flip)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //jump
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        } else
        {
            animator.SetBool("Jump", false);
        }

        ////crouch
        //collide2D = GetComponent<BoxCollider2D>();
        //skin = transform.GetChild(0);
        //characterRenderer = GetComponent<SpriteRenderer>();
        //skinRenderer = skin.GetComponent<SpriteRenderer>();

    }

    //public void Crouch(bool pressed)
    //{
    //    if(pressed)
    //    {
    //        collide2D.size = new Vector2(collide2D.size.x, 4.5f);
    //        collide2D.offset = new Vector2(collide2D.offset.x, 0.5f);
    //        characterRenderer.sprite = crouching[0];
    //        skinRenderer.sprite = crouching[1];
    //    } else
    //    {
    //        collide2D.size = new Vector2(collide2D.size.x, 6f);
    //        collide2D.offset = new Vector2(collide2D.offset.x, 0);
    //        characterRenderer.sprite = standing[0];
    //        skinRenderer.sprite = standing[1];
    //    }
    //}

}
