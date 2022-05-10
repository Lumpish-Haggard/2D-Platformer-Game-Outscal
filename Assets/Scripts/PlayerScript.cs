using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public Image damageScreen;
    public Color imageColor;

    private Color fadeColor = new Color(227f, 0f, 0f, 0f);
    public float fadeSpeed;

    private bool hurt = false;

    public Stats playerStats = new Stats();

    public int normalDamage;

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Chomper"))
        {
            DamagePlayer(normalDamage);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            if (transform.position.y > other.transform.position.y+1)
            transform.SetParent(other.transform);
        }
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        transform.SetParent(null);   
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            if (playerStats.Health < playerStats.maxHP)
            {
                playerStats.Health += 1;
                other.gameObject.SetActive(false);
            }
            else
            {
                return;
            }
        }
    }

    void Awake()
    {
        
        if (damageScreen == null)
        {
            damageScreen = GameObject.FindGameObjectWithTag("DamageScreen").GetComponent<Image>(); //adding screen hurt effect to prefab
        }
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        playerStats.SetHealth();
    }

    // Update is called once per frame
    private void Update()
    {

        if (hurt == true)
        {
            damageScreen.color = imageColor;
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, fadeColor, fadeSpeed * Time.deltaTime);
        }
        hurt = false;

    }

    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        hurt = true;

        if (playerStats.Health <=0)
        {
            Destroy(gameObject);
            GameManager.ApnaGameManager.StartCoroutine(GameManager.ApnaGameManager.Respawn());
        }
    }
}
