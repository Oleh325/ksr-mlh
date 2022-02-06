using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
    public int coins = 0;
    public Text coinsCollected;
             
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
            coinsCollected.text = "Coins: " + coins.ToString();
        }
    }

    private void Update()
    {
        
    }
}
