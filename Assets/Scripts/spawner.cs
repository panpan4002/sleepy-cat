using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [Header("Componentes")]
    private BoxCollider2D spawnArea;
    private gatinhoMovimento gatinhoMovimento;

    [Header("Spawner")]
    [SerializeField] private GameObject asteroidePrefab;
    [SerializeField] private float asteroideSpawnRate;

    void Start()
    {
        spawnArea = GetComponent<BoxCollider2D>();
        StartCoroutine("Spawn");
    }

    void Update()
    {

    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Debug.Log("spawnou asteroide");
            float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            float y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            Vector2 spawnPosition = new Vector2(x, y);
            Instantiate(asteroidePrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(asteroideSpawnRate);
        }
    }
}
