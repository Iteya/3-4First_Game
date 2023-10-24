using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FIREBALL : MonoBehaviour
{
    public Animator animator;
    GameObject player;
    private Rigidbody2D rb;

    public Vector2 playerPos;

    private bool collide = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = 5 * Time.deltaTime;
        if (!collide)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos, step);
        } else if (collide)
        {
            //Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("coding will kill you");
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetInteger("Explode", 2);
            collide = true;
            destroySoon();
        }
    }

    IEnumerator destroySoon()
    {
        return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}