using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Contador : MonoBehaviour
{
    public TMP_Text textoContador;
    private float tiempo = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       tiempo -= Time.deltaTime;
       textoContador.text = tiempo.ToString();

        if(tiempo <= 0)
        {
            textoContador.text = "";
            Time.timeScale = 0;
        
        }
    }
}
