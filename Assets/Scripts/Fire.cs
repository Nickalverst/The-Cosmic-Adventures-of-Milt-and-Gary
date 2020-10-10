// Este script é responsável por criar o GameObject "fogo".

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float animLength;

    void Start()
    {
        Destroy(gameObject, animLength);
    }
}