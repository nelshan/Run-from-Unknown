using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_On_Trigger : MonoBehaviour
{
    public AudioSource audioSource;
    private bool hasPlayed = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            audioSource.Play();
            hasPlayed = true;
        }
    }
}