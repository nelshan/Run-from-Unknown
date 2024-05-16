using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeOnTrigger : MonoBehaviour
{
    public Animator Dooranimator;
    public AudioSource doorCloseSound;
    public bool playerEnteredTrigger = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !playerEnteredTrigger)
        {
            StartCoroutine(CloseDoor());
        }
    }

    private IEnumerator CloseDoor()
    {
        doorCloseSound.Play();
        Dooranimator.Play("Closing");
        

        // destroy the trigger and stop the sound
        Destroy(gameObject);

        yield return new WaitForSeconds(0f);
    }
}
