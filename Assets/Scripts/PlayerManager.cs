using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask buildingsLayer;
    [SerializeField] private GameObject loserMenu;
    [SerializeField] private GameObject canvas;
    [SerializeField] private CameraController cmrctrl;
    private Rigidbody2D player;
    private BoxCollider2D collider2d;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, player.velocity.y);

        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.3348586f, 0.3348586f, 1);
            anim.SetBool("isRunning", true);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.3348586f, 0.3348586f, 1);
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("up") && IsGrounded())
        {
            player.AddForce(new Vector2(0, 9), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider2d.bounds.center, collider2d.bounds.size, 0f, Vector2.down, 0.1f, buildingsLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            transform.position = new Vector3(690.5f, -170f, -8);
            canvas.SetActive(true);
            loserMenu.SetActive(true);
            cmrctrl.GetComponent<CameraController>().Pause();
        }
    }
}
