using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inCaves;
    public int ySpeed;
    public int xSpeed;
    // Update is called once per frame
    void Update()
    {
        if (inCaves)
        {
            ySpeed = 0;
        }
        transform.Translate((Input.GetAxis("Horizontal")* xSpeed )*Time.deltaTime, (Input.GetAxis("Vertical") * ySpeed) * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            
        }
    }
}
