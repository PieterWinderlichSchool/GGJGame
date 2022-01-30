using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthShop : MonoBehaviour
{
    [SerializeField] private Coins coins;
    [SerializeField] private HealthShopTrigger trigger;

    public void buyHealth()
    {
        if (coins.coinAmount >= 4)
        {
            coins.changeCoins(-4);
            //health van speler + 1
            Movement.Player.AddHealth(1);
            Debug.Log("health + 1");
        }
        else
        {
            trigger.OpenWarning();
        }
    } 
}
