using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggropenclosedoor : MonoBehaviour
{
    public Animator opencloseTrigger = null;
    public bool openTrigger = false;
    public bool closeTrigger = false;
	public AudioSource OpendoorSound;
    public AudioSource ClosedoorSound;


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(openTrigger)
            {
                opencloseTrigger.Play("DoorOpen", 0, 0.0f);
                gameObject.SetActive(false);
                OpendoorSound.Play();
            }
            else if(closeTrigger)
            {
                opencloseTrigger.Play("DoorClose", 0, 0.0f);
                gameObject.SetActive(false);
                ClosedoorSound.Play();
            }
        }
    }
}