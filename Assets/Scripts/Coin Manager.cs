using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.SceneManagement.SceneManager;

public class CoinManager : MonoBehaviour
{
    public int coins;
    public TextMeshProUGUI coinsCollected;

    void Update()
    {
        string CoinString = coins.ToString();
        coinsCollected.text = "coins: " + CoinString;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coins += 1;
            other.gameObject.SetActive(false);
        }
    }
}