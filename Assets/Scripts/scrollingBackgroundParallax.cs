using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class scrollingBackgroundParallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;
    private Vector2 startPos;
    private float sizeY;

    void Start()
    {
        startPos = transform.position;
        sizeY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        transform.position = new Vector2(0, transform.position.y + -parallaxSpeed * Time.deltaTime);

        if(transform.position.y <= startPos.y - sizeY)
        {
            transform.position = startPos;
        }
    }
}
