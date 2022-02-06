    using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask buildingsLayer;
    private Rigidbody2D player;
    private BoxCollider2D collider2d;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, player.velocity.y);

        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.07521388f, 0.139201f, 1);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.07521388f, 0.139201f, 1);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("up") && IsGrounded())
        {
            player.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider2d.bounds.center, collider2d.bounds.size, 0f, Vector2.down, 0.1f, buildingsLayer);
    }


}
