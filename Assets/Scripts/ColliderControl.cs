using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControl : MonoBehaviour
{
    public BoxCollider2D stand;
    public BoxCollider2D crouch;
    public CircleCollider2D circle;
    public BoxCollider2D jump;

    PlayerController playerCollide;

    void Start() 
    {   
        playerCollide = GetComponent<PlayerController>();

        stand.enabled = true;
        crouch.enabled = false;
        circle.enabled = true;
        jump.enabled = false;
    }

    void Update() 
    {
        if (playerCollide.grounded == false)
        {
        stand.enabled = false;
        crouch.enabled = false;
        circle.enabled = false;
        jump.enabled = true;
        }
        else
        {
            if (playerCollide.crouching == true)
            {
            stand.enabled = false;
            crouch.enabled = true;
            circle.enabled = true;
            jump.enabled = false;
            }
            else
            {
            stand.enabled = true;
            crouch.enabled = false;
            circle.enabled = true;
            jump.enabled = false;
            }
            
        }

    }

}
