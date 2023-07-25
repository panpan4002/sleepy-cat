using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudScale : MonoBehaviour
{
    [Header("Components")]
    private float screenWidth, screenHeight;
    private Image hudSR;


    void Start()
    {
        hudSR = GetComponent<Image>();

        screenWidth = Screen.width;
        screenHeight = Screen.height;


    }

    void Update()
    {
        hudSR.rectTransform.sizeDelta = new Vector2(screenWidth, screenWidth);
        //hudSR.transform.position = new Vector2(screenWidth / 2, screenHeight);
    }
}
