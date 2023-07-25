using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [Header("PENIS")]
    [SerializeField] private GameObject gameOverPainel;
    [SerializeField] private GameObject pausaPainel;

    [SerializeField] AudioSource musiquinha;

    gameManager gameManager;
    bool pausado;

    private void Start()
    {
        GameObject gameManagerObject = GameObject.Find("Kiwi");
        gameManager = gameManagerObject.GetComponent<gameManager>();
        pausado = false;
    }

    private void Update()
    {

    }

    public void GameOver(bool simnao)
    {
        gameOverPainel.SetActive(simnao);
    }

    public void Pausa(bool simnao)
    {
        pausaPainel.SetActive(simnao);
    }

    public void BotaoSair()
    {
        Application.Quit();
    }

    public void BotaoReiniciar()
    {
        GameOver(false);
        SceneManager.LoadScene(1);
    }

    public void BotaoContinuar()
    {
        musiquinha.UnPause();
        Time.timeScale = 1;
        pausado = false;
        Pausa(false);
    }
}
