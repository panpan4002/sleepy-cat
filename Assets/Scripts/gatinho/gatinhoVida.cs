using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatinhoVida : MonoBehaviour
{

    [Header("Vida")]
    [SerializeField] public float vidaMaxima;
    [SerializeField] public float vida;

    void Start()
    {
        vida = vidaMaxima;
    }

    void Update()
    {
        if(vida <= 0) 
        {
            Debug.Log("e morreu");
            Time.timeScale = 0;
        }
    }

    public void LevarDano(float dano) 
    {
        vida -= dano;
    }
}
