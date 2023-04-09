using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Header("Arma Laser")]
    [SerializeField] private float danoLaser;
    [SerializeField] private float velocidadeProjetilLaser;
    [SerializeField] private Transform[] laserTransform;
    [SerializeField] private float cadenciaLaser;
    private float ultimoTiroLaser;

    void Start()
    {
        gameManager = GameObject.Find("Kiwi").GetComponent<gameManager>();

        gatinho = GetComponent<gatinho>();
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = sonsArmas[0];
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Atirar();
        }

        if (Input.GetKey(KeyCode.L))
        {
            if (gatinho.laser) ArmaLaser();
        }

        if (gatinho.torreta) Torreta();
    }

    void Atirar()
    {
        ArmaBase();
        if(gatinho.minigun) ArmaMinigun();
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
        if(Time.time > ultimoTiroMinigun + cadenciaMinigun)
        {
            foreach(Transform t in minigunTransform)
            {
                GameObject projetilMinigunInstanciado = Instantiate(projetilPrefab, t.transform.position, t.transform.rotation);
                projetilMinigunInstanciado.GetComponent<projetilGatinho>().setarComponentes(this.gatinho, this.gameManager);
                projetilMinigunInstanciado.GetComponent<projetilGatinho>().setarProjetil(danoMinigun, velocidadeProjetilMinigun, 0);
            }

            audioSource.PlayOneShot(sonsArmas[0]);
            gameManager.tirosMinigun++;
            ultimoTiroMinigun = Time.time;
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
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");

        foreach (GameObject inimigo in inimigos)
        {
            float distancia = Vector3.Distance(transform.position, inimigo.transform.position);
            if (distancia < 10)
            {
                alvoTorreta = inimigo.transform;
            }
        }

        if (alvoTorreta != null)
        {

            Vector3 direcao = alvoTorreta.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direcao);
            torreta.transform.rotation = Quaternion.Euler(0f, 0f, lookRotation.eulerAngles.y);
        }
    }
}
