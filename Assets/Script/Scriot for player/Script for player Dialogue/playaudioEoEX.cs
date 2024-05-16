using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playaudioEoEX : MonoBehaviour
{
    public GameObject audioObject; // The game object with an AudioSource component to play the audio
    public GameObject triggerArea; // The trigger area to detect trigger events

    private bool isPlaying = false; // Whether the audio is currently playing
    private bool shouldStop = false; // Whether the audio should be stopped on trigger exit
    private bool hasPlayed = false; // Whether the audio has already played once

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Start playing the audio if it's not already playing and hasn't been played before
            if (!isPlaying && !hasPlayed)
            {
                AudioSource audioSource = audioObject.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.loop = true;
                    audioSource.Play();
                    isPlaying = true;
                    hasPlayed = true;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop looping the audio if it should not be looped
            if (!shouldStop)
            {
                AudioSource audioSource = audioObject.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.loop = false;
                    shouldStop = true;
                }
            }
        }
    }

    void Update()
    {
        // Check if the audio has finished playing and should be stopped
        if (shouldStop && !audioObject.GetComponent<AudioSource>().isPlaying)
        {
            AudioSource audioSource = audioObject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Stop();
                isPlaying = false;
                shouldStop = false;
                hasPlayed = false;
            }
        }
    }
}
