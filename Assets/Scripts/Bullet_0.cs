using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Esta es la bala 0 que se creara como proyectil
public class Bullet_0 : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float Speed;
    public int damage;
    private void Start() 
    {
        rigidbody.AddRelativeForce(new Vector2(x:0, y:Speed), ForceMode2D.Impulse);
        Destroy(gameObject, t:30f);
    }

    /*private void OnTriggerEnter2D(Collider2D tag) 
    {
        if(tag.CompareTag("Enemy"))
        {
            Debug.Log("hit enemy");
            //var meteoroidController = tag.GetComponent<>();
        }
    }*/

}