using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class ModeSwitch : MonoBehaviour
{
    [SerializeField] private PostProcessVolume Volume;
    private ColorGrading cG;
    void Start()
    {
        Volume.profile.TryGetSettings(out cG);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
		{
            cG.colorFilter.value = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cG.colorFilter.value = Color.white;
        }
    }
}
