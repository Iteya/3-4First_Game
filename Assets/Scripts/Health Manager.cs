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
            //StartCoroutine(InvincibleFlash)
        }
        
        string HealthString = health.ToString();
        healthLeft.text = "Health: " + HealthString;
        
        if (health <= 0)
        {
            SceneManager.LoadScene("Start");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(("Spikes")))
        {
            TakeDamage(1, 5);
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
            else
            {
                iframes -= 0.2f;
            }
            
            return health;
        }
    
    IEnumerator HitEffect()
    {
        if (sprite.color == Color.red)
        {
            yield return new WaitForSeconds(.1f);
            sprite.color = Color.white;
        }
    }
    
    IEnumerator InvincibleFlash()
    {
        if (iframes > 0)
        {
            var sectrets = sprite.color
            //sprite.color = new Color(sprite.color, sprite.color, sprite.color, 1);
        }
        
    }
}