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
    [SerializeField] private PostProcessVolume Volume;
    private bool isHell = true;

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
    }
}
