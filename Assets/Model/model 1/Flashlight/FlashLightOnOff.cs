using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightOnOff : MonoBehaviour
{
    public GameObject flashlight;
    public AudioSource turnOn;
    public AudioSource turnOff;
    
    private bool isFlashlightOn = false;

    void Start()
    {
        flashlight.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFlashlightOn = !isFlashlightOn;
            
            if (isFlashlightOn)
            {
                flashlight.SetActive(true);
                turnOn.Play();
            }
            else
            {
                flashlight.SetActive(false);
                turnOff.Play();
            }
        }
    }
}
