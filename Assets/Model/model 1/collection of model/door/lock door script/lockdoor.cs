using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockdoor : MonoBehaviour
{
    
    public AudioSource lockSound;
    public GameObject doorOpenCroosshair;
    public bool doorInReach;
     
    void Start()
    {
        doorInReach = false;
        doorOpenCroosshair.SetActive(false);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
            doorInReach = true;
            doorOpenCroosshair.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
            doorInReach = false;
             doorOpenCroosshair.SetActive(false);
        }
    }

    void Update()
    {
        if (doorInReach == true && Input.GetMouseButtonDown(0))
        {
            lockSound.Play();
        }
    }
}
