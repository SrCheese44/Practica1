using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoChase : MonoBehaviour
{
    public Rigidbody2D Enemigo;
    public Movimientos jeremias;


    void Start()
    {
        Enemigo = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
       jeremias = GameObject.Find("Personaje").GetComponent<Movimientos>();

        MovimientoEnemigo();
    }






    private void MovimientoEnemigo()
    {
        float step = 3000 * Time.deltaTime;
        Vector2 Mov = Vector2.MoveTowards(Enemigo.transform.position, jeremias.rb.transform.position, step);
        float EnemigoVelx = Mov.x - Enemigo.transform.position.x ;
        float EnemigoVely = Mov.y - Enemigo.transform.position.y;
        Enemigo.velocity = new Vector2(EnemigoVelx, EnemigoVely);
    }












}
