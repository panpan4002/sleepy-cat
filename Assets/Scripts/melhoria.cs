using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class melhoria : MonoBehaviour
{
    [Header("Componentes")]
    private SpriteRenderer melhoriaSR;
    private BoxCollider2D melhoriaCol;
    private Rigidbody2D melhoriaRB;
    private gameManager gameManager;
    private kitten kitten;

    [Header("Melhoria")]
    [SerializeField] private string melhoriaNome;
    [SerializeField] private float velocidadeMelhoria;
    

    void Start()
    {
        GameObject gameManagerObject = GameObject.Find("Kiwi");
        gameManager = gameManagerObject.GetComponent<gameManager>();

        GameObject gatinhoObject = GameObject.Find("Gatinho");
        kitten = gatinhoObject.GetComponent<kitten>();

        melhoriaSR = GetComponent<SpriteRenderer>();
        melhoriaCol = GetComponent<BoxCollider2D>();
        melhoriaRB = GetComponent<Rigidbody2D>();

        Vector3 direcao = new Vector3(0, -1, 0);
        melhoriaRB.velocity = direcao * velocidadeMelhoria * Time.deltaTime;
    }

    void Update()
    {
        if(transform.position.y <= 3)
        {
            StartCoroutine(FadeSprite());
        }

        if(transform.position.y <= 0)
        {
            DestruirMelhoria();
        }
    }

    /*public void SetarMelhoria(string nome, float velocidade ,float despawn)
    {
        melhoriaNome = nome;
        velocidadeMelhoria = velocidade;
        melhoriaDespawnSegundos = despawn;
    }*/

    IEnumerator FadeSprite()
    {
        float startTime = Time.time;
        Color spriteColor = melhoriaSR.color;
        while (spriteColor.a > 0f)
        {
            float t = (Time.time - startTime) / 3;
            spriteColor.a = Mathf.Lerp(1f, 0f, t);
            melhoriaSR.color = spriteColor;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (melhoriaNome)
            {
                case "MK2":
                    collision.GetComponent<kitten>().MK2 = true;

                    break;

                case "MK3":
                    collision.GetComponent<kitten>().MK3 = true;
                    break;

                case "torreta":
                    collision.GetComponent<kitten>().torreta = true;
                    break;

                case "minigun":
                    collision.GetComponent<kitten>().minigun = true;
                    break;

                case "laser":
                    if (collision.GetComponent<kitten>().MK3)
                    {
                        collision.GetComponent<kitten>().laser = true;
                    }

                    break;

                default:
                    Debug.Log("Essa melhoria não existe burrao");
                    break;

            }

            //StartCoroutine(PausaMelhoria());

            DestruirMelhoria();
        }
    }

    /*IEnumerator PausaMelhoria()
    {
        gameManager.StartCoroutine("PausaTempo");

        //Time.timeScale = 0;

        bool spacePressed = false;

        Debug.Log("ponce");

        while (!spacePressed)
        {
            Debug.Log("gozei");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                spacePressed = true;
                Debug.Log("sexo");
            }

            Debug.Log("com anao");
            yield return null;
        }

        Debug.Log("Marco");
        gameManager.StartCoroutine("RestauraTempo");
        StopCoroutine(PausaMelhoria());
    }*/

    void DestruirMelhoria()
    {
        Destroy(gameObject);
    }
}
