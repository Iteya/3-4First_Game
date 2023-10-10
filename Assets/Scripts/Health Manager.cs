using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.SceneManagement.SceneManager;

public class HealthManager : MonoBehaviour
{
    public int health = 10;
    public float iframes;
    public TextMeshProUGUI healthLeft;
    public SpriteRenderer sprite;
    
    //awake
    
    private void Start()
    {
        

    }

    void Update()
    {
        if (iframes >= 0f)
        {
            iframes -= 1f * Time.deltaTime;
        }

        if (iframes <= 0f)
        {
            sprite.color = Color.white;
        }
        
        string healthString = health.ToString();
        healthLeft.text = "Health: " + healthString;
        
        if (health <= 0)
        {
            SceneManager.LoadScene("Start");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Spikes"))
        {
            TakeDamage(1, 2);
        }
    }

    public int TakeDamage(int amount, float time)
        {
            if (iframes <= 0f)
            {
                health -= amount;
                iframes = time;
                sprite.color = Color.red;
                StartCoroutine(HitEffect());
            }
            
            return health;
        }
    
    IEnumerator HitEffect()
    {
        if (sprite.color == Color.red)
        {
            yield return new WaitForSeconds(.1f);
            sprite.color = Color.white;
            StartCoroutine(InvincibleFlash());
        }
    }

    IEnumerator InvincibleFlash()
    {
        while (iframes >= 0f)
        {
            if (sprite.color == Color.white)
            {
                sprite.color = Color.clear;
                yield return new WaitForSeconds(0.1f);
            } else if (sprite.color == Color.clear)
            {
                sprite.color = Color.white;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
