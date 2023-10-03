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

    private float _elapsedTime = 0;
    public float elapsedTime { get { return _elapsedTime; } }


    void Awake()
    {
        
    }

    void Start()
    {
        GameObject gatinhoGameObject = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

    void pauseGame(bool pause)
    {
        if(!pause) { Time.timeScale = 1.0f; }
        if(pause) { Time.timeScale = 0f;}
    }
}
