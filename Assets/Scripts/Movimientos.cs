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

    private int ContadorMonedas;
    public TMP_Text Coins;
    

    private bool stun;
    private float time;

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
        //movimiento
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
            rb.Sleep();
            rbSprite.color = Color.red;
        }
        if (stun == true && time > 2)
        {
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
        {
            Destroy(collision.gameObject);

            ContadorMonedas = ContadorMonedas + 1;
            Coins.text = ContadorMonedas.ToString("Platajena: 0  ");
            FX.Play();
            
        }


        if (collision.gameObject.CompareTag("Final"))
        {

            Time.timeScale = 0;
            NivelEnd.SetActive(true);
            Invoke("CargarNivel" , 3.0f);

            MensajeFinalMonedas();


            Musica.Stop();

        }



        void CargarNivel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }





        void MensajeFinalMonedas()
        {
            if (ContadorMonedas == 0)
            {
                TextoNivelEnd.text = "Jeremias llegó, pero ¿a qué costo?";
            }
            else if (ContadorMonedas < 3)
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



