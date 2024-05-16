using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notes : MonoBehaviour
{
    public GameObject player,noteUI, pickUpText;
    //public AudioSource pickUpSound;
    public bool noteReached;

    void Start()
    {
        noteUI.SetActive(false);
        pickUpText.SetActive(false);
        noteReached = false;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
            noteReached = true;
            pickUpText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
            noteReached = false;
            pickUpText.SetActive(false);
        }
    }




    void Update()
    {
        if(Input.GetKey(KeyCode.E) && noteReached)
        {
            noteUI.SetActive(true);
            //pickUpSound.Play();
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }


    public void ExitButton()
    {

        noteUI.SetActive(false);
        player.GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = false;
    }
}
