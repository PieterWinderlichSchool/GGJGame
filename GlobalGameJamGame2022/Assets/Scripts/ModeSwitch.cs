using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Experimental.Rendering.Universal;

public class ModeSwitch : MonoBehaviour
{
    [SerializeField] private List<Light2D> torches = new List<Light2D>();
    [SerializeField] private Light2D globalLight;
    [SerializeField] private Color HellTorchColor;
    [SerializeField] private Color HeavenTorchColor;
    [SerializeField] private List<GameObject> HellObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> HeavenObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> HellCreatures = new List<GameObject>();
    [SerializeField] private List<GameObject> HeavenCreatures = new List<GameObject>();
    [SerializeField] private PostProcessVolume Volume;
    private bool isHell = true;

    private void Start()
    {
        SwitchToHell();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(isHell)
			{
                SwitchToHeaven();
            }
            else
			{
                SwitchToHell();
            }
            isHell = !isHell;
        }
    }

    public void SwitchToHell()
	{
		for (int i = 0; i < HellObjects.Count; i++)
		{
            HellObjects[i].SetActive(true);
        }
        for (int i = 0; i < HeavenObjects.Count; i++)
        {
            HeavenObjects[i].SetActive(false);
        }
        globalLight.intensity = 0.7f;

        for (int i = 0; i < HellCreatures.Count; i++)
        {
            if (HeavenCreatures[i] != null && HellCreatures[i] != null)
            {
                HellCreatures[i].SetActive(true);
                HellCreatures[i].transform.position = HeavenCreatures[i].transform.position;
            }
        }
        for (int i = 0; i < HeavenCreatures.Count; i++)
        {
            if (HeavenCreatures[i] != null && HellCreatures[i] != null)
            {
                HeavenCreatures[i].SetActive(false);
            }
        }
    }

    public void SwitchToHeaven()
	{
        for (int i = 0; i < HellObjects.Count; i++)
        {
            HellObjects[i].SetActive(false);
        }
        for (int i = 0; i < HeavenObjects.Count; i++)
        {
            HeavenObjects[i].SetActive(true);
        }
        globalLight.intensity = 1.3f;

        for (int i = 0; i < HeavenCreatures.Count; i++)
        {
            if (HeavenCreatures[i] != null && HellCreatures[i] != null)
            {
                HeavenCreatures[i].SetActive(true);
                HeavenCreatures[i].transform.position = HellCreatures[i].transform.position;
            }
        }
        for (int i = 0; i < HellCreatures.Count; i++)
        {
            if (HeavenCreatures[i] != null && HellCreatures[i] != null)
            {
                HellCreatures[i].SetActive(false);
            }
        }  
    }

    public List<GameObject> getHeavenEnemies()
    {
        return HeavenCreatures;
    }
}
