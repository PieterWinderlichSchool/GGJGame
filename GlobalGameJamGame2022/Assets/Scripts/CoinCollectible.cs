using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    [SerializeField] Coins coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Movement controller = collision.GetComponent<Movement>();
        if(collision.CompareTag("Player"))
        {
            Debug.Log("fakka neef" + gameObject.name);
            coins.changeCoins(1);
            gameObject.SetActive(false);
            //Destroy(gameObject);

        }
        //if (controller != null)
        //{
        //     }    
    }
}
