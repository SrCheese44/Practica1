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
    {//Referenciamos al objeto al cual seguirá el enemigo, en este caso, el personaje "Jeremias"
       jeremias = GameObject.Find("Personaje").GetComponent<Movimientos>();

        MovimientoEnemigo();
    }






    private void MovimientoEnemigo()
    {
        float Velo = 3000 * Time.deltaTime;
        Vector2 Mov = Vector2.MoveTowards(Enemigo.transform.position, jeremias.rb.transform.position, Velo);
        float EnemigoVelx = Mov.x - Enemigo.transform.position.x ;
        float EnemigoVely = Mov.y - Enemigo.transform.position.y;
        Enemigo.velocity = new Vector2(EnemigoVelx, EnemigoVely);
    }












}
