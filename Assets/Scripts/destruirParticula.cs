using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruirParticula : MonoBehaviour
{
    void Start()
    {
        Invoke("Destruir", 1f);
    }

    void Update()
    {
        
    }

    void Destruir()
    {
        Destroy(gameObject);
    }
}
