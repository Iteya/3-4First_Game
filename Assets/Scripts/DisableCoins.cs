using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCoins : MonoBehaviour
{
    public GameObject[] coins;

    private void Start()
    {
        foreach (GameObject coin in coins)
        {
            coin.SetActive(false);
        }
    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("Collected") > 0)
        {
            foreach (GameObject coin in coins)
            {
                coin.SetActive(false);
            }
        }
    }
}
