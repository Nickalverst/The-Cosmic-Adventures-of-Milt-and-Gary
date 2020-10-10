// Este script é responsável pelo menu principal.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Botão "Jogar"
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Botão "Sair"
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit.");
    }
}