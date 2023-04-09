using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatinhoVida : MonoBehaviour
{

    [Header("Vida")]
    [SerializeField] public float vidaMaxima;
    [SerializeField] public float vida;

    private bool imune;

    void Start()
    {
        vida = vidaMaxima;
        imune = false;
    }

    void Update()
    {
        if(vida <= 0) 
        {
            //Debug.Log("e morreu");
            Time.timeScale = 0;
        }
    }

    public void LevarDano(float dano) 
    {
        if(!imune)
        {
            vida -= dano;
            StartCoroutine(Pisca());
        }
    }

    private IEnumerator Pisca()
    {
        imune = true;

        Color[] cores = { new Color(1, .5f, .5f, 1), new Color(1, 1, 1, 1), new Color(1, .5f, .5f, 1), new Color(1, 1, 1, 1) };
        int numCores = cores.Length;

        for (int i = 0; i < numCores; i++)
        {
            foreach (Renderer childRenderer in GetComponentsInChildren<Renderer>())
            {
                childRenderer.material.color = cores[i];
            }
            yield return new WaitForSeconds(.2f);
        }

        imune = false;
    }
}
