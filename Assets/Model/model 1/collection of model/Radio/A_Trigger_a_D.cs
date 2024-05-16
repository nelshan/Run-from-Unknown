using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Trigger_a_D : MonoBehaviour
{
    public AudioSource radioSound;
    public GameObject triggerArea;

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
        triggerArea.SetActive(true);
    }
}
