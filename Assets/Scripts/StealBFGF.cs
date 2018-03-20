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
    GameObject mage;
    GameObject bfgf;
    GameObject portal;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        mage = GameObject.Find("mage_dark");
        bfgf = GameObject.Find("knight");
        portal = GameObject.Find("Mirror");
        portal.SetActive(false);
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
            portal.SetActive(true);
            yield return new WaitForSeconds(1);
            bfgf.GetComponent<Rigidbody2D>().gravityScale = 0;
            bfgf.gameObject.transform.position = new Vector3(-3, 2.1f, 0);
            bfgf.gameObject.transform.localScale = new Vector3(4,4,0);
            yield return new WaitForSeconds(1);
            bfgf.gameObject.transform.localScale = new Vector3(3,3,0);
            yield return new WaitForSeconds(1);
            bfgf.gameObject.transform.localScale = new Vector3(2,2,0);
            yield return new WaitForSeconds(1);
            bfgf.gameObject.transform.localScale = new Vector3(1,1,0);
            //yield return new WaitForSeconds(1);

            bfgf.SetActive(false);
            anim.SetBool("Run", true);
            yield return new WaitForSeconds(1);
            transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            yield return new WaitForSeconds(1);
            transform.position = new Vector3(-3.5f, 2.4f, 0);
            anim.SetBool("Run", false);
            transform.localScale = new Vector3(4,4,0);
            yield return new WaitForSeconds(1);
            transform.localScale = new Vector3(3,3,0);
            yield return new WaitForSeconds(1);
            transform.localScale = new Vector3(2,2,0);
            yield return new WaitForSeconds(1);
            transform.localScale = new Vector3(1,1,0);
            //yield return new WaitForSeconds(1);

            mage.SetActive(false);
            first = false;
        }
    }
}
