﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    private CharacterController controller;
    private float gravity = 6f;
    private float verticalVelocity;
    Animator anim;
    AudioSource playerAudio;
    //public AudioClip hey;
    public float speed;    
    public float jumpForce;
    private float fallMultiplier = 2f;
    // Use this for initialization
    void Start () {
        playerAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }	
	// Update is called once per frame
    private void Update () {
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;

            }
        }
        else
        {
            verticalVelocity -= gravity *fallMultiplier* Time.deltaTime;
        }        
        Vector2 moveVector = Vector2.zero;
        moveVector.x = Input.GetAxisRaw("Horizontal")*speed;
        moveVector.y = verticalVelocity;
        controller.Move(moveVector * Time.deltaTime);
        float h = Input.GetAxisRaw("Horizontal");
        if (h == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (h == 1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        float v = Input.GetAxisRaw("Vertical");
        if(v == 1)
        {
            Physics.gravity = new Vector3(0, 1.0F, 0);
           // playerAudio.clip = hey;
            playerAudio.Play();
        }
        if (v == -1)
        {
            Physics.gravity = new Vector3(0, -1.0F, 0);
        }
        Animating(h, verticalVelocity, v);
    }
    void Animating(float h, float vert, float v)
    {
        bool walking = h != 0f;
        anim.SetBool("Move", walking);
        bool jumping = vert > 0f;
        anim.SetBool("Jump", jumping);
        bool down = v == -1;
        anim.SetBool("Down", down);
        bool rise = v == 1;
        anim.SetBool("Rise", rise);
    }
}
