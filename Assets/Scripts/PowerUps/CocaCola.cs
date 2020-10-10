// Este script é responsável pelo coletável "energético".

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocaCola : MonoBehaviour
{
    //public GameObject pickupEffect;

    public float multiplier = 2f;
    public float duration = 4f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine( Pickup() );
        }
    }

    IEnumerator Pickup()
    {
        // Spawn effect
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        // Aplica o efeito ao jogador
        BombSpawner.bombsPerSecond /= multiplier;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        BombSpawner.bombsPerSecond *= multiplier;

        // Remove o objeto coletável
        Destroy(gameObject);
    }
}