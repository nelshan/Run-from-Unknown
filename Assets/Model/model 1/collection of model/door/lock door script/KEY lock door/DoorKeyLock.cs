using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorKeyLock : MonoBehaviour
{
    public Animator door;
    public GameObject doorOpenCroosshair;
    public GameObject KeyINV;
    public GameObject lockedCanvas;
    public AudioSource doorSound;
    public AudioSource lockedSound;

    public bool inReach;
    public bool unlocked;
    public bool locked;
    public bool hasKey;

    void Start()
    {
        inReach = false;
        hasKey = false;
        unlocked = false;
        locked = true;
        lockedCanvas.SetActive(false); // Disable the canvas on start
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
        if (KeyINV.activeInHierarchy)
        {
            locked = false;
            hasKey = true;
        }
        else
        {
            hasKey = false;
        }

        if (hasKey && inReach && Input.GetMouseButtonDown(0))
        {
            if (!doorSound.isPlaying)
            {
                doorSound.Play();
            }
            unlocked = true;
            StartCoroutine(OpenDoorAfterSound());
        }
        else
        {
            DoorCloses();
        }

        if (locked && inReach && Input.GetMouseButtonDown(0))
        {
            lockedSound.Play();
            lockedCanvas.SetActive(true); // Show the canvas
            StartCoroutine(HideLockedCanvas());
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

    void DoorCloses()
    {
        if (unlocked)
        {
            door.SetBool("open", false);
            door.SetBool("closed", true);
        }
    }

    IEnumerator HideLockedCanvas()
    {
        yield return new WaitForSeconds(3f); // Hide the canvas after 3 seconds
        lockedCanvas.SetActive(false);
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
