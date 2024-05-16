using System.Collections;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public Animator animator; // assign the animator for the object you want to animate
    public AudioSource audioSource; // assign the AudioSource component for the audio clip

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.Play("mannequin"); // play the animation
            audioSource.Play(); // play the audio clip
            StartCoroutine(DeactivateAnimator()); // wait for the animation to finish before deactivating the animator game object
        }
    }

    IEnumerator DeactivateAnimator()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); // wait for the animation to finish
        animator.gameObject.SetActive(false); // disable the animator game object
        gameObject.SetActive(false); // disable the trigger area object
    }
}
