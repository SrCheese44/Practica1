using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class Movimientos : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer rbSprite;
    //variables asociadas al movimiento
    public float speed;
    private float move;

    private bool stun;
    private float time;

  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>(); 
        
       
    }
    void Update()
    {
        //movimiento
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        
        move = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, move * speed);

        if (stun == true)
        {
            time = Time.deltaTime + time;
            rb.Sleep();
            rbSprite.color = UnityEngine.Color.red;
        }
        if (stun == true && time > 2)
        {
            rb.WakeUp();
            stun = false;         
            time = 0;
            rbSprite.color = new UnityEngine.Color(0.4589239f, 0.2766109f, 0.5283019f, 1f);

        }



    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bordes"))
        {
          
            stun = true;
           
        }

      


    }   
  
 }



