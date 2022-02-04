using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//este es el la creacion del objeto arma que permite crear y disparar las balas
public class Weapon_0 : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public Bullet_0 BulletPrefab;
    public float FireRate = 0f;
    private float _fireRateCounter;
    public bool NotFire = false;

    private void FixedUpdate() 
    {

       _fireRateCounter += Time.deltaTime; 
        if(Input.GetKey(KeyCode.Space))
        {
            Fire();
        }

        if(NotFire == true)
        {
            Fire();
        }

    }

    public void Fire()
    {
        if(_fireRateCounter > FireRate)
        {
            _fireRateCounter = 0;
            foreach (var spawnPoint in SpawnPoints)
            {
                Instantiate(BulletPrefab, spawnPoint);
            }

        }
    }

    public void StartFire()
    {
        NotFire = false;
    }
    public void StopFire()
    {
        NotFire = true;
    }
}
