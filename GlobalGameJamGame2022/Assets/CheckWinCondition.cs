using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using Unity.VisualScripting;
using UnityEngine;

public class CheckWinCondition : MonoBehaviour
{

    public ModeSwitch modeSwitcher;
    public int coins;
    public int deadEnemies = 0;
    public bool HellVictory = false;
    public bool HeavenVictory = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (coins == 19)
        {
            Debug.Log("Grats");
            HellVictory = true;
        }else if (deadEnemies == 20 )
        {
            Debug.Log("Grats");
            HeavenVictory = true;
        }
        foreach(GameObject Enemies in  modeSwitcher.getHeavenEnemies())
        {
            deadEnemies = 0;
            if (Enemies == null)
            {
                deadEnemies++;
            }
        }

    }
}
