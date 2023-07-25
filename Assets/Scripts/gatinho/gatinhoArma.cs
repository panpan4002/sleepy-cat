using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class gatinhoArma : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private AudioClip[] sonsArmas;
    [SerializeField] private GameObject projetilPrefab;
    private gatinho gatinho;
    private gameManager gameManager;
    private AudioSource audioSource;

    [Header("Arma Base")]
    [SerializeField] private float danoArmaBase;
    [SerializeField] private float velocidadeProjetilArmaBase;
    [SerializeField] private Transform armaTransform;
    [SerializeField] private float cadenciaArma;
    private float ultimoTiroArma;

    [Header("Arma Torreta")]
    [SerializeField] private GameObject projetilTeleguiadoPrefab;
    [SerializeField] private float danoTorreta;
    [SerializeField] private float velocidadeProjetilTorreta;
    [SerializeField] private Transform torretaTransform;
    [SerializeField] private float cadenciaTorreta;
    [SerializeField] private GameObject torreta;

    private Transform alvoTorreta;
    private float ultimoTiroTorreta;

    [Header("Arma Mingun")]
    [SerializeField] private float danoMinigun;
    [SerializeField] private float velocidadeProjetilMinigun;
    [SerializeField] private Transform[] minigunTransform;
    [SerializeField] private float cadenciaMinigun;
    private float ultimoTiroMinigun;
    [SerializeField] private float temperaturaMaximaMinigun;
    public float temperaturaMinigun;
    [SerializeField] private GameObject minigunObjeto;

    private Color corFria = new Color (1, 1, 1, 1);
    private Color corQuente = new Color(1, 0f, 0f, 1);

    [Header("Arma Laser")]
    [SerializeField] private float danoLaser;
    [SerializeField] private float velocidadeProjetilLaser;
    [SerializeField] private Transform[] laserTransform;
    [SerializeField] private float cadenciaLaser;
    private float ultimoTiroLaser;

    void Start()
    {
        temperaturaMinigun = 0;

        ultimoTiroArma = -cadenciaArma;
        ultimoTiroMinigun = -cadenciaMinigun;
        ultimoTiroTorreta = -cadenciaTorreta;
        ultimoTiroLaser = -cadenciaLaser;

        gameManager = GameObject.Find("Kiwi").GetComponent<gameManager>();

        gatinho = GetComponent<gatinho>();
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = sonsArmas[0];
    }

    void Update()
    {
        Atirar(); 

        temperaturaMinigun = Mathf.Max(0f, temperaturaMinigun - 2 * Time.deltaTime);
        float porcentagemAquecimento = temperaturaMinigun / temperaturaMaximaMinigun;
        Color corAtual = Color.Lerp(corFria, corQuente, porcentagemAquecimento);
        minigunObjeto.GetComponent<SpriteRenderer>().color = corAtual;
    }

    void Atirar()
    {
        ArmaBase();
        if(gatinho.minigun) ArmaMinigun();
        if (gatinho.torreta) Torreta();
        if (gatinho.laser) ArmaLaser();
    }

    void ArmaBase()
    {
        if(Time.time > ultimoTiroArma + cadenciaArma)
        {
            GameObject projetilArmaBaseInstanciado = Instantiate(projetilPrefab, armaTransform.transform.position, armaTransform.transform.rotation);
            projetilArmaBaseInstanciado.GetComponent<projetilGatinho>().setarComponentes(this.gatinho, this.gameManager);
            projetilArmaBaseInstanciado.GetComponent<projetilGatinho>().setarProjetil(danoArmaBase, velocidadeProjetilArmaBase, 3);

            audioSource.PlayOneShot(sonsArmas[0]);
            gameManager.tirosArma++;
            ultimoTiroArma = Time.time;
        }
    }

    void ArmaMinigun()
    {
        if (Time.time > ultimoTiroMinigun + cadenciaMinigun && temperaturaMinigun < temperaturaMaximaMinigun)
        {
            foreach(Transform t in minigunTransform)
            {
                GameObject projetilMinigunInstanciado = Instantiate(projetilPrefab, t.transform.position, t.transform.rotation);
                projetilMinigunInstanciado.GetComponent<projetilGatinho>().setarComponentes(this.gatinho, this.gameManager);
                projetilMinigunInstanciado.GetComponent<projetilGatinho>().setarProjetil(danoMinigun, velocidadeProjetilMinigun, 0);
            }

            audioSource.PlayOneShot(sonsArmas[0]);
            gameManager.tirosMinigun++;
            temperaturaMinigun += 1;
            ultimoTiroMinigun = Time.time;
        }

        else

        {
            Debug.Log("minigun quente");
        }
    }

    void ArmaLaser()
    {
        if (Time.time > ultimoTiroLaser + cadenciaLaser)
        {
            foreach (Transform t in laserTransform)
            {
                GameObject projetilLaserInstanciado = Instantiate(projetilPrefab, t.transform.position, t.transform.rotation);
                projetilLaserInstanciado.GetComponent<projetilGatinho>().setarComponentes(this.gatinho, this.gameManager);
                projetilLaserInstanciado.GetComponent<projetilGatinho>().setarProjetil(danoLaser, velocidadeProjetilLaser, 2);
            }

            audioSource.PlayOneShot(sonsArmas[0]);
            gameManager.tirosLaser++;
            ultimoTiroLaser = Time.time;
        }
    }

    void Torreta()
    {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo").Concat(GameObject.FindGameObjectsWithTag("Asteroide")).ToArray();

        foreach (GameObject inimigo in inimigos)
        {

            //float closestDistance = Mathf.Infinity;
            float distancia = Vector3.Distance(transform.position, inimigo.transform.position);

            if (distancia < 10)
            {
                alvoTorreta = inimigo.transform;
            }
        }

        if (alvoTorreta != null)
        {
            Vector3 targetPosition = new Vector3(alvoTorreta.position.x, alvoTorreta.position.y, transform.position.z);
            Vector3 direction = targetPosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            torreta.transform.rotation = Quaternion.Slerp(torreta.transform.rotation, rotation, 10 * Time.deltaTime);
        }

        if (Time.time > ultimoTiroTorreta + cadenciaTorreta)
        {
            if(alvoTorreta != null)
            {
                GameObject projetilTorretaInstanciado = Instantiate(projetilTeleguiadoPrefab, torretaTransform.transform.position, torretaTransform.transform.rotation);
                projetilTorretaInstanciado.GetComponent<projetilTeleguiado>().SetarProjetil(danoTorreta, velocidadeProjetilTorreta, 10, 1, gatinho, alvoTorreta);
                ultimoTiroTorreta = Time.time;
            }
        }
    }
}
