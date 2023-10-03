using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class inimigoMovimento : MonoBehaviour
{
    [Header("Componentes")]
    private BoxCollider2D inimigoCol;
    private Rigidbody2D inimigoRB;
    private kitten kitten;

    [Header("Movimento")]
    [SerializeField] public float velocidade;
    [SerializeField] private float amplitudeZZ;
    [SerializeField] private float frequenciaZZ;
    private Transform gatinhoTransform;
    private Vector3 alvo;
    [HideInInspector] public bool atacando;

    private float startTime;

    void Start()
    {
        GameObject gatinhoObject = GameObject.Find("Gatinho");
        kitten = gatinhoObject.GetComponent<kitten>();
        gatinhoTransform = kitten.transform;

        inimigoCol = GetComponent<BoxCollider2D>();
        inimigoRB = GetComponent<Rigidbody2D>();

        startTime = Time.time;

        float randomNumber = Random.Range(0, 2) * 2 - 1;
        amplitudeZZ *= randomNumber;
    }

    void Update()
    {
        alvo = new Vector3(gatinhoTransform.position.x, gatinhoTransform.position.y + 2.5f, gatinhoTransform.position.z);
    }

    private void FixedUpdate()
    {

        MovimentoZigZag();

    }

    private void MovimentoZigZag()
    {
        Vector3 direction = (alvo - transform.position).normalized;
        Vector3 zigzagDirection = new Vector3(Mathf.Sin((Time.time - startTime) * frequenciaZZ) * amplitudeZZ, direction.y, direction.z);

       inimigoRB.velocity = zigzagDirection.normalized * velocidade;
    }
}
