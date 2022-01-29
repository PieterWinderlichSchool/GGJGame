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
    [SerializeField] private GameObject HellLightning;
    [SerializeField] private GameObject HeavenLightning;
    [SerializeField] private PostProcessVolume Volume;
    private ColorGrading cG;
    void Start()
    {
        //Volume.profile.TryGetSettings(out cG);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
		{
            SwitchToHeaven();
            //cG.colorFilter.value = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchToHell();
            //cG.colorFilter.value = Color.white;
        }
    }

    public void SwitchToHell()
	{
		//for (int i = 0; i < torches.Count; i++)
		//{
        //    torches[i].color = HellTorchColor;
		//}
        HellLightning.SetActive(true);
        HeavenLightning.SetActive(false);
        globalLight.intensity = 0.7f;
	}

    public void SwitchToHeaven()
	{
        //for (int i = 0; i < torches.Count; i++)
        //{
        //    torches[i].color = HellTorchColor;
        //}
        HellLightning.SetActive(false);
        HeavenLightning.SetActive(true);
        globalLight.intensity = 1.3f;
    }
}
