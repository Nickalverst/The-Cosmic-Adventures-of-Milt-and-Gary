﻿// Este script é responsável pelo coletável "morfina".

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morphine : MonoBehaviour
{
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
        stats.isPoisoned = false;

        // Remove o objeto coletável
        Destroy(gameObject);
    }
}
