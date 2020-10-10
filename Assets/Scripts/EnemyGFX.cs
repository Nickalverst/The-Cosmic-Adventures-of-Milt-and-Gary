// Este script é responsável pela animação do GameObject "Enemy".

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    public Animator animator;
    public Enemy enemy;
    public GameObject Enemy;

    public float deathAnimLength = 0.3f;
    public float xSpeed;
    public float ySpeed;

    private bool isDying = false;

    void Update()
    {
        if (!isDying)
        {
            animator.SetFloat("Horizontal", aiPath.desiredVelocity.x);
            animator.SetFloat("Vertical", aiPath.desiredVelocity.y);
            animator.SetFloat("Speed", aiPath.desiredVelocity.sqrMagnitude);
        }
        if (enemy.currentEnemyHealth <= 0 && !isDying)
        {
            aiPath.canMove = false;
            animator.SetTrigger("Death");
            Invoke("EnemyDeath", deathAnimLength);
        }

        xSpeed = aiPath.desiredVelocity.x;
        ySpeed = aiPath.desiredVelocity.y;
    }


    // Mata o inimigo
    void EnemyDeath()
    {
        Destroy(gameObject);
        Destroy(Enemy);
    }

    // Desabilita o movimento
    public void DisableMovement()
    {
        aiPath.canMove = false;
    }

    // Habilita o movimento
    public void EnableMovement()
    {
        aiPath.canMove = true;
        Debug.Log("MOVEMENT RE ENABLEEEEEEDDD!!!!!!!!");
    }
}