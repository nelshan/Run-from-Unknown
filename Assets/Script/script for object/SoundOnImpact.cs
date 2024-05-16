using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnImpact : MonoBehaviour
{
    public AudioSource impactSound;
    public GameObject otherchair;
    private bool hasPlayed = false; // flag to check if the audio has been played before

    void OnCollisionEnter(Collision other)
    {
        if (other.relativeVelocity.magnitude > 0.75f && !hasPlayed) // check if the relative velocity is greater than 0.75 and the audio has not been played
        {
            impactSound.Play();
            hasPlayed = true; // set the flag to true to indicate that the audio has been played
            otherchair.SetActive(false);
        }
    }
}
