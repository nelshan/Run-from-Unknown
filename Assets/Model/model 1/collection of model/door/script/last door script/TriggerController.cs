using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerController : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject uiObject;
    public string nextScene;

    private bool triggerActivated;

    private void Start()
    {
        // Deactivate the UI object at start
        uiObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggerActivated)
        {
            triggerActivated = true;

            // Activate the UI object
            uiObject.SetActive(true);
            
            audioSource.Play();

            StartCoroutine(PlayAudioAndFadeOutScreen());
        }
    }

    private IEnumerator PlayAudioAndFadeOutScreen()
    {

        Animator animator = uiObject.GetComponent<Animator>();
        animator.Play("lastanima");

        // Wait until the audio is done playing
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        
        // Load the next scene
        SceneManager.LoadScene(nextScene);
    }
}
