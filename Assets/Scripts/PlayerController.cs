// Este script é responsável pela manutenção das estatísticas e movimento do jogador. Exclusivamente pt-BR e en-US.
// This script is responsible for the player's statistics management and movement. Exclusively pt-BR and en-US.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour   
{
    private Rigidbody2D rb2d;

    // Estatísticas do jogador
    public float speed = 5f;
    public float poisonFrequency = 5;
    public float stunDuration = 0.5f;
    public float deathAnimLength = 1f;

    public int currentHealth;
    public int maxHealth = 5;
    public int poisonedHealthLoss = 1;
    public int hearts;
    public int damage = 50;

    public bool isPoisoned = false;
    private bool poisonedIsActive = false;
    private bool isStunned = false;
    private bool isDying = false;

    public HealthBar healthBar;
    private Animator animator;

    public static float lastKeyX;
    public static float lastKeyY;

    Vector2 movement;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        StartCoroutine("Poisoned");
    }

    void FixedUpdate()
    {
        // Obtém a entrada do jogador
        // Gets input from player
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Previne o movimento diagonal do jogador
        // Prevents player's diagonal movement
        if (Mathf.Abs(x) >= Mathf.Abs(y))
            y = 0;
        else if (Mathf.Abs(y) >= Mathf.Abs(x))
            x = 0;

        // Calcula o movimento
        // Calculates movement
        Vector2 movement = new Vector2(x, y) * speed;

        if (!isStunned)
        {
            // Define o movimento
            // Sets movement
            rb2d.velocity = movement;
        }

        // Obtém a direção para a qual o jogador está olhando
        // Gets direction player is looking
        if (x == 1 || x == -1)
        {
            lastKeyX = Input.GetAxisRaw("Horizontal");
            lastKeyY = 0;
        }
        if (y == 1 || y == -1)
        {
            lastKeyY = lastKeyY = Input.GetAxisRaw("Vertical");
            lastKeyX = 0;
        }

        // Verifica se o jogador está envenenado e habilida Poisoned caso esteja
        // Checks if the player is poisoned and enables Poisoned if so
        if (isPoisoned == true && poisonedIsActive == false)
        {
            StartCoroutine("Poisoned");
            poisonedIsActive = true;
        }

        // Verifica se o jogador está envenenado e desabilita Poisoned caso não
        // Checks if the player is poisoned and disables Poisoned if not
        if (isPoisoned == false){
            poisonedIsActive = false;
        }

        // Verifica se o jogador está vivo e ativa EndGame caso não
        // Checks if the player is alive and triggers EndGame if not
        if (currentHealth <= 0)
        {
            // Desativar movimento | Disable movement
            // Tocar animação | Play animation
            FindObjectOfType<GameManager>().EndGame();
        }

        healthBar.SetHealth(currentHealth);
    }

    private void Update()
    {
        if (!isDying)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        if (currentHealth <= 0 && !isDying)
        {
            isStunned = true;
            animator.SetTrigger("Death");
            Invoke("PlayerDeath", deathAnimLength);
            rb2d.velocity = new Vector2(0, 0);
        }

        movement.x = Input.GetAxisRaw("Horizontal"); // Número entre -1 (esquerda) e 1 (direita) | Number between -1 (left) and 1 (right)
        movement.y = Input.GetAxisRaw("Vertical"); // Número entre -1 (baixo) e 1 (cima) | Number between -1 (down) and 1 (up)

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    // Dá dano de veneno no jogador
    // Deals poison damage to the player
    IEnumerator Poisoned()
    {
        while(isPoisoned == true)
        {
            currentHealth -= poisonedHealthLoss; // Dar x dano | Deal x damage
            yield return new WaitForSeconds(poisonFrequency); // Esperar x segundos | Wait x seconds
        }
        
        if (isPoisoned == false || currentHealth <= 0)
        {
            yield break;
        }
    }

    // Desabilita o movimento por stunDuration segundos
    // Disables movement for stunDuration seconds
    public IEnumerator PlayerImpact()
    {
        isStunned = true;

        yield return new WaitForSeconds(stunDuration);

        isStunned = false;
    }

    public void PlayerDeath()
    {
        Destroy(gameObject);
    }
}