using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetilTeleguiado : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private GameObject particulaColisaoPrefab;
    private Rigidbody2D projetilRB;
    private BoxCollider2D projetilCol;
    private gatinho gatinho;
    private gameManager gameManager;

    [Header("Projetil")]
    private float danoProjetil;
    private float velocidadeProjetil;
    private float despawnSegundos;
    private int gatinhoOuNao;
    private Transform alvo;

    void Start()
    {
        projetilRB = GetComponent<Rigidbody2D>();
        projetilCol = GetComponent<BoxCollider2D>();

        Invoke("Destruir", despawnSegundos);
    }

    public void SetarProjetil(float dano, float velocidade, float despawn, int gatinhoOuRobotbosta, gatinho gatinhoSetado, Transform alvoSetado)
    {
        danoProjetil = dano;
        velocidadeProjetil = velocidade;
        despawnSegundos = despawn;
        gatinho = gatinhoSetado;
        gatinhoOuNao = gatinhoOuRobotbosta;
        alvo = alvoSetado;
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        MissilMovimento();
    }

    void MissilMovimento()
    {
        if (alvo != null) 
        {
            Vector2 direcao = (Vector2)alvo.position - projetilRB.position;
            direcao.Normalize();
            Vector2 forca = direcao * velocidadeProjetil;
            Quaternion rotacaoDesejada = Quaternion.LookRotation(Vector3.forward, direcao);
            projetilRB.transform.rotation = Quaternion.Lerp(projetilRB.transform.rotation, rotacaoDesejada, Time.deltaTime * 10f);
            projetilRB.AddForce(forca);
        }
    }

    void Destruir()
    {
        Instantiate(particulaColisaoPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(gatinhoOuNao == 1)
        {
            if (colisao.CompareTag("Asteroide"))
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

        else if(gatinhoOuNao == 2)
        {
            if (colisao.CompareTag("Player"))
            {
                colisao.gameObject.GetComponent<gatinhoVida>().LevarDano(danoProjetil);
                Destruir();
            }
        }

        else
        {
            Debug.Log("Não especificado se é gatinho ou robotpenis porra");
            Invoke("Destruir", 5);
        }
    }
}
