using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraFollow : MonoBehaviour
{
    //Cuando el juego inicia, la camará irá directamente al personaje.
    private Vector3 set = new Vector3 (0f, 0f, -10f);
    //como de suave seguirá la camara al personaje
    private float smooth = 0.25f;
    private Vector3 Velocity = Vector3.zero;

    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + set;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref Velocity, smooth);
    }
}
