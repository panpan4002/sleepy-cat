using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class inimigoMovimento : MonoBehaviour
{
    [Header("Componentes")]
    private BoxCollider2D inimigoCol;
    private Rigidbody2D inimigoRB;
    private gatinho gatinho;

    [Header("Movimento")]
    [SerializeField] public float velocidade;
    [SerializeField] private float amplitudeZZ;
    [SerializeField] private float frequenciaZZ;
    [HideInInspector] public Transform gatinhoTransform;
    [HideInInspector] public Vector3 alvo;
    [HideInInspector] public bool atacando;

    private Vector3 startPosition;
    private float startTime;

    void Start()
    {
        inimigoCol = GetComponent<BoxCollider2D>();
        inimigoRB = GetComponent<Rigidbody2D>();

        startPosition = transform.position;
        startTime = Time.time;
    }

    void Update()
    {
        alvo = new Vector3(gatinhoTransform.position.x, gatinhoTransform.position.y + 4, gatinhoTransform.position.z);
    }

    private void FixedUpdate()
    {
        //if(!atacando)
        //{
            MovimentoZigZag();
        //}
    }

    private void MovimentoZigZag()
    {
        Vector3 direction = (alvo - transform.position).normalized;
        Vector3 zigzagDirection = new Vector3(Mathf.Sin((Time.time - startTime) * frequenciaZZ) * amplitudeZZ, direction.y, direction.z);

       inimigoRB.velocity = zigzagDirection.normalized * velocidade;
    }
}
