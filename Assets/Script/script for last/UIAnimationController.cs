using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIAnimationController : MonoBehaviour
{
    public GameObject uiObject;

    private Animator uiAnimator;
    private AudioSource audioSource;
    private bool animationFinished = false;

    void Start()
    {
        uiAnimator = uiObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // Play the UI animation
        uiAnimator.Play("creditani");

        // Play the sound clip from the game object's AudioSource
        audioSource.Play();

        // Check when the UI animation is finished playing
        StartCoroutine(CheckAnimationFinished());
    }

    IEnumerator CheckAnimationFinished()
    {
        while (uiAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return null;
        }

        // The UI animation has finished playing
        animationFinished = true;

        // Load the main menu scene if the sound clip has finished playing
        if (!audioSource.isPlaying)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    void Update()
    {
        // Load the main menu scene if the sound clip has finished playing and the UI animation has finished playing
        if (animationFinished && !audioSource.isPlaying)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
