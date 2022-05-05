using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D ellenkibody; //for fall after the jump

    public float crouch;

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
        float crouch = Input.GetAxisRaw("Crouch");

        MoveCharacter(horizontal, vertical, crouch);
        PlayMovementAnimation(horizontal, vertical, crouch);

    }

    private void MoveCharacter(float horizontal, float vertical, float crouch) //character moving function
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

    private void PlayMovementAnimation(float horizontal, float vertical, float crouch)
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

        animator.SetBool("Jump", vertical > 0);
        animator.SetBool("Crouch", crouch > 0);

    }

}
