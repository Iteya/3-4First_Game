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
        transform.position = Vector2.MoveTowards(transform.position, playerPos, step);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetInteger("Explode", 1);
        }
    }
}