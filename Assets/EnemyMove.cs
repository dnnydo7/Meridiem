using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public float speed;
    Rigidbody2D rb;
    Transform trans;
    float myWidth;
    public LayerMask enemyMask;
    
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        trans = transform;
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
    }
    private void FixedUpdate()
    {
        //check for objects
        Vector2 lineCastPos = trans.position + trans.right;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        //bool touch = Physics2D.Linecast(lineCastPos, lineCastPos + trans.right, enemyMask);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - trans.right.toVector2() * .05f, enemyMask);
        rb.velocity = new Vector2(trans.right.x*speed, 0f);
        //if it touches
        if (isBlocked)
        {
            Vector3 rotate = trans.eulerAngles;
            rotate.y += 180;
            trans.eulerAngles = rotate;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    Destroy(collision.gameObject);
        //}
        //else
        //{
        //    Vector3 rotate = trans.eulerAngles;
        //    rotate.y += 180;
        //    trans.eulerAngles = rotate;
        //}
        Vector3 rotate = trans.eulerAngles;
        rotate.y += 180;
        trans.eulerAngles = rotate;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
