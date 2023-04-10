using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoAnimacao : MonoBehaviour
{
    [Header("Componentes")]
    private Animator inimigoAnimator;

    int inimigo;

    void Start()
    {
        inimigoAnimator = GetComponent<Animator>();

        inimigo = Random.Range(1, 4);

        inimigoAnimator.SetInteger("animacao", inimigo);
    }

    void Update()
    {

    }
}
