using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject lightObject;
    public AudioSource switchSound;

    private bool lightsAreOn = true;
    private bool switchIsInRange = false;
    public GameObject lightsText;

    void Start()
    {
        lightObject.SetActive(true);
        lightsText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("reach"))
        {
            switchIsInRange = true;
            lightsText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("reach"))
        {
            switchIsInRange = false;
            lightsText.SetActive(false);
        }
    }

    void Update()
    {
        if (switchIsInRange && Input.GetKeyDown(KeyCode.E))
        {
            lightsAreOn = !lightsAreOn;
            lightObject.SetActive(lightsAreOn);
            switchSound.Play();
        }
    }
}
