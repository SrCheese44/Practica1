using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebotinMovimiento : MonoBehaviour
{

    public int velocidad = 15;
    bool arriba = true;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 2.78)
        {
            arriba = true;
        }
        else if (transform.position.y < -0.13)
        {

            arriba = false;
        }









        if (arriba == true)
        {
            transform.Translate(velocidad * Vector2.down * Time.deltaTime);


        }
        else if (arriba == false)
        {

            transform.Translate(velocidad * Vector2.up * Time.deltaTime);


        }












    }




}
