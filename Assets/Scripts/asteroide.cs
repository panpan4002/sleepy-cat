using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroide : MonoBehaviour
{
    [Header("Componentes")]
    private Rigidbody2D asteroideRB;
    private BoxCollider2D asteroideCol;
    private gatinhoMovimento gatinhoMovimento;
    private gameManager gameManager;

    [Header("Asteroide")]
    private float velocidade;
    [SerializeField] private float velocidadeMin;
    [SerializeField] private float velocidadeMax;
    [SerializeField] private float danoAsteroide;
    [SerializeField] private float vidaMaximaAsteroide;
    [SerializeField] private float vidaAtualAsteroide;
    [SerializeField] private float despawnSegundos;
    [SerializeField] private Sprite[] asteroideSprite;
    [SerializeField] private GameObject particulaPoeiraPrefab;

    void Start()
    {
        gatinhoMovimento = GameObject.Find("Gatinho").GetComponent<gatinhoMovimento>();
        asteroideCol = GetComponent<BoxCollider2D>();
        asteroideRB = GetComponent<Rigidbody2D>();

        vidaAtualAsteroide = vidaMaximaAsteroide;
        velocidade = Random.Range(velocidadeMin, velocidadeMax);
        GetComponent<SpriteRenderer>().sprite = asteroideSprite[Random.Range(0,asteroideSprite.Length)];

        Invoke("DestruirAsteroide", despawnSegundos);
    }

    private void Update()
    {
        if(vidaAtualAsteroide <= 0)
        {
            gameManager.AumentarPontuacao(Mathf.RoundToInt(10f * danoAsteroide));
            DestruirAsteroide();
        }

        MovimentoAsteroide();
    }

    private void MovimentoAsteroide()
    {
        if(gatinhoMovimento.transform.position.y > 1)
        {
            transform.position += new Vector3(0, -velocidade, 0) * gatinhoMovimento.transform.position.y / 2 * Time.deltaTime;
        }

        else transform.position += new Vector3(0, -velocidade, 0) * 0.5f * Time.deltaTime;
    }

    public void LevarDano(float dano)
    {
        vidaAtualAsteroide -= dano;
    }

    public void setarGameManager(gameManager gameManagerSetado)
    {
        gameManager = gameManagerSetado;
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.CompareTag("Player"))
        {
            colisao.gameObject.GetComponent<gatinhoVida>().LevarDano(danoAsteroide);
            DestruirAsteroide();
        }
    }

    private void DestruirAsteroide()
    {
        Instantiate(particulaPoeiraPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
