using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;



public class MovementAI : MonoBehaviour
{
    public enum States{Patrolling, combat, chasing}

    public States enemyStates;

    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Patrolling());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Patrolling()
    {
        while (true)
        {
             Debug.Log("hit");
            transform.position += new Vector3();
            yield return new WaitForSeconds(1f);
        }
        
    }

    public void Combat()
    {
        
    }

    public void Chasing()
    {
        
        
    }
    
    

}
