using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperControl : MonoBehaviour
{

    public Transform originPoint;
    private Vector2 dir = new Vector2(1, 0);
    public float range;
    public float speed;

    Rigidbody2D ChomperRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        ChomperRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(originPoint.position, dir * range);
        RaycastHit2D hit = Physics2D.Raycast(originPoint.position, dir, range);
        if (hit == false)
        {
            Flip();
            speed *= -1;
            dir *= -1;
        }
    }

    void FixedUpdate()
    {
        ChomperRigidBody.velocity = new Vector2(speed, ChomperRigidBody.velocity.y);
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
