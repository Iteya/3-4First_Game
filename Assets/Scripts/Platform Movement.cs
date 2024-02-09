using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.SceneManagement.SceneManager;
using Random = UnityEngine.Random;

public class PlatformMovement : MonoBehaviour
{
    public Collider2D col;
    public Rigidbody2D rb;
    public bool inCaves;
    public int ySpeed;
    public int xSpeed;
    private bool grounded = false;
    public Vector2 Position; 
    public Vector2 Target;
    public GameObject Fireball;
    public float distance;
    public LayerMask layer;
    [SerializeField] private float Jumpstrength;

    void Update()
    {
        Debug.DrawRay(rb.position, Vector2.down * (col.bounds.extents.y + .1f), Color.red);
        Position = transform.position;
        Target = Position;
        if (inCaves)
        {
            transform.Translate((Input.GetAxis("Horizontal") * xSpeed) * Time.deltaTime, 0, 0);
            RaycastHit hit;
            if (Input.GetAxisRaw("Jump") != 0 && grounded)
            {
                    rb.velocity = new Vector2(rb.velocity.x, Jumpstrength);
                    grounded = false;
            }
        }
        else
        {
            transform.Translate((Input.GetAxis("Horizontal") * xSpeed) * Time.deltaTime,
                (Input.GetAxis("Vertical") * ySpeed) * Time.deltaTime, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Fireball, Position, transform.rotation);
        }

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (Physics2D.Raycast(rb.position, Vector2.down, col.bounds.extents.y + .1f, layer))
        {
            grounded = true;
        }
    }
}
