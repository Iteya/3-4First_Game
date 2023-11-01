using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using static UnityEngine.SceneManagement.SceneManager;

public class CoinManager : MonoBehaviour
{
    public Hud hud;

    private void Start()
    {
        hud = GameObject.FindObjectOfType<Hud>();
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            hud.coinData[other.gameObject.GetComponent<CoinID>().currentLevel][other.gameObject.GetComponent<CoinID>().id] = true;
            hud.coins += 1;
            other.gameObject.SetActive(false);
        }
    }
}