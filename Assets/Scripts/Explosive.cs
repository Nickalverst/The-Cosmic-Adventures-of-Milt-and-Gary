// Este script é responsável pela animação da explosão do explosivo.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public GameObject fire;
    public GameObject fireCenter;
    public GameObject fireMiddleRight;
    public GameObject fireMiddleLeft;
    public GameObject fireMiddleUp;
    public GameObject fireMiddleDown;
    public GameObject fireEndUp;
    public GameObject fireEndDown;
    public GameObject fireEndRight;
    public GameObject fireEndLeft;

    public int firePower = 3;

    public float fuse;

    private Rigidbody2D rb2d;

    void Start()
    {
        // Destrói o GameObject e inicia a animação
        Invoke("Explode", fuse);
    }

    void Explode()
    {
        Debug.Log("BOOM: " + firePower);

        // Cria fogo central
        Instantiate(fireCenter, transform.position, Quaternion.identity);

        if(firePower == 2)
        {
            SpawnFire2();
        }
        // Cria resto do fogo
        if (firePower == 3)
        {
            SpawnFire3();
        }

        Destroy(gameObject);
    }

    private void SpawnFire2()
    {
        // Fim
        Instantiate(fireEndRight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 90));
        Instantiate(fireEndLeft, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, -90));
        Instantiate(fireEndUp, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.Euler(0, 0, 180));
        Instantiate(fireEndDown, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.Euler(0, 0, 0));
        Destroy(fireEndDown);
    }

    private void SpawnFire3()
    {
        // Meio
        Instantiate(fireMiddleRight, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 90));
        Instantiate(fireMiddleLeft, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, -90));
        Instantiate(fireMiddleUp, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.Euler(0, 0, 180));
        Instantiate(fireMiddleDown, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.Euler(0, 0, 0));
    
        // Fim
        Instantiate(fireEndRight, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 90));
        Instantiate(fireEndLeft, new Vector3(transform.position.x - 2, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, -90));
        Instantiate(fireEndUp, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.Euler(0, 0, 180));
        Instantiate(fireEndDown, new Vector3(transform.position.x, transform.position.y - 2, transform.position.z), Quaternion.Euler(0, 0, 0));
    }

     public void OnTriggerExit2D(Collider2D collision)
     {
        GetComponent<BoxCollider2D>().isTrigger = false;
     }
}