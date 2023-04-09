using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    [Header("Game Manager")]
    [SerializeField] private TextMeshProUGUI tempoTexto;
    [SerializeField] private TextMeshProUGUI pontuacaoTexto;
    [SerializeField] private Slider vidaSlider;
    [SerializeField] private gatinhoVida gatinhoVida;
    [SerializeField] public int tirosArma;
    [SerializeField] public int tirosMinigun;
    [SerializeField] public int tirosTorreta;
    [SerializeField] public int tirosLaser;

    public gatinho gatinho;
    public int pontuacao = 0;

    private bool estaPausando;
    private bool estaDespausando;

    void Start()
    {
        //StartCoroutine(Tempo());

        estaDespausando = false;
        estaPausando = false;

        GameObject gatinhoGameObject = GameObject.FindWithTag("Player");
        gatinho = gatinhoGameObject.GetComponent<gatinho>();

        tirosArma = 0;
        tirosMinigun = 0;
        tirosTorreta = 0;
        tirosLaser = 0;
    }

    void Update()
    {

        Temporizador();

        pontuacaoTexto.text = pontuacao.ToString();

        VidaSlider();

    }

    private void FixedUpdate()
    {
   
    }

    public void AumentarPontuacao(int pontuacaoAumentar)
    {
        pontuacao += pontuacaoAumentar;
    }

    private void Temporizador()
    {
        float timeInSeconds = Time.time;
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);
        tempoTexto.text = timeSpan.ToString("m':'ss");
    }

    void VidaSlider()
    {
        if(gatinhoVida.vida >= gatinhoVida.vidaMaxima / 4 * 3) vidaSlider.fillRect.GetComponent<Image>().color = new Color(0, 1, 0, 1);

        else if(gatinhoVida.vida >= gatinhoVida.vidaMaxima / 4 * 2) vidaSlider.fillRect.GetComponent<Image>().color = new Color(1, 1, 0, 1);

        else if (gatinhoVida.vida >= gatinhoVida.vidaMaxima / 4) vidaSlider.fillRect.GetComponent<Image>().color =  new Color(1, .2f, 0, 1);

        else vidaSlider.fillRect.GetComponent<Image>().color = new Color(1, 0, 0, 1);

        vidaSlider.maxValue = gatinhoVida.vidaMaxima;
        vidaSlider.value = gatinhoVida.vida;
    }

    /*IEnumerator PausaTempo()
    {
        StopCoroutine(RestauraTempo());
        Time.timeScale = 1f;

        if (!estaPausando)
        {

            estaPausando = true;
        }

        yield return null;
    }

    IEnumerator RestauraTempo()
    {
        StopCoroutine(PausaTempo());
        Time.timeScale = 0f;
        Debug.Log("Polo");

        if (!estaDespausando)
        {

            estaDespausando = true;
        }

        yield return null;
    }

    IEnumerator Tempo()
    {
        while (true)
        {
            if (estaPausando)
            {
                Time.timeScale -= Time.deltaTime * 3f;

                if (Time.timeScale <= 0f)
                {
                    Time.timeScale = 0f;
                    estaPausando = false;
                }
            }

            if (estaDespausando)
            {
                Time.timeScale += Time.deltaTime * 3f;

                if (Time.timeScale >= 1f)
                {
                    Time.timeScale = 1f;
                    estaPausando = false;
                }
            }

            yield return null;
        }
    }*/
}
