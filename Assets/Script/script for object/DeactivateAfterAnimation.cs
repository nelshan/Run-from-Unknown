using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAfterAnimation : MonoBehaviour
{
    private Animator animator;
    private bool hasAnimationFinished = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !hasAnimationFinished)
        {
            // Deactivate the game object after the animation is done playing
            gameObject.SetActive(false);
            hasAnimationFinished = true;
        }
    }
}
