using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloseTrigger : MonoBehaviour
{
    public Animator door;
    public AudioSource doorSound;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DoorCloses();
        }
    }

    void DoorCloses()
    {
        door.SetBool("open", false);
        door.SetBool("closed", true);
        doorSound.Play();
    }
}
