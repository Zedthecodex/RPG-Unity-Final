using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_End : MonoBehaviour
{
    SpriteRenderer sr;
    BoxCollider2D collider;

    void Start()
    {

        collider = GetComponent<BoxCollider2D>();
        collider.enabled = false;

        sr  = GetComponent<SpriteRenderer>();
        Color c = sr.material.color;
        c.a = 0f;
        sr.material.color = c;

    }

    // Update is called once per frame
    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1;f+=0.05f)
        {
            Color c = sr.material.color;
            c.a = f;
            sr.material.color = c;
        
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void startFading()
    {
        StartCoroutine("FadeIn");
        collider.enabled = true;
    }


    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            GameObject.Find("Canvas").GetComponent<UI>().SwitchOnWinScreen();
        }
    }
}
