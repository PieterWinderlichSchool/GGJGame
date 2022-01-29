using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinAmount;

    private void Start()
    {
        coinAmount = 0;
    }
    public void changeCoins(int amount)
    {
        coinAmount += amount;
    }
}
