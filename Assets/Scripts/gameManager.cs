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

    private float tempoDecorrido = 0;
    private int pontuacao = 0;

    void Start()
    {
        
    }

    void Update()
    {
        tempoDecorrido = Mathf.Round(Time.time * 100) / 100;
        tempoTexto.text = tempoDecorrido.ToString();

        pontuacaoTexto.text = pontuacao.ToString();

        VidaSlider();
    }

    public void SetarPontuacao(int pontuacaoSetar)
    {
        pontuacao += pontuacaoSetar;
    }

    void VidaSlider()
    {
        if(gatinhoVida.vida >= gatinhoVida.vidaMaxima / 4 * 3) vidaSlider.fillRect.GetComponent<Image>().color = Color.green;

        else if(gatinhoVida.vida >= gatinhoVida.vidaMaxima / 4 * 2) vidaSlider.fillRect.GetComponent<Image>().color = Color.cyan;

        else if (gatinhoVida.vida >= gatinhoVida.vidaMaxima / 4) vidaSlider.fillRect.GetComponent<Image>().color = Color.yellow;

        else vidaSlider.fillRect.GetComponent<Image>().color = Color.red;

        vidaSlider.maxValue = gatinhoVida.vidaMaxima;
        vidaSlider.value = gatinhoVida.vida;
    }
}
