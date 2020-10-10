// Este script é reponsável por lidar com os GameObjects "bomba" e "explosivo".

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject fire;

    public int firePower;
    public static float projectileSpeed = 10;

    public float fuse;

    float x,
        y;

    private GameObject bomb;
    private Rigidbody2D rb2d;

    void Start()    
    {
        rb2d = GetComponent<Rigidbody2D>();
        bomb = GetComponent<GameObject>();

        x = PlayerController.lastKeyX;
        y = PlayerController.lastKeyY;

        switch (PlayerController.lastKeyX)
        {
            case 1: break;
            case -1: bomb.transform.Rotate(0f, 0f, 90f, Space.Self); break;
        }

        // Previne o movimento diagonal da bomba
        if (Mathf.Abs(x) >= Mathf.Abs(y))
            y = 0;
        else if (Mathf.Abs(y) >= Mathf.Abs(x))
            x = 0;

        // Destroys GameObject and initiates animation
        Invoke("Explode", fuse);
    }

    private void Update()
    {
        // Calcula o movimento
        Vector2 movement = new Vector2(x, y) * projectileSpeed;

        // Define o movimento
        rb2d.velocity = movement;
    }

    void Explode()
    {
        Debug.Log("BOOM: " + firePower);

        // Cria o fogo central
        Instantiate(fire, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    // Explode a bomba quando uma colisão ocorre
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "PowerUp")
        {
            Explode();
        }
    }
}