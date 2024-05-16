using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_D_U_A : MonoBehaviour
{
    public Sound_On_Trigger soundOnTrigger; // reference to Sound_On_Trigger object

    public Animator door;
    public GameObject doorOpenCroosshair;
    public AudioSource doorSound;
    public AudioSource lockedSound;

    public bool inReach;
    public bool unlocked;
    public bool locked;

    private bool lockSoundPlayed;

    void Start()
    {
        inReach = false;
        unlocked = false;
        locked = true;
        lockSoundPlayed = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
            inReach = true;
            doorOpenCroosshair.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
            inReach = false;
            doorOpenCroosshair.SetActive(false);
        }
    }

    void Update()
    {
        if (soundOnTrigger.audioSource.isPlaying && !lockSoundPlayed) // check if sound is playing
        {
            lockedSound.Play();
            lockSoundPlayed = true;
            return; // exit the method if sound is still playing
        }

        if (inReach && Input.GetMouseButtonDown(0))
        {
            if (!doorSound.isPlaying)
            {
                doorSound.Play();
            }
            if (unlocked)
            {
                StartCoroutine(OpenDoorAfterSound());
            }
            else if (!soundOnTrigger.audioSource.isPlaying)
            {
                lockedSound.Play();
            }
        }
    }

    void DoorOpens()
    {
        if (unlocked)
        {
            door.SetBool("open", true);
            door.SetBool("closed", false);
        }
    }

    IEnumerator OpenDoorAfterSound()
    {
        while (doorSound.isPlaying)
        {
            yield return null;
        }
        DoorOpens();
    }
}
