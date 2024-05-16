using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevDoor : MonoBehaviour
{
    public GameObject elevDoorClose, elevDoorOpen, doorMassageToOpen;
    public AudioSource OpenSound;
    public bool opened;

    void OnTriggerStay(Collider other) 
    {
        if(other.CompareTag("MainCamera"))
        {
            if(opened == false)
            {
                doorMassageToOpen.SetActive(true);
                if(Input.GetKey(KeyCode.E))
                {
                    elevDoorClose.SetActive(false);
                    elevDoorOpen.SetActive(true);
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
        elevDoorClose.SetActive(true);
        elevDoorOpen.SetActive(false);
    }
}
