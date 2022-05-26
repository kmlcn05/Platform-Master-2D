using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator anim;
    private Health health;

    public bool landed;

    private float dirX = 0f;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float jump = 10f;  

    private enum MovementState { Idle, Walk, Jump, Fall}


    [SerializeField] 
    private AudioSource jumpSoundEffect;
    //private MovementState state = MovementState.Idle;
    
    [SerializeField] 
    private AudioSource dieSoundEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();


        health.OnDie += OnDie;
        
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        if(rb.bodyType == RigidbodyType2D.Dynamic)
            rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && landed)
        {
            if(rb.bodyType == RigidbodyType2D.Dynamic)
            {
                
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jump);

            }

        }

        UpdateAnimaUpdate();
    }

    private void UpdateAnimaUpdate()
    {
        MovementState state;


        if (dirX > 0f)
        {
            state = MovementState.Walk;
            //anim.SetBool("Walk", true);
            sp.flipX = false;
        }

        else if (dirX < 0f)
        {
            state = MovementState.Walk;
            //anim.SetBool("Walk", true);
            sp.flipX = true;
        }

        else
        {
            state = MovementState.Idle;
            //anim.SetBool("Walk", false);
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.Jump;

        }

        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.Fall;
        }

        anim.SetInteger("state", (int)state);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            landed = true;
            

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            landed = false;
            
        }
    }
    public void OnDie() {

        rb.bodyType = RigidbodyType2D.Static;
        dieSoundEffect.Play();
    }
}
