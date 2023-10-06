using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Rotaciones : MonoBehaviour
{
    public bool izquierda;
   
    void Update()
    {
        RotacionObstaculo();
    }



    private void RotacionObstaculo()
    {
        if (izquierda == true)
        {
            transform.Rotate(Vector3.forward, Time.deltaTime * 190);
        }
        else
        {
            transform.Rotate(Vector3.back, Time.deltaTime * 190);

        }

    }


}
