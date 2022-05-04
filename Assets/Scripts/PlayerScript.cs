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

    Stats playerStats = new Stats();

    public int normalDamage;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Chomper"))
        {
            DamagePlayer(normalDamage);
            Destroy(other.gameObject);
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
    }
}
