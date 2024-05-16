using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupFlashlight : MonoBehaviour
{
    public GameObject PickUpCroosshair, ObjectFlashlight, PlayerFlashlight;
    public AudioSource PickupSound;
    public bool FlashlightInReach;

    void Start()
    {
        PickUpCroosshair.SetActive(false);
        PlayerFlashlight.SetActive(false);
        FlashlightInReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
            PickUpCroosshair.SetActive(true);
            FlashlightInReach = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
            PickUpCroosshair.SetActive(false);
            FlashlightInReach = false;
        }
    }

    void Update()
    {
        if(FlashlightInReach == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PickUpCroosshair.SetActive(false);
                FlashlightInReach = false;
                PickupSound.Play();
                PlayerFlashlight.SetActive(true);
                ObjectFlashlight.SetActive(false);
            }
        }
    }
}
