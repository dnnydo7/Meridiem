using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crunch : MonoBehaviour {
    public AudioClip crunch;
    void Start () {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = crunch;
    }
    void OnTriggerEnter2D(Collider2D other)  //Plays Sound Whenever collision detected
    {
        if (other.gameObject.CompareTag("Fruit"))
        {
            other.gameObject.SetActive(false);
            GetComponent<AudioSource>().Play();
            
        }
        
    }
}
