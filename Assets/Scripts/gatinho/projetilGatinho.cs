using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetilGatinho : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private GameObject particulaColisaoPrefab;
    private Rigidbody2D projetilRB;
    private BoxCollider2D projetilCol;
    private gatinho gatinho; //= GameObject.Find("Gatinho");
    private gameManager gameManager;

    [Header("Projetil")]
    private float danoProjetil;
    private float velocidadeProjetil;
    [SerializeField] private float despawnSegundos;

    [SerializeField] private Sprite[] projetilSprite;

    void Start()
    {
        projetilRB = GetComponent<Rigidbody2D>();
        projetilCol = GetComponent<BoxCollider2D>();


        Invoke("Destruir", despawnSegundos);
    }

    void Update()
    {
        Vector3 direcao = new Vector3 (0, 1, 0);
        projetilRB.transform.position += direcao * velocidadeProjetil * Time.deltaTime;
    }

    public void setarComponentes(gatinho gatinhoSetado, gameManager gameManagerSetado)
    {
        gatinho = gatinhoSetado;
        gameManager = gameManagerSetado;
    }

    public void setarProjetil(float dano, float velocidade, int sprite)
    {
        danoProjetil = dano;
        velocidadeProjetil = velocidade;
        GetComponent<SpriteRenderer>().sprite = projetilSprite[sprite];
    }
    
    void Destruir()
    {
        Instantiate(particulaColisaoPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.CompareTag("Asteroide"))
        {
            colisao.gameObject.GetComponent<asteroide>().LevarDano(danoProjetil);
            Destruir();
        }

        if (colisao.CompareTag("Inimigo"))
        {
            colisao.gameObject.GetComponent<inimigo>().LevarDano(danoProjetil);
            Destruir();
        }
    }
}
