using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OrcPathfinding : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public bool dropsAxe;
    public bool aggro = false;
    public bool cansee = false;
    public int visionRange = 20;
    public string direction;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x)
        {
            if (SimpleRay(rb, transform.TransformDirection(Vector3.left), visionRange))
            {
                direction = "left";
            }
        } else if (player.transform.position.x > transform.position.x)
        {
            if (SimpleRay(rb, transform.TransformDirection(Vector3.right), visionRange))
            {
                direction = "right";
            }
        }
        if (player.transform.position.y < transform.position.y)
        {
            if (SimpleRay(rb, transform.TransformDirection(Vector3.left), visionRange))
            {
                direction = "down";
            }
        } else if (player.transform.position.y > transform.position.y)
        {
            if (SimpleRay(rb, transform.TransformDirection(Vector3.left), visionRange))
            {
                direction = "up†";
            }
        }
        
    }

    private bool SimpleRay(Rigidbody2D rb, Vector3 direction, int range)
    {
        RaycastHit hit;
        if (Physics2D.Raycast(rb.position, direction, range))
        {
            return true;
        }else
        {
            return false;
        }
    }
}
