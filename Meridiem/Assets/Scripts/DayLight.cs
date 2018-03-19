using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayLight : MonoBehaviour {
    public GameObject lightEnemy= null;
    public GameObject darkEnemy=null;
    public Light lit;
    public Color day = Color.cyan;
    public Color night = Color.blue;
	// Use this for initialization
	void Start () {
        //lit = GetComponent<Light>();
        lightEnemy = GameObject.FindWithTag("Day");
        darkEnemy = GameObject.FindWithTag("Night");
	}	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            //night -> day
            if(lightEnemy.GetComponent<SpriteRenderer>().enabled == true){                
                lit.color = day;
                lightEnemy.GetComponent<SpriteRenderer>().enabled = false;
                darkEnemy.GetComponent<SpriteRenderer>().enabled = true;
                //day -> night
            }
            else if(darkEnemy.GetComponent<SpriteRenderer>().enabled == true){
                lit.color = night;
                darkEnemy.GetComponent<SpriteRenderer>().enabled = false;
                lightEnemy.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
	}
}
