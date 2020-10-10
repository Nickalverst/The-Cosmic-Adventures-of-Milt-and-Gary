using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : MonoBehaviour
{
    public float multiplier = 2f;
    public float duration = 4f;

    //public GameObject pickupEffect;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine( Pickup(other) );
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        // Spawn effect
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        // Apply effect to player
        PlayerController stats = player.GetComponent<PlayerController>();
        stats.speed *= multiplier;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.speed /= multiplier;

        // Remove power up object
        Destroy(gameObject);
    }
}