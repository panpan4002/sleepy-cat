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

    [Header("Menu")]
    VideoPlayer Cutscene;

    [Header("Gatinho")]
    [HideInInspector] public gatinho gatinho;
    [HideInInspector] public gatinhoArma gatinhoArma;
    [HideInInspector] public gatinhoMovimento gatinhoMovimento;
    [HideInInspector] public gatinhoVida gatinhoVida;

    [HideInInspector] public int pontuacao = 0;

    public bool cena0 = false;
    public bool cena1 = false;

    private UI UI;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (FindObjectOfType<gameManager>() != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (!cena0) Cena0Start();

        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (!cena1) Cena1Start();  

            Temporizador();
            pontuacaoTexto.text = pontuacao.ToString();
            if(gatinhoVida.vida > 0) VidaSlider();
        }


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

    void Cena0Start()
    {
        Cutscene = GameObject.Find("Cutscene").GetComponent<VideoPlayer>();

        float targetAspect = 4.0f / 3.0f;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            Camera.main.rect = new Rect(0.0f, (1.0f - scaleHeight) / 2.0f, 1.0f, scaleHeight);
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Camera.main.rect = new Rect((1.0f - scaleWidth) / 2.0f, 0.0f, scaleWidth, 1.0f);
        }
    }

    void Cena1Start()
    {
        cena1 = true;

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

        tirosArma = 0;
        tirosMinigun = 0;
        tirosTorreta = 0;
        tirosLaser = 0;

        pontuacao = 0;

        float targetAspect = 4.0f / 3.0f;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            Camera.main.rect = new Rect(0.0f, (1.0f - scaleHeight) / 2.0f, 1.0f, scaleHeight);
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Camera.main.rect = new Rect((1.0f - scaleWidth) / 2.0f, 0.0f, scaleWidth, 1.0f);
        }
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
