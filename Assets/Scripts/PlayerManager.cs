using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask buildingsLayer;
    private Rigidbody2D player;
    private BoxCollider2D collider2d;
    private int coffesec = 0;
    private float jumpForce = 6.0f;
    private int UnmbrelluNum = 0;
    private float rainchance = 1.0f;
    private ParticleSystem particle;
    private bool check = false;


    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<BoxCollider2D>();
        StartCoroutine(coffeclock());
        particle = GameObject.Find("Rain").GetComponent<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        if (particle.isPlaying && UnmbrelluNum<=0){
            check = false;
            rainchance = 0.5f;
        } else if(particle.isPlaying && UnmbrelluNum>0){
            check = true;
        } else {
            if (check){
                UnmbrelluNum--;
                check = false;
            }
            rainchance = 1;
        }
        player.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * rainchance, player.velocity.y);
        

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
            player.AddForce(new Vector2(0, jumpForce * rainchance), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider2d.bounds.center, collider2d.bounds.size, 0f, Vector2.down, 0.1f, buildingsLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Umbrella")){
                Destroy(collision.gameObject);
                UnmbrelluNum++;
                jumpForce = 3.5f;
                player.gravityScale = 1.0f;

        }

        if (collision.gameObject.CompareTag("coffe")){
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
