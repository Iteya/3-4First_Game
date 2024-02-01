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
        Debug.DrawRay(Position, Vector2.down * distance, Color.blue, 0.5f);
        Position = transform.position;
        Target = Position;
        if (inCaves)
        {
            transform.Translate((Input.GetAxis("Horizontal") * xSpeed) * Time.deltaTime, 0, 0);
            RaycastHit hit;
            if (Input.GetAxisRaw("Vertical") > 0.5 && (grounded || Physics2D.Raycast(rb.position, Vector2.down, col.bounds.extents.y - .1f, layer) == true))
            {
                if (rb.velocity.y > -0.1f || 0.1f > rb.velocity.y)
                {
                    rb.velocity = new Vector2(rb.velocity.x, Jumpstrength);
                    grounded = false;
                }
                
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
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
