using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Hud : MonoBehaviour
{
    public GameObject[] CoinArray;
    public int health;
    public int coins;
    
    public TextMeshProUGUI coinsCollected;
    public TextMeshProUGUI healthLeft;
    
    
    public static Hud hud;

    private void Awake()
    {
        if (hud != null && hud != this)
        {
            Destroy(gameObject);
        }
        else
        {
            hud = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        string CoinString = coins.ToString();
        coinsCollected.text = "coins: " + CoinString;
        
        string healthString = hud.health.ToString();
        healthLeft.text = "Health: " + healthString;
    }
}
