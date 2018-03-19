using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealBFGF : MonoBehaviour
{
    float Speed = 2.0f;
    bool first = true;
    bool canFade = false;
    float timeToFade = 1.0f;
    Color alphaColor;
    Animator anim;
    GameObject bfgf;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        bfgf = GameObject.Find("knight");
        alphaColor = bfgf.GetComponent<SpriteRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CutScene());
    }

    IEnumerator CutScene()
    {
        if (first)
        {
            anim.SetBool("Push", true);
            yield return new WaitForSeconds(1);
            anim.SetBool("Push", false);
            bfgf.GetComponent<Rigidbody2D>().gravityScale = 0;
            bfgf.gameObject.transform.localScale = new Vector3(4,4,0);
            yield return new WaitForSeconds(1);
            bfgf.gameObject.transform.localScale = new Vector3(3,3,0);
            yield return new WaitForSeconds(1);
            bfgf.gameObject.transform.localScale = new Vector3(2,2,0);
            yield return new WaitForSeconds(1);
            bfgf.gameObject.transform.localScale = new Vector3(1,1,0);
            yield return new WaitForSeconds(1);

            bfgf.SetActive(false);
            anim.SetBool("Run", true);
            transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            yield return new WaitForSeconds(1);
            anim.SetBool("Run", false);
            first = false;
        }
    }
}
