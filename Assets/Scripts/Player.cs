using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Weapon_0[] WeaponSystems;
    private int _WeaponIndex = 0; 
    Rigidbody2D rb;//Variable en la cual se almacenara el objeto player
    float shipAngle;//angulo en el que se encuentra el jugador

    public float speed;//Velocidad a la que se movera
    public float rotationInterpolation = 0.8f;//Tiempo de rotacion
    public bool isMoving, isFire;//variable para detectar si nuestro personaje esta en movimiento

    private Vector2 control, input;
    public Joystick joystick, joystick2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//inicializamos el objeto del player
    }

    void Update()//(no constante)
    {
        //Esto detecta el input de nuestro usuario de forma vertical u horisontal
        input.x = joystick.Horizontal;
        input.y = joystick.Vertical;

        float horizontal = joystick2.Horizontal;
        float vertical = joystick2.Vertical;

        if(input.x != 0 || input.y !=0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if(horizontal != 0 || vertical !=0)
        {
            isFire = true;

        }
        else
        {
            isFire = false;
        }

        //Weapon sistem
        if(Input.GetKey(KeyCode.Space))
        {
            WeaponSystems[_WeaponIndex].Fire();
        }

        if(Input.GetKey(KeyCode.Q))
        {
            _WeaponIndex--;
            if(_WeaponIndex < 0)
            {
                _WeaponIndex = WeaponSystems.Length - 1;
            }
        }

        if(Input.GetKey(KeyCode.E))
        {
            _WeaponIndex++;
            if(_WeaponIndex > WeaponSystems.Length)
            {
                _WeaponIndex = 0;
            }
        }

    }

    void FixedUpdate()//mejora las fisicas del personaje (física continua constante)
    {
        Vector2 direction = Vector2.up * joystick.Vertical + Vector2.right * joystick.Horizontal;
        Vector2 arm = Vector2.up * joystick2.Vertical + Vector2.right * joystick2.Horizontal;

        if(isMoving)
        {
            GetRotation();
            //rb.velocity = direction * speed * Time.fixedDeltaTime;//Time.fixedDeltaTime(convertidor a micro segundos) recomendable para dar efectos suaves
        }
        
        if(isFire)
        {
            GetRotation();
            rb.velocity = arm * speed * Time.fixedDeltaTime;
        }
            
        //GetRotation();//Rota el player
    }

    void GetRotation()//control de rotacion
    {
        Vector2 lookDir = new Vector2(-input.x, input.y);

        if(isMoving)//isMoving
        {
            shipAngle = Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg;//convertimos el input en un angulo
            //el resultado esta en radianes por lo que lo multiplicamos por Mathf.Rad2Deg
        }
        
        if(rb.rotation <= -90 && shipAngle >= 90)
        {
            rb.rotation += 360;
            rb.rotation = Mathf.Lerp(rb.rotation, shipAngle, rotationInterpolation);
        }
        else if(rb.rotation >= 90 && shipAngle <= -90)
        {
            rb.rotation -= 360;
            rb.rotation = Mathf.Lerp(rb.rotation, shipAngle, rotationInterpolation);
        }
        else{
            rb.rotation = Mathf.Lerp(rb.rotation, shipAngle, rotationInterpolation);
        }
    }
}