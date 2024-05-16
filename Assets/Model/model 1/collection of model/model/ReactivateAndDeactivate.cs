using UnityEngine;
using System.Collections;

public class ReactivateAndDeactivate : MonoBehaviour {

    public GameObject jumpscareObject; // The game object to activate and deactivate
    public float jumpscareDuration = 1f; // The length of time to keep the object active before deactivating it again
    public GameObject jumpscareAudio; // The game object with the AudioSource component to play when the jumpscare object is activated
    public GameObject triggerArea; // The trigger area game object to deactivate after the jumpscare object is deactivated
    public GameObject player; // The player game object

    private AudioSource audioSource; // Reference to the AudioSource component attached to the jumpscare object
    private bool isJumpscareActive = false; // Whether the jumpscare object is currently active

    void Start() {
        // Get the AudioSource component from the jumpscare audio object
        audioSource = jumpscareAudio.GetComponent<AudioSource>();
        // If there is no AudioSource component, add one to the jumpscare audio object
        if (audioSource == null) {
            audioSource = jumpscareAudio.AddComponent<AudioSource>();
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject == player && !isJumpscareActive) {
            // Reactivate the jumpscare object
            jumpscareObject.SetActive(true);
            // Play the jumpscare sound
            audioSource.Play();
            // Start a coroutine to deactivate the object after the set duration
            StartCoroutine(DeactivateJumpscare());
            // Set isJumpscareActive to true
            isJumpscareActive = true;
        }
    }

    IEnumerator DeactivateJumpscare() {
        // Wait for the jumpscare duration to pass
        yield return new WaitForSeconds(jumpscareDuration);
        // Deactivate the jumpscare object and all its child objects
        jumpscareObject.SetActive(false);
        // Deactivate the trigger area object
        triggerArea.SetActive(false);
        // Set isJumpscareActive to false
        isJumpscareActive = false;
    }
}
