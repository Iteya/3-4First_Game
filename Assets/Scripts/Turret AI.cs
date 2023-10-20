using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    GameObject player;

    public GameObject fireball;
    private bool WillFire = false;
    private int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FIREBALL());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            WillFire = true;
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            WillFire = false;
        }
    }

    IEnumerator FIREBALL()
    {
        while (a == 0)
        {
            if (WillFire == true)
            {
                yield return new WaitForSeconds(1f);
                Instantiate(fireball);
            }

            yield return null;
        }
    }
}
