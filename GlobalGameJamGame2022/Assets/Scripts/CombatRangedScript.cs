using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRangedScript : MonoBehaviour
{

    public float Damage;

    public float ProjectileSpeedInterval;

    public GameObject projectileToFire;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    public void FireProjectile()
    {
        GameObject newProjectile = Instantiate(projectileToFire, transform.position, Quaternion.identity);
        BulletBehaviour bBehaviour = newProjectile.GetComponent<BulletBehaviour>();
        StartCoroutine(bBehaviour.MoveProjectile(ProjectileSpeedInterval));
    }
    
}
