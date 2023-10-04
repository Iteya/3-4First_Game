using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.SceneManagement.SceneManager;

public class PlatformMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inCaves;
    public int ySpeed;
    public int xSpeed;
    public int coins;
    public int health = 10;
    public float iframes;
    public TextMeshProUGUI coinsCollected;
    public TextMeshProUGUI healthLeft;
    public SpriteRenderer sprite;
    public int TakeDamage(int amount, float time)
    {
        if (iframes <= 0f)
        {
            health -= amount;
            iframes = time;
            sprite.color = Color.red;
        }
        else
        {
            iframes -= 0.2f;
        }
        
        return health;
    }

    void Update()
    {
        if (inCaves)
        {
            ySpeed = 0;
        }

        if (iframes >= 0f)
        {
            iframes -= 1f * Time.deltaTime;
        }

        if (iframes < 4.9)
        {
            sprite.color = Color.white;
        }
        Debug.Log("iframes: " + iframes);
        transform.Translate((Input.GetAxis("Horizontal")* xSpeed )*Time.deltaTime, (Input.GetAxis("Vertical") * ySpeed) * Time.deltaTime, 0);
        string CoinString = coins.ToString();
        string HealthString = health.ToString();
        healthLeft.text = "Health: " + HealthString;
        coinsCollected.text = "coins: " + CoinString;
        if (health <= 0)
        {
            SceneManager.LoadScene("Start");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coins += 1;
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag(("Spikes")))
        {
            TakeDamage(1, 5);
        }
    }
}
