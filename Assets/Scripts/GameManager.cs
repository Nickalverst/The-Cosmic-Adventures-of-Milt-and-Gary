// Este script é responsável pelo gerenciamento do estado atual do jogo.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false; // Jogo terminou
    public float restartDelay = 1f; // Tempo para a fase (cena) reiniciar

    public PlayerController player;

    // Verifica se deve-se terminar o jogo ou reiniciar a fase (cena)
    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;

            if(player.hearts >= 0)
            {
                Debug.Log("You have died!");
                Invoke("Restart", restartDelay);
                player.hearts--;
            }
            else
            {
                Invoke("GameOver", restartDelay);
            }
        }
    }

    // Reinicia a cena
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Finaliza o jogo
    void GameOver()
    {
        Debug.Log("The game is over!");
    }
}