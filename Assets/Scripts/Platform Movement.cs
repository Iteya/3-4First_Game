using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inCaves;
    public int ySpeed;
    public int xSpeed;
    public int coins;
    public TextMeshProUGUI coinsCollected;
    public TextMeshProUGUI healthLeft;
    void Update()
    {
        if (inCaves)
        {
            ySpeed = 0;
        }
        transform.Translate((Input.GetAxis("Horizontal")* xSpeed )*Time.deltaTime, (Input.GetAxis("Vertical") * ySpeed) * Time.deltaTime, 0);
        Debug.Log("coins: " + coins);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coins += 1;
            other.gameObject.SetActive(false);
        } 
    }
}
