using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opencloseDoorSound : MonoBehaviour
{
    public Animator doorAnimator;
    public bool doorIsOpen;
    public bool doorIsLocked;
    public GameObject doorCrosshair;
    public AudioSource opendoorSound;
    public AudioSource jumpdoorSound;
    public AudioSource doorLockSound;
    public GameObject lightCollection;
    public GameObject flashlight;
    public float doorCloseTime = 2f;
    public bool doorInReach;

    void Start()
    {
        doorInReach = false;
        doorIsOpen = false;
        doorIsLocked = false;
        doorCrosshair.SetActive(false);
        lightCollection.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
            doorInReach = true;
            doorCrosshair.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
            doorInReach = false;
            doorCrosshair.SetActive(false);
        }
    }

    void Update()
    {
        if (doorInReach && !doorIsOpen && !doorIsLocked && Input.GetMouseButtonDown(0))
        {
            // play the open door sound
            opendoorSound.Play();
            StartCoroutine(OpenDoor());
        }
        else if (doorInReach && doorIsOpen && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(CloseDoor());
        }
        else if (doorInReach && doorIsLocked && Input.GetMouseButtonDown(0))
        {
            doorLockSound.Play();
        }
    }

    private IEnumerator OpenDoor()
{
    // start the door opening animation
    doorAnimator.Play("Opening");

    // set the door state to open
    doorIsOpen = true;
    
    // play the jump door sound after the door is fully open
    jumpdoorSound.Play();

    // randomly flicker the lights for a short duration
    float flickerDuration = 2;
    float flickerInterval = 0.02f;
    float flickerTime = 0f;
    while (flickerTime < flickerDuration)
    {
        // randomly turn on/off each light in the collection
        foreach (Light light in lightCollection.GetComponentsInChildren<Light>())
        {
            light.enabled = Random.value < 0.5f;
        }

        // wait for a short interval before flickering again
        yield return new WaitForSeconds(flickerInterval);

        flickerTime += flickerInterval;
    }

    // close the door after a short delay
    StartCoroutine(CloseDoor());
    
    // turn off the lights and flashlight
    lightCollection.SetActive(false);
    flashlight.SetActive(false);
}

    private IEnumerator CloseDoor()
    {
        doorAnimator.Play("Closing");
        yield return new WaitForSeconds(doorCloseTime);
        yield return new WaitForSeconds(doorLockSound.clip.length);
        doorIsOpen = false;
        doorIsLocked = true;
        doorLockSound.Play();
    }
}
