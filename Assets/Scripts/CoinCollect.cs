using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GlobalValues
{
    public static int coins;
}

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private Text coinsCollected;
             
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            GlobalValues.coins++;
            coinsCollected.text = "Coins: " + GlobalValues.coins;
        }
    }
}
