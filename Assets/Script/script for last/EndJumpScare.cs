using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndJumpScare : MonoBehaviour
{
    public GameObject playerObject; // assign the player game object in the inspector
    public GameObject jumpscareObject; // assign the jumpscare game object in the inspector
    public GameObject jumpscareSoundObject;
    public float fadeOutTime = 2f; // time in seconds to fade out screen
    private bool jumpscareActive = false;
    private Animator jumpscareAnimator;
    private AudioSource audioSource;

    public GameObject uiObject;
    public AudioSource endaudioSource;

    private void Start()
    {
        jumpscareAnimator = jumpscareObject.GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();

        // Deactivate the UI object at start
        uiObject.SetActive(false);
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

            // Activate the UI object
            uiObject.SetActive(true);
            endaudioSource.Play();
        }
    }

    private void Update()
    {
        if (jumpscareActive && jumpscareAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            StartCoroutine(FadeOutScreenAndLoadCredits());
        }
    }

    private IEnumerator FadeOutScreenAndLoadCredits()
    {
        // Fade out the screen
        float elapsedTime = 0;
        while (elapsedTime < fadeOutTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeOutTime);
            uiObject.GetComponent<CanvasGroup>().alpha = alpha;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Wait until the end audio is done playing
        while (endaudioSource.isPlaying)
        {
            yield return null;
        }

        // Load the end credits scene
        SceneManager.LoadScene("Credits");
    }
}