using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
    public float scrollSpeed;
    public float tileSizeZ;
    private float newPosition;
    
    //public bool walking;

    private Vector3 startPosition;
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float v = Input.GetAxis("Vertical");
        if (v > 0) {
         newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
        }else if (v < 0)
        {
            newPosition = Mathf.Repeat(Time.time * -scrollSpeed, tileSizeZ);
            transform.position = startPosition + Vector3.forward * newPosition;
        }
        //startPosition += Vector3.forward;
       // transform.position = startPosition + Vector3.forward * newPosition;
    }
}
