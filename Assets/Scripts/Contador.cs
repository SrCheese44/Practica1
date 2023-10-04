using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{
    public TMP_Text textoContador;
    private float tiempo = 5;
    public GameObject GameOver;
    public GameObject Pausa;
    private bool isPaused = false;
    private bool Perdiste = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tiempo -= Time.deltaTime;
        textoContador.text = tiempo.ToString();

        MenuPausa();

        if (tiempo <= 0)
        {
            textoContador.text = "";
            Time.timeScale = 0;

            GameOver.SetActive(true);
            Perdiste = true;

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartCurrentScene();
        }





    }


    void MenuPausa()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Perdiste == false)
        {
            Pausa.SetActive(true);
            PauseGame();


        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Pausa.SetActive(false);
            ResumeGame();
        }

    }



    void PauseGame()
    {
        Time.timeScale = 0;
   
        
    }

   
    void ResumeGame()
    {
        Time.timeScale = 1; 
        
       

    }



    void RestartCurrentScene()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;

    }

}


