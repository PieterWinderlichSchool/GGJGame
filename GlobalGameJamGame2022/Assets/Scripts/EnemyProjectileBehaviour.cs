using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyProjectileBehaviour : MonoBehaviour
{

    public float projectilespeed;
    public Coroutine thisRoutine;
    public float timeFlying = 0;
    public bool isFlying = false;

    void Update()
    {
        if (isFlying = true)
        {

            timeFlying += Time.deltaTime;
        }
        else
        {
            Debug.Log("hit");
        }

    }
    public IEnumerator MoveProjectile(GameObject Player)
    {
        isFlying = true;
        //transform.LookAt(Player.transform.position);

        Vector3 diff = Player.transform.position - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

        while (true)
        {



            if (timeFlying < 2f)
            {
                transform.position += transform.right * Time.deltaTime * projectilespeed;
                yield return new WaitForSeconds(0.05f);
            }
            else
            {
                timeFlying = 0;
                isFlying = false;
                StopCoroutine(thisRoutine);
                resetPosition();
                yield break;
            }
        }
    }

    public void resetPosition()
    {
        transform.localPosition = Vector3.zero;
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("hit");
            resetPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Movement.Player.RemoveHealth(0.5f);

            resetPosition();
        }
    }
}