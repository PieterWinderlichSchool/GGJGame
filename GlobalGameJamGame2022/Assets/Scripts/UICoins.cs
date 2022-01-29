using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoins : MonoBehaviour
{
    Text coinCount;
    public Coins coins;

    void Start()
    {
        coinCount = GetComponent<Text>();
    }

    void Update()
    {
        coinCount.text = coins.coinAmount.ToString();
    }
}
