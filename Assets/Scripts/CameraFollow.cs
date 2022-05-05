using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private GameObject player;

    private float positionX;
    private float positionY;

    private Vector2 currentVelocity;

    public float smoothX;
    public float smoothY;

    public bool border;

    public float minX;
    public float maxX;

    public float minY;
    public float maxY;

    void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("ForCam");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("ForCam");
        }
        else
        {
            SmoothCamera();
        }
        if (border == true)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
        }
        
    }

    void SmoothCamera()
    {
        positionX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref currentVelocity.x, smoothX);
        positionY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref currentVelocity.y, smoothY);
        transform.position = new Vector3(positionX, positionY, transform.position.z);
    }
}
