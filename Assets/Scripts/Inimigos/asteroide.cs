using UnityEngine;

public class asteroide : MonoBehaviour
{
    [Header("Componentes")]
    private Rigidbody2D asteroideRB;
    private BoxCollider2D asteroideCol;

    [Header("Asteroide")]
    private float asteroidSpeed;
    [SerializeField] private Vector2 speed;
    [SerializeField] private float danoAsteroide;
    [SerializeField] private float vidaMaximaAsteroide;
    [SerializeField] private float vidaAtualAsteroide;
    [SerializeField] private float despawn;
    [SerializeField] private Sprite[] asteroideSprite;
    [SerializeField] private GameObject particulaPoeiraPrefab;

    void Start()
    {
        asteroideCol = GetComponent<BoxCollider2D>();
        asteroideRB = GetComponent<Rigidbody2D>();

        vidaAtualAsteroide = vidaMaximaAsteroide;
        asteroidSpeed = Random.Range(speed.x, speed.y);
        GetComponent<SpriteRenderer>().sprite = asteroideSprite[Random.Range(0,asteroideSprite.Length)];

        Invoke("DestruirAsteroide", despawn);
    }

    private void Update()
    {
        if(vidaAtualAsteroide <= 0)
        {
            DestruirAsteroide();
        }
    }

    private void FixedUpdate()
    {
        MovimentoAsteroide();
    }

    private void MovimentoAsteroide()
    {
        asteroideRB.velocity = new Vector2(0, -asteroidSpeed);
    }

    public void TakeDamage(float damage)
    {
        vidaAtualAsteroide -= damage;
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
