using UnityEngine;

public class T_Off_L_OnTrigger : MonoBehaviour
{
    public GameObject targetLight; // the light to turn off
    public AudioSource audioSource; // the audio source that will play the sound
    public AudioSource targetSound; // the sound to stop

    private bool isTriggered = false; // flag to check if trigger has been activated

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered) // check if the trigger was entered by the player object and has not been triggered before
        {
            targetLight.SetActive(false); // turn off the target light
            audioSource.Play(); // play the sound from the audio source

            if (targetSound.isPlaying) // check if the target sound is playing
            {
                targetSound.Stop(); // stop the target sound
            }

            isTriggered = true; // set the trigger flag to true
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isTriggered) // check if the trigger flag is true
        {
            gameObject.SetActive(false); // deactivate the trigger area
        }
    }
}

