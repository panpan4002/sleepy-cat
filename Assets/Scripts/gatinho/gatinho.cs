using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatinho : MonoBehaviour
{
    [Header("Componentes")]
    gatinhoMovimento gatinhoMovimento;
    gatinhoArma gatinhoArma;



    void Start()
    {
        gatinhoMovimento = GetComponent<gatinhoMovimento>();
        gatinhoArma = GetComponent<gatinhoArma>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gatinhoArma.Atirar();
        }
    }
}
