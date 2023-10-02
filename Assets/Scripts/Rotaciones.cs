using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Rotaciones : MonoBehaviour
{
    public bool izquierda;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
