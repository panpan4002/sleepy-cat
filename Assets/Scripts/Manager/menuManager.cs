using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class menuManager : MonoBehaviour
{

    private void OnEnable()
    {

    }

    public void FreeMode()
    {
        SceneManager.LoadScene("Free Mode");
    }
}
