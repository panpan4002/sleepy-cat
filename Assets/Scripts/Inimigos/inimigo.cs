using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    [Header("Componentes")]
    private inimigoMovimento inimigoMovimento;
    private BoxCollider2D inimigoCol;
    private Rigidbody2D inimigoRB;
    private kitten kitten;
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
        kitten = gatinhoObject.GetComponent<kitten>();

        inimigoMovimento = GetComponent<inimigoMovimento>();
        inimigoCol = GetComponent<BoxCollider2D>();
        inimigoRB = GetComponent<Rigidbody2D>();

        vidaAtual = vidaMaxima;
    }

    void Update()
    {
        if(vidaAtual <= 0)
        {
            DestruirInimigo();
        }

        //Atacar();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<gatinhoVida>().LevarDano(dano);
        }
    }

    public void SetarComponentes(kitten gatinhoSetado, gameManager gameManagerSetado)
    {
        gameManager = gameManagerSetado;
        kitten = gatinhoSetado;
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
