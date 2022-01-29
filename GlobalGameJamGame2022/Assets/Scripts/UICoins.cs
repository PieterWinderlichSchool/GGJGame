using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoins : MonoBehaviour
{
    Text coinCount;
    public int coinAmount = 0;

    public void changeCoins(int amount)
    {
        coinAmount += amount;
    }

    void Start()
    {
        coinCount = GetComponent<Text>();
    }

    void Update()
    {
        coinCount.text = coinAmount.ToString();
    }
}
