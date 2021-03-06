using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask jumpableLayer;
    [SerializeField] private GameObject loserMenu;
    [SerializeField] private GameObject winnerMenu;
    [SerializeField] private GameObject canvas;
    [SerializeField] private CameraController cmrctrl;
    private Rigidbody2D player;
    private BoxCollider2D collider2d;
    private int coffesec = 0;
    private float jumpForce = 9.0f;
    private int UnmbrelluNum = 0;
    private float rainPercent = 1.0f;
    private ParticleSystem particle;
    private bool checkUmbrellaUsing = false;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<BoxCollider2D>();
        //StartCoroutine(coffeclock());
        //particle = GameObject.Find("Rain").GetComponent<ParticleSystem>();

    }

    private void FixedUpdate()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        //if (particle.isPlaying && UnmbrelluNum <= 0)
        //{
        //    checkUmbrellaUsing = false;
        //    rainPercent = 0.5f;
        //}
        //else if (particle.isPlaying && UnmbrelluNum > 0)
        //{
        //    checkUmbrellaUsing = true;
        //    rainPercent = 1;
        //}
        //else
        //{
        //    if (checkUmbrellaUsing)
        //    {
        //        UnmbrelluNum--;
        //        checkUmbrellaUsing = false;
        //    }
        //    rainPercent = 1;
        //}
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
            player.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider2d.bounds.center, collider2d.bounds.size, 0f, Vector2.down, 0.1f, jumpableLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            transform.position = new Vector3(690f, -170f, -8);
            canvas.SetActive(true);
            loserMenu.SetActive(true);
            cmrctrl.GetComponent<CameraController>().Pause();
        }
        if (collision.gameObject.tag == "Win")
        {
            transform.position = new Vector3(690f, -170f, -8);
            canvas.SetActive(true);
            winnerMenu.SetActive(true);
            cmrctrl.GetComponent<CameraController>().Pause();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Umbrella")){
                Destroy(collision.gameObject);
                UnmbrelluNum++;
                jumpForce = 3.5f;
                player.gravityScale = 1.0f;

        }

        if (collision.gameObject.CompareTag("Coffe")){
                Destroy(collision.gameObject);
                speed = speed * 1.5f;
                StartCoroutine(coffeclock());
                coffesec = 0;
                
        }
    }

    IEnumerator coffeclock(){
        while(true){
            coffesec++;
            if (coffesec == 20){
                coffesec = 0;
                if (speed > 2.5f){
                    speed = speed / 1.5f;
                }
                
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
