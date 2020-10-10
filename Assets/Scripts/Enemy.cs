// Este script é responsável pela manutenção das estatísticas e movimento do inimigo.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxEnemyHealth = 100;
    public int currentEnemyHealth;
    public int enemyDamage = 2;

    public float multiplier = 3;

    public GameObject enemy;
    public EnemyGFX enemyGFX;
    public PlayerController Player;

    void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
    }

    // Dá dano ao inimigo
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Missile")
        {
            currentEnemyHealth -= Player.damage;
        }
    }

    // Lida com o impacto com o jogador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.currentHealth -= enemyDamage;
            Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(enemyGFX.xSpeed * multiplier, enemyGFX.ySpeed * multiplier));

            StartCoroutine( EnemyImpact() );
            StartCoroutine( Player.PlayerImpact() );
        }
    }

    // Desabilita o movimento temporariamente
    IEnumerator EnemyImpact()
    {
        enemyGFX.DisableMovement();
        enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(-enemyGFX.xSpeed * multiplier, -enemyGFX.ySpeed * multiplier));

        yield return new WaitForSeconds(2f);

        enemyGFX.EnableMovement();
    }
}