// Este script é responsável pelo coletável "barra de chocolate".

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateBar : MonoBehaviour
{
    public int healthPack = 20;

    //public GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider2D player)
    {
        // Spawn effect
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        // Aplica o efeito ao jogador
        PlayerController stats = player.GetComponent<PlayerController>();
        if (stats.currentHealth <= stats.maxHealth - healthPack)
        {
            stats.currentHealth += healthPack;
        } else
        {
            stats.currentHealth = stats.maxHealth;
        }

        // Remove o objeto de power-up
        Destroy(gameObject);
    }
}