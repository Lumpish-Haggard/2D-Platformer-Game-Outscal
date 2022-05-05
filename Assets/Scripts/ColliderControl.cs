using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControl : MonoBehaviour
{
    public BoxCollider2D stand;
    public BoxCollider2D crouch;
    public CircleCollider2D circle;

    PlayerController playerCollide;

    void Start() 
    {   
        playerCollide = GetComponent<PlayerController>();

        stand.enabled = true;
        crouch.enabled = false;
        circle.enabled = true;
    }

    void Update() 
    {
        if (playerCollide.grounded == false)
        {
        stand.enabled = true;
        crouch.enabled = false;
        circle.enabled = false;
        }
        else
        {
            if (playerCollide.crouching == true)
            {
            stand.enabled = false;
            crouch.enabled = true;
            circle.enabled = true;
            }
            else
            {
            stand.enabled = true;
            crouch.enabled = false;
            circle.enabled = true;
            }
        }

    }

}
