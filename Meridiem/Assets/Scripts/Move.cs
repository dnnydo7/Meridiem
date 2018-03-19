using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    //private CharacterController controller;
    Rigidbody2D rb;
    private float gravity = 6f;
    private float verticalVelocity;
    Animator anim;
    AudioSource playerAudio;
    //public AudioClip hey;
    public float speed;
    public float jumpForce;
    private float fallMultiplier = 2f;
    bool grounded = false;
    //bool top = false;
    public Transform groundCheck;
    //public Transform topCheck;
    float groundRadius = .2f;
    public LayerMask whatIsGround;
    bool flip = false;

    // Use this for initialization
    void Start() {
        playerAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //top = Physics2D.OverlapCircle(topCheck.position, groundRadius, whatIsGround);
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
    void OnTriggerEnter(Collider other)
    {
        //if (top)
        //{
        //    transform.rotation = Quaternion.Euler(180, 0, 0);
        //}else if (grounded)
        //{
        //    transform.rotation = Quaternion.Euler(0, 0, 0);
        //}
        //transform.rotation = Quaternion.Euler(180, 0, 0);
        //float v = Input.GetAxisRaw("Vertical");
        //if (other.gameObject.CompareTag("Forest"))
        //{
        //    print("hi");
        //    if(v == 1)
        //    {
        transform.rotation = Quaternion.Euler(180, 0, 0);
            //    }else if(v == -1)
            //    {
            //      transform.rotation = Quaternion.Euler(0, 0, 0);
            //    }
            //    flip = false;
        //}
    }
    private void Update(){
             
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        float v = Input.GetAxisRaw("Vertical");
        if (v == 1)
        {
            //reverses gravity
            Physics2D.gravity = new Vector2(0, 1.0F);
            playerAudio.Play();
            if (!grounded)
            {
                transform.rotation = Quaternion.Euler(180, 0, 0);
            }
            
        }else if (v == -1)
        {
            //changes world gravity to normal      
            if (!grounded)
            {
                Physics2D.gravity = new Vector2(0, -1.0F*fallMultiplier);
            }else if(grounded)
            {
                Physics2D.gravity = new Vector2(0, -1.0F);
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
        anim.SetBool("Rise", down);
        bool rise = v == 1;
        anim.SetBool("Rise", rise);
    }
}