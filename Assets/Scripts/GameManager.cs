using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ApnaGameManager;

    public GameObject prefab;
    public GameObject respawnPoint;

    public float respawnTimeDelay = 2f;

    public int lives;

    


    //making the Game Manager a Singleton 
    void Awake() 
    {
        if (ApnaGameManager == null)
        {
            ApnaGameManager = this;
            DontDestroyOnLoad(gameObject);           
        }    
        else
        {
            Destroy(gameObject);
        }

        
    }

    public IEnumerator Respawn()
    {
        lives -= 1;
        if (lives <= 0)
        {
            Debug.Log("For Sending to End Screen");
        }
        yield return new WaitForSeconds(respawnTimeDelay); //respawn after 2 seconds
        if (lives > 0)
        Instantiate(prefab, respawnPoint.transform.position, respawnPoint.transform.rotation);
    }
}
