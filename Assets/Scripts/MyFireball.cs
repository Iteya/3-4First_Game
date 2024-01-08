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

    void Start()
    {
        FuturePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    // Update is called once per frame
    void Update()
    {
        float step = 5 * Time.deltaTime;
        if (!collide)
        {
            transform.position = Vector2.MoveTowards(transform.position, FuturePosition, step);
        }

        Vector2 Position = transform.position;
        if (Position == FuturePosition)
        {
            StartCoroutine(DestroySoon());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            animator.SetBool("Collision", true);
            collide = true;
            StartCoroutine(DestroySoon());
        }
    }

    IEnumerator DestroySoon()
    {
        animator.SetBool("Collision", true);
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}