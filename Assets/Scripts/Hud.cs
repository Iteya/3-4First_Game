using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hud : MonoBehaviour
{
    public bool[][] coinData;
    public int health;
    public int coins;
    public int levelCount;
    public int[] coinsPerLevel;
    public List<string> enemies;
    public int idInt = 0;
    
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

        coinData = new bool[levelCount][];
        for (int i = 0; i < levelCount; i++)
        {
            coinData[i] = new bool[coinsPerLevel[i]];
        }
    }

    void Update()
    {
        string CoinString = coins.ToString();
        coinsCollected.text = "coins: " + CoinString;
        
        string healthString = hud.health.ToString();
        healthLeft.text = "Health: " + healthString;
    }
}
