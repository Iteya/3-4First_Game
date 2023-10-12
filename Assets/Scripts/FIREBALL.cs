using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class FIREBALL : MonoBehaviour
{
    private float playerX;
    private float playerY;
    GameObject player;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerX = player.GetComponent<Transform>().transform.position.x;
        playerY = player.GetComponent<Transform>().transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject);
    }
}
