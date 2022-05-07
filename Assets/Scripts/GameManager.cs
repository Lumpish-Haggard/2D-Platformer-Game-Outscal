using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public GameObject prefab;
    private GameObject respawnPoint;

    public int lives;


    //making the Game Manager a Singleton 
    void Awake() 
    {
        if (GM == null)
        {
            GM = this;
            DontDestroyOnLoad(gameObject);           
        }    
        else
        {
            Destroy(gameObject);
        }

        respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
    }

    public IEnumerator Respawn()
    {
        lives -= 1;
        if (lives <= 0)
        {
            Debug.Log("For Sending to End Screen");
        }
        yield return new WaitForSeconds(2f); //respawn after 2 seconds
        if (lives > 0)
        Instantiate(prefab, respawnPoint.transform.position, respawnPoint.transform.rotation);
    }
}
