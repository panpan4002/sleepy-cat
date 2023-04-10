using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fundoInfinitoMenu : MonoBehaviour
{
    [Header("Componentes")]
    private RawImage fundo;

    [SerializeField] private float velocidadeX, velocidadeY;


    void Start()
    {
        fundo = GetComponent<RawImage>();
    }

    void Update()
    {
        fundo.uvRect = new Rect(fundo.uvRect.position + new Vector2(velocidadeX, velocidadeY) * Time.deltaTime, fundo.uvRect.size);
    }
}
