using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectTrowTrigger : MonoBehaviour
{
    public GameObject TrowActivator;
    private bool isTriggered = false; // flag to check if trigger has been activated

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered && other.CompareTag("Player")) // check if the trigger has not been activated and the other object is the player
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            TrowActivator.SetActive(true);
            StartCoroutine(DeactivateTrowActivator());
            isTriggered = true; // set the trigger flag to true
        }
    }

    private IEnumerator DeactivateTrowActivator()
    {
        yield return new WaitForSeconds(0.5f);
        TrowActivator.SetActive(false);
    }
}

