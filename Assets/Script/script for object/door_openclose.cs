using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_openclose : MonoBehaviour
{
    public Animator door;
    public GameObject DoorText;
    public AudioSource doorSound;
    public bool DoorinReach;

     void Start()
    {
        DoorinReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
            DoorinReach = true;
            DoorText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
            DoorinReach = false;
            DoorText.SetActive(false);
        }
    }

    void Update()
    {
        if (DoorinReach && Input.GetKey(KeyCode.E))
        {
            DoorOpens();
        }
        else
        {
            DoorCloses();
        }
    }

    void DoorOpens ()
    {
        door.SetBool("door_open", true);
        door.SetBool("door_close", false);
        doorSound.Play();

    }

    void DoorCloses()
    {
        door.SetBool("door_open", false);
        door.SetBool("door_close", true);
    }
}
