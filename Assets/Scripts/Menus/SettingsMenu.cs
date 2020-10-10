// Este script é responsável pelo menu de configurações do jogo.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        // Define a resolução correta
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options); // Adiciona a lista ao menu
        resolutionDropdown.value = currentResolutionIndex; // Seleciona a resolução correta
        resolutionDropdown.RefreshShownValue(); // Mostra a resolução correta no menu
    }

    // Controla a resolução do jogo
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Controla volume
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    // Controla qualidade
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Controla o modo de exibição
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}