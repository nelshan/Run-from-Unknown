using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickkey : MonoBehaviour
{
    public GameObject keyOB;
    public GameObject invOB;
    public GameObject doorOpenCroosshair;
    public AudioSource keySound;

    public bool inReach;


    void Start()
    {
        inReach = false;
        doorOpenCroosshair.SetActive(false);
        invOB.SetActive(false);
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
        if (inReach && Input.GetMouseButtonDown(0))
        {
            keyOB.SetActive(false);
            keySound.Play();
            invOB.SetActive(true);
            doorOpenCroosshair.SetActive(false);
        }

        
    }
}
