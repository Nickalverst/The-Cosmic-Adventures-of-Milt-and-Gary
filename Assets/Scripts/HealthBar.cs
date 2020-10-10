// Este script é responsável pelo elemento de interface do usuário "barra de vida".

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    // Definir a vida máxima
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Ajusta o slider de acordo com a currentHealth
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}