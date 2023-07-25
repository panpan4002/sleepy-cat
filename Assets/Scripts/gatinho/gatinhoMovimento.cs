using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatinhoMovimento : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidadeNave;
    public bool hyperSpeed;
    public bool slowSpeed;

    [Header("Componentes")]
    private Rigidbody2D gatinhoRB;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        objectWidth = transform.GetComponent<Renderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<Renderer>().bounds.size.y / 2;

        gatinhoRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            transform.position = touchPosition;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(horizontalInput, verticalInput, 0f);

        gatinhoRB.transform.position += direcao * velocidadeNave * Time.deltaTime;

        ManterNaTela();

        if(transform.position.y >= 5) 
        {
            hyperSpeed = true;
        }

        else

        {
            hyperSpeed = false;
        }

        if (transform.position.y <= 2)
        {
            slowSpeed = true;
        }

        else

        {
            slowSpeed = false;
        }
    }

    void ManterNaTela()
    {
        Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        float minX = objectWidth;
        float maxX = Screen.width - objectWidth;
        float minY = objectHeight;
        float maxY = Screen.height / 3 - objectHeight;

        objectPosition.x = Mathf.Clamp(objectPosition.x, minX, maxX);
        objectPosition.y = Mathf.Clamp(objectPosition.y, minY, maxY);

        transform.position = Camera.main.ScreenToWorldPoint(objectPosition);
    }
}
