using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    [Header("Componentes")]
    private inimigoMovimento inimigoMovimento;
    private BoxCollider2D inimigoCol;
    private Rigidbody2D inimigoRB;
    private gatinho gatinho;
    private gameManager gameManager;

    [Header("Inimigo")]
    [SerializeField] private float vidaMaxima;
    [SerializeField] private float vidaAtual;
    [SerializeField] private float dano;
    [SerializeField] private float ataqueCD;
    private float ultimoAtaque;
    private bool podeAtacar;

    private bool piscando;

    void Start()
    {
        GameObject gameManagerObject = GameObject.Find("Kiwi");
        gameManager = gameManagerObject.GetComponent<gameManager>();

        GameObject gatinhoObject = GameObject.Find("Gatinho");
        gatinho = gatinhoObject.GetComponent<gatinho>();

        inimigoMovimento = GetComponent<inimigoMovimento>();
        inimigoCol = GetComponent<BoxCollider2D>();
        inimigoRB = GetComponent<Rigidbody2D>();

        vidaAtual = vidaMaxima;
    }

    void Update()
    {
        if(vidaAtual <= 0)
        {
            gameManager.AumentarPontuacao(Mathf.RoundToInt(10 * dano));
            DestruirInimigo();
        }

        //Atacar();
    }

    private void Atacar()
    {
        if(Time.time > ultimoAtaque + ataqueCD)
        {
            podeAtacar = true;
        }

        if (Vector3.Distance(transform.position, inimigoMovimento.alvo) <= 3 && podeAtacar)
        {
            inimigoMovimento.atacando = true;
            ultimoAtaque = Time.time;
            podeAtacar = false;
            MovimentoAtaque();
            Debug.Log("entrou no range");

        }

        else

        {
            inimigoMovimento.atacando = false;
        }
    }

    private void MovimentoAtaque()
    {
        Vector3 direction = (inimigoMovimento.gatinhoTransform.position - transform.position).normalized;
        inimigoRB.velocity = direction * inimigoMovimento.velocidade * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<gatinhoVida>().LevarDano(dano);
        }
    }

    public void SetarComponentes(gatinho gatinhoSetado, gameManager gameManagerSetado)
    {
        gameManager = gameManagerSetado;
        gatinho = gatinhoSetado;
    }

    public void LevarDano(float danoLevar)
    {
        vidaAtual -= danoLevar;
        if(!piscando) StartCoroutine(Pisca());
    }

    private IEnumerator Pisca()
    {
        piscando = true;

        Color[] cores = { new Color(1, .5f, .5f, 1), new Color(1, 1, 1, 1), new Color(1, .5f, .5f, 1), new Color(1, 1, 1, 1) };
        int numCores = cores.Length;

        for (int i = 0; i < numCores; i++)
        {
            foreach (Renderer childRenderer in GetComponentsInChildren<Renderer>())
            {
                childRenderer.material.color = cores[i];
            }
            yield return new WaitForSeconds(.2f);
        }

        piscando = false;
    }

    private void DestruirInimigo()
    {
        Destroy(gameObject);
    }
}
