using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    public Image heart;
    public Sprite[] heartSprite;

    PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            ChangingUIHealth();
        }
        else
        {
            player = FindObjectOfType<PlayerScript>();
            heart.enabled = false;
        }
    }

    void ChangingUIHealth()
    {
        if (player.playerStats.Health > 0)
        {
            heart.enabled = true;
            heart.sprite = heartSprite[player.playerStats.Health - 1];
        }
      
    }
}
