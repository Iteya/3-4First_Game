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

    void Update()
    {
        if (inCaves)
        {
            ySpeed = 0;
        }
        transform.Translate((Input.GetAxis("Horizontal")* xSpeed )*Time.deltaTime, (Input.GetAxis("Vertical") * ySpeed) * Time.deltaTime, 0);
    }
}
