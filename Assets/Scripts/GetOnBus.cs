using UnityEngine;

public class GetOnBus : MonoBehaviour
{
    [SerializeField] private int busFare = 5;
    [SerializeField] private CoinCollect coincollect;

    [SerializeField] private GameObject endpoint;
    [SerializeField] private float speed = 1f;

    private int coinsLoc;
    Rigidbody2D locPlayer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        coinsLoc = coincollect.GetComponent<CoinCollect>().coins;
        locPlayer = GetComponent<Rigidbody2D>();
        if (collision.gameObject.CompareTag("Bus") && Input.GetKey("space")
            && coinsLoc >= busFare)
        {
            coinsLoc -= busFare;
            coincollect.GetComponent<CoinCollect>().coinsCollected.text = "Coins: " + coinsLoc.ToString();
            
            busTrip(collision);
        }
    }

    private void busTrip(Collider2D collision)
    {
        Rigidbody2D locPlayer = GetComponent<Rigidbody2D>(); 
        transform.position = new Vector2(locPlayer.position.x, locPlayer.position.y + 0.1f);
        locPlayer.bodyType = RigidbodyType2D.Static;
        collision.gameObject.transform.SetParent(transform);

        transform.position = Vector2.MoveTowards(transform.position, endpoint.transform.position, 5);


    }
}
