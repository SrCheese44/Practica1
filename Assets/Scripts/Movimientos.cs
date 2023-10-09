using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using static UnityEngine.GraphicsBuffer;

public class Movimientos : MonoBehaviour
{
    public Rigidbody2D rb;
    SpriteRenderer rbSprite;

    Color inicial;

    //variables asociadas al movimiento
    public float speed;
    private float move;
    //variables asociadas al numero de coleccionables
    private int ContadorMonedas;
    public TMP_Text Coins;
    
    
    private bool stun;
    private float time;
    //variables asociadas a la pantalla de final de nivel
    public GameObject NivelEnd;
    public TMP_Text TextoNivelEnd;

    public AudioSource Musica;
    public AudioSource FX;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
        inicial = rbSprite.color;
        FX = GameObject.Find("FX").GetComponent<AudioSource>();

    }
    void Update()
    {
        MovimientoPersonaje();
        StunPersonaje();

 

    }
    


    private void MovimientoPersonaje()
    {
        //si quisieramos un impulso de algún tipo : rb.AddForce(Vector.(whatever)*(magnitud, 10 por ejemplo)*ForceMode2D.Impulse o Force)
        //movimiento en base a la velocidad, esto quiere decir que tiene fisicas añadidas
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        move = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, move * speed);
    }

    private void StunPersonaje()
    {

        //al tocar una pared, recibes stun
        if (stun == true)
        {
            time = Time.deltaTime + time;
            //Con Sleep "detienes" solo al personaje
            rb.Sleep();
            rbSprite.color = Color.red;
        }
        if (stun == true && time > 2)
        {
            //Con WakeUp "despiertas" solo al personaje
            rb.WakeUp();
            stun = false;
            time = 0;
            //rbSprite.color = new UnityEngine.Color(0.4589239f, 0.2766109f, 0.5283019f, 1f);
            rbSprite.color = inicial;

        }


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bordes"))
        {
          
            stun = true;
           
        }
       

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        { //Destruir el objeto con el que se colisiona, para destruir al jugador sería  Destroy(gameObject);
            Destroy(collision.gameObject);

            ContadorMonedas = ContadorMonedas + 1;
            Coins.text = ContadorMonedas.ToString("Platajena: 0  ");
            FX.Play();
            
        }


        if (collision.gameObject.CompareTag("Final"))
        {

            Time.timeScale = 0;
            NivelEnd.SetActive(true);

            MensajeFinalMonedas();


            Musica.Stop();

        }








        void MensajeFinalMonedas()
        {
            if (ContadorMonedas == 0)
            {
                TextoNivelEnd.text = "Jeremias llegó, pero ¿a qué costo?";
            }
            else if (ContadorMonedas <= 3)
            {
                TextoNivelEnd.text = "Jeremias ha conseguido escapar, pero le rugen las tripas...";
            }
            else if (ContadorMonedas <= 8)
            {
                TextoNivelEnd.text = "Jeremias se ha quedado satisfecho, pero no lleno...";
            }
            else if (ContadorMonedas == 9)
            {
                TextoNivelEnd.text = "Felicidades! Jeremias se ha comido todo! ";
            }

        }








    }

    



}



