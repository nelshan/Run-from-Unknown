using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playaudioOntrigger : MonoBehaviour
{
    public AudioClip audioClip; // The audio clip to play when the player enters the trigger area
    public bool hasPlayed = false; // Keeps track of whether the audio has already been played

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !hasPlayed) // Check if the player has entered the trigger area and the audio hasn't been played yet
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position); // Play the audio clip at the position of the trigger
            hasPlayed = true; // Mark the audio as having been played
        }
    }
    /*public AudioSource playsound;

    void OnTriggerEnter(Collider other) 
    {
        playsound.Play();
    }*/
}
