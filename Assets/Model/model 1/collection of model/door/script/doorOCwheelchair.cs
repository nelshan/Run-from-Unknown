using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOCwheelchair : MonoBehaviour
{
    public Animator doorAnimator;
    public AudioSource doorOpenSound;
    public AudioSource doorCloseSound;
    public bool playerEnteredTrigger = false;
    public float doorCloseDelay = 3f; // Time in seconds before the door automatically closes

    public Animator otherObjectAnimator;
    public bool otherObjectPlayed = false;

    public AudioSource otherObjectSound;

    private IEnumerator OpenDoor()
    {
        doorOpenSound.Play();
        doorAnimator.Play("Opening");

        // Wait for the door to fully open before playing the other object's animation
        yield return new WaitForSeconds(doorAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Play the other object's animation
        otherObjectAnimator.Play("wheelchair");
        otherObjectSound.Play();
        otherObjectPlayed = true;

        // Wait for the other object's animation to complete before closing the door
        while (otherObjectAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        // Wait for door close delay
        yield return new WaitForSeconds(doorCloseDelay);

        // Play door close sound and animation
        doorCloseSound.Play();
        doorAnimator.Play("Closing");

        // Wait for the door to fully close before resetting trigger and other object played flag
        yield return new WaitForSeconds(doorAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Deactivate trigger area
        gameObject.SetActive(false);

        playerEnteredTrigger = false;
        otherObjectPlayed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerEnteredTrigger && !otherObjectPlayed)
        {
            playerEnteredTrigger = true;
            StartCoroutine(OpenDoor());
        }
    }
}
