using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playaudioOnTrigger : MonoBehaviour
{
    public AudioSource radioSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !radioSound.isPlaying)
        {
            radioSound.Play();
            StartCoroutine(DeactivateAfterSound());
        }
    }

    IEnumerator DeactivateAfterSound()
    {
        yield return new WaitForSeconds(radioSound.clip.length);
        gameObject.SetActive(false);
    }
}
