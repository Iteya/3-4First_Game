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
    private bool grounded = false;
    public string facing = "up";
    public Vector2 Position;
    public GameObject Fireball;
    [SerializeField] private float Jumpstrength;

    void Update()
    {
        Position = transform.position;
        if (inCaves)
        {
            transform.Translate((Input.GetAxis("Horizontal") * xSpeed) * Time.deltaTime, 0, 0);
            if (Input.GetAxisRaw("Vertical") > 0.5 && grounded)
            {
                rb.AddForce(new Vector2(0, Mathf.Max(0, Input.GetAxisRaw("Vertical")) * ySpeed * Jumpstrength), ForceMode2D.Impulse);
                grounded = false;
            }
        } else
        {
            transform.Translate((Input.GetAxis("Horizontal") * xSpeed ) * Time.deltaTime, (Input.GetAxis("Vertical") * ySpeed) * Time.deltaTime, 0);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            facing = "right";
        } else if (Input.GetAxis("Horizontal") < 0)
        {
            facing = "left";
        } else if (Input.GetAxis("Vertical") > 0)
        {
            facing = "up";
        } else if (Input.GetAxis("Vertical") < 0)
        {
            facing = "down";
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (facing == "right")
            {
                Position.x += 3;
                Instantiate(Fireball, Position, transform.rotation);
            } else if (facing == "left")
            {
                Position.x -= 3;
                Instantiate(Fireball, Position, transform.rotation);
            } else if (facing == "up")
            {
                Position.y += 3;
                Instantiate(Fireball, Position, transform.rotation);
            } else if (facing == "down")
            {
                Position.y -= 3;
                Instantiate(Fireball, Position, transform.rotation);
            }
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
