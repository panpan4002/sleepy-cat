using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroide : MonoBehaviour
{
    [Header("Componentes")]
    private Rigidbody2D asteroideRB;
    private BoxCollider2D asteroideCol;
    private gatinhoMovimento gatinhoMovimento;

    [Header("Asteroide")]
    private float velocidade;
    [SerializeField] private float velocidadeMin;
    [SerializeField] private float velocidadeMax;
    [SerializeField] private float danoAsteroide;
    [SerializeField] private float despawnSegundos;

    void Start()
    {
        gatinhoMovimento = GameObject.Find("Gatinho").GetComponent<gatinhoMovimento>();
        asteroideCol = GetComponent<BoxCollider2D>();
        asteroideRB = GetComponent<Rigidbody2D>();

        velocidade = Random.Range(velocidadeMin, velocidadeMax);

        Invoke("DestruirAsteroide", despawnSegundos);
    }

    void Update()
    {
        MovimentoAsteroide();
    }

    void MovimentoAsteroide()
    {
        transform.position += new Vector3(0, -velocidade, 0) * gatinhoMovimento.transform.position.y / 2 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.CompareTag("Player"))
        {
            colisao.gameObject.GetComponent<gatinhoVida>().LevarDano(danoAsteroide);
            Destroy(gameObject);
        }
    }

    public void DestruirAsteroide()
    {
        Destroy(gameObject);
    }
}
