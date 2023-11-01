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
        }

        Vector2 Position = transform.position;
        if (playerPos == Position)
        {
            animator.SetBool("Collision", true);
            StartCoroutine(DestroySoon());

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Collision", true);
            collide = true;
            StartCoroutine(DestroySoon());
        }
    }

    IEnumerator DestroySoon()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}