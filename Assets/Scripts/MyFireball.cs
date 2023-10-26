using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MyFireball : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public Vector2 FuturePosition;

    private bool collide = false;

    // Update is called once per frame
    void Update()
    {
        float step = 5 * Time.deltaTime;
        if (!collide)
        {
            //transform.position = Vector2.MoveTowards(transform.position, playerPos, step);
        }

        Vector2 Position = transform.position;
        /*if (playerPos == Position)
        {
            animator.SetBool("Collision", true);
            StartCoroutine(DestroySoon());

        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("coding will kill you");
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