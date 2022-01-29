using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class MovementAI : MonoBehaviour
{
    public enum States{Patrolling, combat, chasing}

    public States enemyStates;

    public float Speed;
    public float chaseSpeed;

    public float TimeBetweenInverting;

    public Coroutine currentRoutine;
    public SpriteRenderer SRenderer;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        currentRoutine = StartCoroutine(Patrolling());
    }

    // Update is called once per frame
    void Update()
    {
        TimeBetweenInverting += Time.deltaTime;
    }

    public IEnumerator Patrolling()
    {
        while (true)
        {
            transform.position += chooseDirection();

            
            yield return new WaitForSeconds(0.1f);
        }
        
    }

    public IEnumerator Combat()
    {
        yield return new WaitForSeconds(0.1f);
    }

    public IEnumerator Chasing()
    {
        while (true)
        {
            
            Debug.Log(Speed *10 * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position,player.transform.position, chaseSpeed * 250 * Time.deltaTime);
            
            
            if (Vector3.Distance(transform.position, player.transform.position) <= 3f)
            {
            
                SetNewState(States.combat);
                yield break;
            }
            yield return new WaitForSeconds(0.1f);

        }
        
    }

    public void InvertSpeed()
    {
        SRenderer.flipX = !SRenderer.flipX;
        Speed *= -1;
    }

    public Vector3 chooseDirection()
    {
        Vector3 newPositionDirection = new Vector3(Speed, 0, 0);
        int changeDirection = Mathf.FloorToInt(Random.Range(1, 100));
        if (changeDirection > 75)
        {
            int directionInt = Mathf.FloorToInt((Random.Range(1, 100)));
            if (directionInt > 75 && TimeBetweenInverting >= 2f)
            {
                TimeBetweenInverting = 0;
                InvertSpeed();
            }
            int randoNumbero = Mathf.FloorToInt(Random.Range(1, 500));
            
            if (randoNumbero > 200)
            {
                newPositionDirection.y = Speed;
                newPositionDirection.x = 0;
            }else
            { newPositionDirection.y = 0;
                newPositionDirection.x = Speed;}
        }
        

        return newPositionDirection;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            InvertSpeed();  
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            SetNewState(States.chasing);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            SetNewState(States.Patrolling);
        }
    }

    private void SetNewState(States newState)
    {
        StopCoroutine(currentRoutine);
        
        switch (newState)
        {
            case  States.Patrolling:
               currentRoutine =  StartCoroutine(Patrolling());
                enemyStates = newState;
                
                break;
            case States.chasing :
                currentRoutine =  StartCoroutine(Chasing());
                enemyStates = newState;
               
                break;
            case States.combat :
                currentRoutine =   StartCoroutine(Combat());
                enemyStates = newState;
           
                break;
            default:
                Debug.Log("No state found");
                break;
        }
    }
}
