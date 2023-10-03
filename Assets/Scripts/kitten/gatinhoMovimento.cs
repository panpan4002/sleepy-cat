using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatinhoMovimento : MonoBehaviour
{
    [Header("Componentes")]
    private Rigidbody2D kittenRB;
    private float spaceshipWidth;
    private float spaceshipHeight;

    [Header("Movimento")]
    public float velocidadeNave;

    void Start()
    {
        spaceshipWidth = transform.GetComponent<Renderer>().bounds.size.x / 2;
        spaceshipHeight = transform.GetComponent<Renderer>().bounds.size.y / 2;

        kittenRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        TouchMove();

        if(Application.isEditor)
        {
            KeyboardMove();
        }

        ManterNaTela();
    }

    void KeyboardMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(horizontalInput, verticalInput, 0f);

        kittenRB.transform.position += direcao * velocidadeNave * 10 * Time.deltaTime;
    }

    void TouchMove()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {

            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(touchDeltaPosition.x * velocidadeNave * Time.deltaTime, touchDeltaPosition.y * velocidadeNave * Time.deltaTime, 0);
        }
    }

    void ManterNaTela()
    {
        Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        float minX = spaceshipWidth;
        float maxX = Screen.width - spaceshipWidth;
        float minY = spaceshipHeight;
        float maxY = Screen.height - spaceshipHeight;

        objectPosition.x = Mathf.Clamp(objectPosition.x, minX, maxX);
        objectPosition.y = Mathf.Clamp(objectPosition.y, minY, maxY);

        transform.position = Camera.main.ScreenToWorldPoint(objectPosition);
    }
}
