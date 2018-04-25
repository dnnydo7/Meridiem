using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayLight : MonoBehaviour {
    public GameObject lightEnemy;
    public GameObject darkEnemy;
    public GameObject day;
    public GameObject night;
    //public Light lit;
    //public Color day = Color.cyan;
    //public Color night = Color.blue;
	// Use this for initialization
	void Start () {
        //lit = GetComponent<Light>();
        lightEnemy = GameObject.FindWithTag("Day");
        darkEnemy = GameObject.FindWithTag("Night");
	}	
	// Update is called once per frame
	void Update () {        
        if (Input.GetKeyDown(KeyCode.E)){
            //night -> day
            if(night.gameObject.activeSelf == true){
                //lit.color = day;
                day.SetActive(true);
                night.SetActive(false);
                lightEnemy.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                darkEnemy.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            //day -> night
            else if (day.gameObject.activeSelf == true)
            {
                //lit.color = night;
                day.SetActive(false);
                night.SetActive(true);
                lightEnemy.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                darkEnemy.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
	}
}
