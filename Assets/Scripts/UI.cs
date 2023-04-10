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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausado)
            {
                Pausa(false);
                pausado = false;
                Time.timeScale = 1;
                musiquinha.UnPause();
            }

            else

            {
                Pausa(true); 
                pausado = true;
                Time.timeScale = 0;
                musiquinha.Pause();
            }
        }

        if(gameManager.gatinhoVida.vida <= 0)
        {
            musiquinha.Stop();
            GameOver(true);
            Time.timeScale = 0;
        }
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
        gameManager.cena1 = false;
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
