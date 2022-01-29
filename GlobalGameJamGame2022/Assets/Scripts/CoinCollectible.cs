using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    [SerializeField] UICoins coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movement controller = collision.GetComponent<Movement>();

        if (controller != null)
        {
            coins.changeCoins(1);
            Destroy(gameObject);
        }    
    }
}
