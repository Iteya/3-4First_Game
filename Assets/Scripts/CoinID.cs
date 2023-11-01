using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinID : MonoBehaviour
{
    public int id;
    public int currentLevel;

    private void Awake()
    {
        GameObject hud = GameObject.FindGameObjectWithTag("DDOL");

        if (hud.GetComponent<Hud>().coinData[currentLevel][id])
        {
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
