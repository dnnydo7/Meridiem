using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    //private CharacterController controller;
    Rigidbody2D rb;
    private float gravity = 6f;
    //private float reverse;
    private float verticalVelocity;
    Animator anim;
    AudioSource playerAudio;
    //public AudioClip hey;
    public float speed;
    public float jumpForce;
    private float fallMultiplier = 2f;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = .2f;
    public LayerMask whatIsGround;

    // Use this for initialization
    void Start() {
        playerAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        if (move == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (move == 1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        bool walking = move != 0;
        anim.SetBool("Move", walking);
    }
    private void Update(){
        //if (controller.isGrounded)
        //{
        //    verticalVelocity = -gravity * Time.deltaTime;
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        verticalVelocity = jumpForce;
        //    }
        //}else{
        //    //provides a constant gravity force on player
        //    verticalVelocity -= gravity * fallMultiplier * Time.deltaTime;
        //}        
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
            // rb.velocity = movement * speed;
            // rb.AddForce(new Vector2(0, jumpForce));
            //transform.Translate(Vector2.up * jumpForce * Time.deltaTime, Space.World);
        }
        float v = Input.GetAxisRaw("Vertical");
        if (v == 1)
        {
            //reverses gravity
            Physics2D.gravity = new Vector2(0, 1.0F);
            playerAudio.Play();
            if(grounded == true)
            {
                transform.rotation = Quaternion.Euler(180, 0, 0);
            }   
        }
        if (v == -1)
        {
            //changes world gravity to normal            
            Physics2D.gravity = new Vector2(0, -1.0F);
            //changes player gravity back to normal
            //if(gravity < 0)
            //{
            //    gravity *= -1;
            //}
            //verticalVelocity -= gravity * fallMultiplier * Time.deltaTime;
            if (grounded == true)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        Animating(verticalVelocity, v);
    }

    void Animating(float vert, float v)
    {
        bool jumping = vert > 0f;
        anim.SetBool("Jump", jumping);
        bool down = v == -1;
        anim.SetBool("Down", down);
        bool rise = v == 1;
        anim.SetBool("Rise", rise);
    }
}