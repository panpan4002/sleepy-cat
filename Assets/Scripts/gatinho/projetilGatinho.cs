using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetilGatinho : MonoBehaviour
{
    [Header("Componentes")]
    private Rigidbody2D projetilRB;
    private BoxCollider2D projetilCol;
    [SerializeField] private gatinho gatinho; //= GameObject.Find("Gatinho");
    private gameManager gameManager;

    [Header("Projetil")]
    public float velocidadeProjetil;
    public float despawnSegundos;

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
    
    void Destruir()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.CompareTag("Asteroide"))
        {
            colisao.gameObject.GetComponent<asteroide>().DestruirAsteroide();
            gameManager.SetarPontuacao(5);
            Destroy(gameObject);
        }
    }
}
