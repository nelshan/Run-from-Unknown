using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject[] lights;
    public AudioClip lightBreakSound;
    public GameObject doorOpenCroosshair;
    public AudioSource lockSound;
    public GameObject triggerArea;

    private bool doorInReach;
    private int currentLightIndex = 0;
    private bool breakingLights;

    void Update()
    {
        if (doorInReach && Input.GetMouseButtonDown(0) && !breakingLights)
        {
            StartCoroutine(BreakLightsWithDelay());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("reach"))
        {
            doorInReach = true;
            doorOpenCroosshair.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("reach"))
        {
            doorInReach = false;
            doorOpenCroosshair.SetActive(false);
        }
    }

    private IEnumerator BreakLightsWithDelay()
    {
        breakingLights = true;
        float delayTime = 1f; // initial delay
        while (currentLightIndex < lights.Length)
        {
            AudioSource.PlayClipAtPoint(lightBreakSound, transform.position);
            lights[currentLightIndex].SetActive(false);
            currentLightIndex++;
            triggerArea.SetActive(true);
            if (currentLightIndex < lights.Length)
            {
                yield return new WaitForSeconds(delayTime);
                delayTime += 1f; // increase delay for each light
            }
            else
            {
    
                yield return new WaitForSeconds(1.0f); // final delay after activating trigger area
            }
        }
        breakingLights = false;
    }
}
