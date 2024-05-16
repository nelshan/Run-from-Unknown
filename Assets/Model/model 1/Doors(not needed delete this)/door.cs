using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject doorClose, doorOpen, doorMassageToOpen;
    public AudioSource OpenSound, closeSound;
    public bool opened;

    void Start() 
    {
        // Stop the closeSound audio source from playing at start
        closeSound.Stop();
    }
    void OnTriggerStay(Collider other) 
    {
        if(other.CompareTag("MainCamera"))
        {
            if(opened == false)
            {
                doorMassageToOpen.SetActive(true);
                if(Input.GetKey(KeyCode.E))
                {
                    doorClose.SetActive(false);
                    doorOpen.SetActive(true);
                    doorMassageToOpen.SetActive(false);
                    StartCoroutine(repeat());
                    opened = true;
                    
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            doorMassageToOpen.SetActive(false);
        }
    }

    IEnumerator repeat()
    {
        yield return new WaitForSeconds(5f);
        opened = false;
        doorClose.SetActive(true);
        doorOpen.SetActive(false);
    }
}
