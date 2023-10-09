using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Rotaciones : MonoBehaviour
{
    //opción para que gire en sentido contrario y añadir variedad en el gameplay.
    public bool izquierda;
   
    void Update()
    {
        RotacionObstaculo();
    }



    private void RotacionObstaculo()
    {
        if (izquierda == true)
        {
            transform.Rotate(Vector3.forward, Time.deltaTime * 130);
        }
        else
        {
            transform.Rotate(Vector3.back, Time.deltaTime * 100);

        }

    }


}
