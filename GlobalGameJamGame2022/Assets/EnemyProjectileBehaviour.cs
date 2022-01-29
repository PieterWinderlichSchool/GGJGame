using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyProjectileBehaviour : MonoBehaviour
{

    public float projectilespeed;
    public Coroutine thisRoutine;

    public IEnumerator MoveProjectile(GameObject Player)
    {
        
        //transform.LookAt(Player.transform.position);

            Vector3 diff = Player.transform.position - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
            while (true)
            {
                if (Vector3.Distance(transform.position, GetComponentInParent<Transform>().transform.localPosition) < 20)
                {
                    
                    transform.position += transform.right * Time.deltaTime * projectilespeed;
                    yield return new WaitForSeconds(0.05f);
                }
                else
                {
                    
                    StopCoroutine(thisRoutine);
                    resetPosition();
                    yield break;
                }
            }
    }

    public void resetPosition()
    {
        transform.position = GetComponentInParent<Transform>().transform.localPosition;
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            resetPosition();
        }
    }
}
