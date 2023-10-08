using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{     

    public TMP_Text textoContador;
    private float tiempo = 20;
    //Nombre de los menus
    public GameObject GameOver;
    public GameObject Pausa;
    public AudioSource Musica;

    private bool Perdiste = false;

    // Update is called once per frame
    void Update()
    {   //cuenta regresiva
        tiempo -= Time.deltaTime;
        textoContador.text = tiempo.ToString("#0.00");
        
        MenuPausa();
        TiempoFinalizado();
       

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartCurrentScene();
        }
       
    }


    void MenuPausa()
    {
      
        // true si el panel esta activado, false si no lo está
        if (!Perdiste)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !Pausa.activeSelf)
            {
                Pausa.SetActive(true);
                PauseGame();


            }
            else if (Input.GetKeyDown(KeyCode.Escape) && Pausa.activeSelf)
            {
                Pausa.SetActive(false);
                ResumeGame();
            }

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





    void TiempoFinalizado()
    {
        if (tiempo <= 0)
        {
            textoContador.text = "";
            Time.timeScale = 0;

            GameOver.SetActive(true);
            Perdiste = true;
            Musica.Stop();


        }

    }






    void RestartCurrentScene()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;

    }

}


