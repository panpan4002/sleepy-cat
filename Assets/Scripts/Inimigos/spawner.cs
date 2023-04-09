using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [Header("Componentes")]
    private BoxCollider2D spawnArea;
    private gatinhoMovimento gatinhoMovimento;
    [SerializeField] private gameManager gameManager;

    [Header("Asteroide")]
    [SerializeField] private GameObject asteroidePrefab;
    [SerializeField] private float asteroideSpawnRate;

    [Header("Melhorias")]
    [SerializeField] private GameObject melhoriaMK2Prefab;
    [SerializeField] private GameObject melhoriaMK3Prefab;
    [SerializeField] private GameObject melhoriaTorretaPrefab;
    [SerializeField] private GameObject melhoriaMinigunPrefab;
    [SerializeField] private GameObject melhoriaLaserPrefab;

    private GameObject ultimaMelhoriaMK2;
    private GameObject ultimaMelhoriaMK3;
    private GameObject ultimaMelhoriaTorreta;
    private GameObject ultimaMelhoriaMinigun;
    private GameObject ultimaMelhoriaLaser;

    void Start()
    {
        spawnArea = GetComponent<BoxCollider2D>();
        StartCoroutine("SpawnAsteroide");
        StartCoroutine("SpawnMelhoriaMK2");
        StartCoroutine("SpawnMelhoriaMK3");
        StartCoroutine("SpawnMelhoriaTorreta");
        StartCoroutine("SpawnMelhoriaLaser");
        StartCoroutine("SpawnMelhoriaMinigun");
    }

    void Update()
    {
        
    }

    IEnumerator SpawnMelhoriaMK2()
    {
        while (true)
        {
            if (gameManager.pontuacao > 200 && !gameManager.gatinho.MK2 && ultimaMelhoriaMK2 == null)
            {
                Debug.Log("MK2");

                float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
                float y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
                Vector2 spawnPosition = new Vector2(x, y);

                GameObject melhoriaMK2Instanciada = Instantiate(melhoriaMK2Prefab, spawnPosition, Quaternion.identity);
                //melhoriaMK2Instanciada.GetComponent<melhoria>().SetarMelhoria("MK2", 80, 30);
                ultimaMelhoriaMK2 = melhoriaMK2Instanciada;
            }
            yield return null;
        }
    }

    IEnumerator SpawnMelhoriaMK3()
    {
        while (true)
        {
            if (gameManager.pontuacao > 600 && !gameManager.gatinho.MK3 && ultimaMelhoriaMK3 == null)
            {
                Debug.Log("MK3");

                float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
                float y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
                Vector2 spawnPosition = new Vector2(x, y);

                GameObject melhoriaMK3Instanciada = Instantiate(melhoriaMK3Prefab, spawnPosition, Quaternion.identity);
                //melhoriaMK3Instanciada.GetComponent<melhoria>().SetarMelhoria("MK2", 80, 30);
                ultimaMelhoriaMK3 = melhoriaMK3Instanciada;
            }
            yield return null;
        }
    }

    IEnumerator SpawnMelhoriaTorreta()
    {
        while (true)
        {
            if (gameManager.pontuacao > 300 && !gameManager.gatinho.torreta && ultimaMelhoriaTorreta == null)
            {
                Debug.Log("Torreta");

                float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
                float y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
                Vector2 spawnPosition = new Vector2(x, y);

                GameObject melhoriaTorretaInstanciada = Instantiate(melhoriaTorretaPrefab, spawnPosition, Quaternion.identity);
                //melhoriaTorretaInstanciada.GetComponent<melhoria>().SetarMelhoria("MK2", 80, 30);
                ultimaMelhoriaTorreta = melhoriaTorretaInstanciada;
            }
            yield return null;
        }
    }

    IEnumerator SpawnMelhoriaMinigun()
    {
        while (true)
        {
            if (gameManager.pontuacao > 500 && !gameManager.gatinho.minigun && ultimaMelhoriaMinigun == null)
            {
                Debug.Log("Minigun");

                float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
                float y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
                Vector2 spawnPosition = new Vector2(x, y);

                GameObject melhoriaMinigunInstanciada = Instantiate(melhoriaMinigunPrefab, spawnPosition, Quaternion.identity);
                //melhoriaMinigunInstanciada.GetComponent<melhoria>().SetarMelhoria("MK2", 80, 30);
                ultimaMelhoriaMinigun = melhoriaMinigunInstanciada;
            }
            yield return null;
        }
    }

    IEnumerator SpawnMelhoriaLaser()
    {
        while (true)
        {
            if (gameManager.pontuacao > 900 && !gameManager.gatinho.laser && ultimaMelhoriaLaser == null && gameManager.gatinho.MK3)
            {
                Debug.Log("Laser");

                float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
                float y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
                Vector2 spawnPosition = new Vector2(x, y);

                GameObject melhoriaLaserInstanciada = Instantiate(melhoriaLaserPrefab, spawnPosition, Quaternion.identity);
                //melhoriaLaserInstanciada.GetComponent<melhoria>().SetarMelhoria("MK2", 80, 30);
                ultimaMelhoriaLaser = melhoriaLaserInstanciada;
            }
            yield return null;
        }
    }

    IEnumerator SpawnAsteroide()
    {
        while (true)
        {
            //Debug.Log("spawnou asteroide");
            float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            float y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            Vector2 spawnPosition = new Vector2(x, y);
            GameObject asteroideInstanciado = Instantiate(asteroidePrefab, spawnPosition, Quaternion.identity);
            asteroideInstanciado.GetComponent<asteroide>().setarGameManager(gameManager);
            yield return new WaitForSeconds(asteroideSpawnRate);
        }
    }
}
