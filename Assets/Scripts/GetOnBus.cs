using UnityEngine;

public class GetOnBus : MonoBehaviour
{
    [SerializeField] private int busFare = 5;
    [SerializeField] private CoinCollect coincollect;
    private int coinsLoc;

    private void OnTriggerStay2D(Collider2D collision)
    {
        coinsLoc = coincollect.GetComponent<CoinCollect>().coins;
        if (collision.gameObject.CompareTag("Bus") && Input.GetKeyDown("space")
            && coinsLoc >= busFare)
        {
           coinsLoc -= busFare;
           coincollect.GetComponent<CoinCollect>().coinsCollected.text = "Coins: " + coinsLoc.ToString();
        }
    }
}
