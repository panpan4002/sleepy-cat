using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class gameManager : MonoBehaviour
{
    [Header("Game Manager")]
    private TextMeshProUGUI tempoTexto;
    private TextMeshProUGUI pontuacaoTexto;
    private Slider vidaSlider;

    [HideInInspector] public int tirosArma;
    [HideInInspector] public int tirosMinigun;
    [HideInInspector] public int tirosTorreta;
    [HideInInspector] public int tirosLaser;

    [Header("Gatinho")]
    [HideInInspector] public gatinho gatinho;
    [HideInInspector] public gatinhoArma gatinhoArma;
    [HideInInspector] public gatinhoMovimento gatinhoMovimento;
    [HideInInspector] public gatinhoVida gatinhoVida;

    [HideInInspector] public int pontuacao = 0;

    private UI UI;

    void Awake()
    {
        /*DontDestroyOnLoad(this.gameObject);

        if (FindObjectOfType<gameManager>() != this)
        {
            Destroy(gameObject);
            return;
        }*/
    }

    void Start()
    {
        GameObject gatinhoGameObject = GameObject.FindWithTag("Player");
        gatinho = gatinhoGameObject.GetComponent<gatinho>();

        GameObject gatinhoHUDObject = GameObject.Find("HUD");
        vidaSlider = gatinhoHUDObject.GetComponentInChildren<Slider>();
        pontuacaoTexto = GameObject.Find("Pontuacao").GetComponent<TextMeshProUGUI>();
        tempoTexto = GameObject.Find("Tempo").GetComponent<TextMeshProUGUI>();

        gatinhoArma = gatinhoGameObject.GetComponent<gatinhoArma>();
        gatinhoMovimento = gatinhoGameObject.GetComponent<gatinhoMovimento>();
        gatinhoVida = gatinhoGameObject.gameObject.GetComponent<gatinhoVida>();

        UI = GameObject.Find("UI").GetComponent<UI>();

        pontuacao = 0;
    }

    void Update()
    {
        Temporizador();
        pontuacaoTexto.text = pontuacao.ToString();
        if (gatinhoVida.vida > 0) VidaSlider();
    }

    public void AumentarPontuacao(int pontuacaoAumentar)
    {
        pontuacao += pontuacaoAumentar;
    }

    private void Temporizador()
    {
        float timeInSeconds = Time.time;
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);
        string v = timeSpan.ToString("m':'ss");
        tempoTexto.text = v;
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

    public void BotaoIniciar()
    {
        SceneManager.LoadScene(1);
    }

    public void BotaoSair()
    {
        Application.Quit();
    }
}
