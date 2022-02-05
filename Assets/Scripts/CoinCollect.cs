using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GlobalValues
{
    public static int coins = 0;
}

public class CoinCollect : MonoBehaviour
{
    public Text coinsCollected;
             
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            GlobalValues.coins++;
        }
    }

    private void Update()
    {
        coinsCollected.text = "Coins: " + GlobalValues.coins;
    }
}
