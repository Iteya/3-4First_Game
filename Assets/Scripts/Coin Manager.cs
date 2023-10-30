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
            if (hud.CoinArray.Length == hud.coins)
            {
                Array.Resize(ref hud.CoinArray, hud.CoinArray.Length + 1);
            }
            hud.coins += 1;
            hud.CoinArray.AddRange(new GameObject[] {other.gameObject});
            other.gameObject.SetActive(false);
        }
    }
}