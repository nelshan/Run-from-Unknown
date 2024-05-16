using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstLight_TriggerArea : MonoBehaviour
{
    public Light lightToTurnOn;
    public float delay = 1.0f;
    public GameObject audioObjectOn;
    //public GameObject audioObjectOff;
    private bool playerEntered = false;
    private bool lightTurnedOn = false;

    private void Start()
    {
        lightToTurnOn.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !lightTurnedOn)
        {
            playerEntered = true;
            Invoke("TurnOnLight", delay);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = false;
            CancelInvoke("TurnOnLight");
            TurnOffLight();
        }
    }

    private void TurnOnLight()
    {
        if (playerEntered && !lightTurnedOn)
        {
            lightToTurnOn.enabled = true;
            lightTurnedOn = true;
            if (audioObjectOn != null)
            {
                audioObjectOn.GetComponent<AudioSource>().Play();
            }
        }
    }

    private void TurnOffLight()
    {
        lightToTurnOn.enabled = false;
        
    }
}
