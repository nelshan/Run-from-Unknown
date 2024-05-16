using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    public GameObject playerObject; // assign the player game object in the inspector
    public GameObject jumpscareObject; // assign the jumpscare game object in the inspector
    public Transform checkpointTransform; // assign the checkpoint transform in the inspector

    private bool jumpscareActive = false;
    private Animator jumpscareAnimator;
    public GameObject jumpscareSoundObject;

    private void Start()
    {
        jumpscareAnimator = jumpscareObject.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        // activate the jumpscare game object and play the animation
        jumpscareActive = true;
        jumpscareObject.SetActive(true);
        jumpscareAnimator.Play("jumpscare");

        // disable the player's movement script while the jumpscare is active
        playerObject.GetComponent<footsound1>().enabled = false;
        playerObject.GetComponent<FirstPersonController>().enabled = false;

        // play the jumpscare sound
        jumpscareSoundObject.GetComponent<AudioSource>().Play();

        // Move the parent object and its child object to a random position
        float minDistance = 30f;
        float maxDistance = 50f;
        Vector3 randomOffset = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized * Random.Range(minDistance, maxDistance);
        Vector3 newPosition = transform.parent.position + randomOffset;
        transform.parent.position = newPosition;
    }
}


    private void Update()
    {
        if (jumpscareActive && jumpscareAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            // once the jumpscare animation has finished playing, deactivate the jumpscare game object
            jumpscareObject.SetActive(false);
            jumpscareActive = false;

            // move the player to the checkpoint transform position and enable their movement scripts
            playerObject.transform.position = checkpointTransform.position;
            playerObject.GetComponent<footsound1>().enabled = true;
            playerObject.GetComponent<FirstPersonController>().enabled = true;
        }
    }
}
