using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_move_prototype : MonoBehaviour {

    public int playerSpeed = 10;
    public bool facingRight = true;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    private CharacterController controller;
    private float gravity = 6f;
    private float verticalVelocity;
    public float speed = 2f;
    public float jumpForce = 2f;
    private float fallMultiplier = 2f;

    // Update is called once per frame
    void Update ()
    {
        PlayerMove();
        PlayerRaycast();
	}

    void PlayerMove()
    {
        // CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown ("Jump") && isGrounded == true)
        {
            Jump();
        }

        // ANIMATIONS


        // PLAYER DIRECTION
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }

        // PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump ()
    {
        // JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    void FlipPlayer ()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
        }

        if ((col.gameObject.tag == "door") && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    void PlayerRaycast ()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.collider.tag == "enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hit.collider.gameObject.GetComponent<enemy_move>().enabled = false;
            // Destroy(hit.collider.gameObject);
        }

        if (hit.collider != null && hit.distance < 0.7f && hit.collider.tag != "enemy")
        {
            isGrounded = true;
        }

        // if (hit.collider.tag == "spikes")
        // {
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // }
    }

    IEnumerator SlowTime()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Time.timeScale = 0.2f;
            speed = 10f;
            gravity = 30f;
            jumpForce = 25f;
            fallMultiplier = 10f;
            yield return new WaitForSeconds(5);
            Time.timeScale = 1f;
            speed = 2f;
            gravity = 6f;
            jumpForce = 5f;
            fallMultiplier = 2f;
        }
    }

}
