using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatinhoArma : MonoBehaviour
{
    [Header("Componentes")]
    gatinho gatinho;
    private gameManager gameManager;
    [SerializeField] private AudioClip[] sonsArmas;
    private AudioSource audioSource;

    [Header("Arma")]
    public Transform[] armasTransform;
    [SerializeField] private float cadenciaSegundos;
    private float ultimoTiro;

    [Header("Projetil")]
    public GameObject projetilGatinho;
    void Start()
    {
        gameManager = GameObject.Find("Kiwi").GetComponent<gameManager>();

        gatinho = GetComponent<gatinho>();
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = sonsArmas[0];
    }

    void Update()
    {
        
    }

    public int Atirar()
    {
        if(Time.time > ultimoTiro + cadenciaSegundos)
        {
            foreach (Transform t in armasTransform)
            {
                GameObject projetilGatinhoInstanciado = Instantiate(projetilGatinho, t.transform.position, t.transform.rotation);
                projetilGatinhoInstanciado.GetComponent<projetilGatinho>().setarComponentes(this.gatinho, this.gameManager);
            }

            audioSource.PlayOneShot(sonsArmas[0]);
            
            ultimoTiro = Time.time;
            return 1;
        }

        return 0;
    }
}
