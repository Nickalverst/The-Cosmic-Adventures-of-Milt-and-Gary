// Este script é responsável pelo comportamento do objeto destrutível "caixa".

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D box;

    public float destroyBoxAnimLenght = 0.3f;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Missile")
        {
            box.enabled = false;
            anim.SetTrigger("Destroy");
            Invoke( "DestroyBox" , destroyBoxAnimLenght);
        }
    }

    public void DestroyBox()
    {
        Destroy(gameObject);
    }
}
