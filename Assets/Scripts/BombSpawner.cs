// Este script é responsável por criar os GameObjects "bomba" e "explosivo" e aplicar sobre ele as tranformações e forças adequadas.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
	
	public GameObject bomb_right;
    public GameObject bomb_left;
    public GameObject bomb_up;
    public GameObject bomb_down;
    public GameObject explosive;

    public int firePower = 1;
	public static float numberOfBombs = 1;
    public static float bombsPerSecond = 1;
    public float animLenght = 0.15f;
    public int numberOfExplosives = 3;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && numberOfBombs >= 1)
        {
            Vector2 bombSpawnPos = new Vector2(transform.position.x + PlayerController.lastKeyX, transform.position.y + PlayerController.lastKeyY); // Calcula a posição de criação da bomba
            if (PlayerController.lastKeyX == 1)
            {
                var newBomb = Instantiate(bomb_right, bombSpawnPos, Quaternion.identity) as GameObject; // Instancia a bomba como GameObject à direita do jogador
                newBomb.GetComponent<Bomb>().firePower = firePower;
            }
            else if (PlayerController.lastKeyX == -1)
            {
                var newBomb = Instantiate(bomb_left, bombSpawnPos, Quaternion.identity) as GameObject; // Instancia a bomba como GameObject à esquerda do jogador
                //newBomb.GetComponent<Bomb>().firePower = firePower;
            }
            else if (PlayerController.lastKeyY == 1)
            {
                var newBomb = Instantiate(bomb_up, bombSpawnPos, Quaternion.identity) as GameObject; // Instancia a bomba como GameObject acima do jogador
                //newBomb.GetComponent<Bomb>().firePower = firePower;
            }
            else if (PlayerController.lastKeyY == -1)
            {
                var newBomb = Instantiate(bomb_down, bombSpawnPos, Quaternion.identity) as GameObject; // Instancia a bomba como GameObject abaixo do jogador
                //newBomb.GetComponent<Bomb>().firePower = firePower;
            }

            numberOfBombs--;
        	Invoke("AddBomb", bombsPerSecond);

            switch (PlayerController.lastKeyY)
            {
                case -1: StartCoroutine(Shoot()); break;
                case 1: StartCoroutine(ShootUp()); break;
            }
            switch (PlayerController.lastKeyX)
            {
                case -1: StartCoroutine(ShootLeft()); break;
                case 1: StartCoroutine(ShootRight()); break;
            }
        }

        if (Input.GetButtonDown("Fire2") && numberOfExplosives >= 1)
        {
            Vector2 explosiveSpawnPos = new Vector2(transform.position.x, transform.position.y); // Calcula a posição de criação do explosivo
            var newExplosive = Instantiate(explosive, explosiveSpawnPos, Quaternion.identity) as GameObject; // Instancia a bomba como GameObject na posicão calculada
            numberOfExplosives--;
        }
    }

    IEnumerator Shoot()
    {
        animator.SetTrigger("Shoot");
        yield return new WaitForSeconds(animLenght);
        animator.SetTrigger("Shoot");
    }

    IEnumerator ShootUp()
    {
        animator.SetTrigger("ShootUp");
        yield return new WaitForSeconds(animLenght);
        animator.SetTrigger("ShootUp");
    }

    IEnumerator ShootLeft()
    {
        animator.SetTrigger("ShootLeft");
        yield return new WaitForSeconds(animLenght);
        animator.SetTrigger("ShootLeft");
    }

    IEnumerator ShootRight()
    {
        animator.SetTrigger("ShootRight");
        yield return new WaitForSeconds(animLenght);
        animator.SetTrigger("ShootRight");
    }

    public void AddBomb()
    {
    	numberOfBombs++;
    }
}