using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitten : MonoBehaviour
{
    [Header("Componentes")]
    gatinhoMovimento gatinhoMovimento;
    gatinhoArma gatinhoArma;

    [Header("Melhorias")]
    public bool MK2;
    public bool MK3;
    public bool minigun;
    public bool torreta;
    public bool laser;

    [SerializeField] private GameObject MK2Objeto;
    [SerializeField] private GameObject MK3Objeto;
    [SerializeField] private GameObject minigunObjeto;
    [SerializeField] private GameObject torretaObjeto;
    [SerializeField] private GameObject laserObjeto;

    private bool MK2JaMelhorou;
    private bool MK3JaMelhorou;
    private bool minigunJaMelhorou;
    private bool torretaJaMelhorou;
    private bool laserJaMelhorou;

    [SerializeField] private GameObject particulaMelhoria;

    void Start()
    {
        gatinhoMovimento = GetComponent<gatinhoMovimento>();
        gatinhoArma = GetComponent<gatinhoArma>();

        minigun = false;
        torreta = false;
        laser = false;
        MK2 = false;
        MK3 = false;

        MK2JaMelhorou = false;
        MK3JaMelhorou = false;
        laserJaMelhorou = false;
        minigunJaMelhorou = false;
        torretaJaMelhorou = false;    
    }

    void Update()
    {
        Melhorias();
    }

    private void Melhorias()
    {
        if (MK2 && !MK2JaMelhorou)
        {
            MK2JaMelhorou = true;
            MK2Objeto.SetActive(true);
            GetComponent<gatinhoVida>().vidaMaxima = 10;
            GetComponent<gatinhoVida>().vida = 10;
            Instantiate(particulaMelhoria, transform.position, Quaternion.identity);
        }

        if (MK3 && !MK3JaMelhorou)
        {
            MK3JaMelhorou = true;
            MK3Objeto.SetActive(true);
            GetComponent<gatinhoVida>().vidaMaxima = 20;
            GetComponent<gatinhoVida>().vida = 20;
            Instantiate(particulaMelhoria, transform.position, Quaternion.identity);
        }

        if (minigun && !minigunJaMelhorou)
        {
            minigunJaMelhorou = true;
            minigunObjeto.SetActive(true);
            Instantiate(particulaMelhoria, transform.position, Quaternion.identity);
        }

        if (torreta && !torretaJaMelhorou)
        {
            torretaJaMelhorou = true;
            torretaObjeto.SetActive(true);
            Instantiate(particulaMelhoria, transform.position, Quaternion.identity);
        }

        if (laser && !laserJaMelhorou)
        {
            laserJaMelhorou = true;
            laserObjeto.SetActive(true);
            Instantiate(particulaMelhoria, transform.position, Quaternion.identity);
        }
    }
}
