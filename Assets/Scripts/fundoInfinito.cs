using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fundoInfinito : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] gatinhoMovimento gatinhoMovimento;
    private RawImage fundo;
    public float velocidadeX, velocidadeY;

    
    void Start()
    {
        fundo = GetComponent<RawImage>();
    }

    void Update()
    {
        if(gatinhoMovimento.transform.position.y >= 5)
        {
            velocidadeY = (0.5f * 5) / 4;
        }

        else if(gatinhoMovimento.transform.position.y <= 3)
        {
            velocidadeY = (0.5f * 3) / 4;
        }

        else
        {
            velocidadeY = (0.5f * Mathf.Abs(gatinhoMovimento.transform.position.y)) / 4 ;
        }

        fundo.uvRect = new Rect(fundo.uvRect.position + new Vector2(velocidadeX, velocidadeY) * Time.deltaTime, fundo.uvRect.size);
    }
}
