using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_on_openClose_on_trigger : MonoBehaviour
{
    public Animator openandclose;
    public GameObject doorOpenCroosshair;
    public AudioSource doorSound;
    public AudioSource lockSound;
    
    private bool doorInReach;
    private bool doorHasBeenOpened;
    
    private void Start()
    {
        doorInReach = false;
        doorHasBeenOpened = false;
        doorOpenCroosshair.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("reach"))
        {
            doorInReach = true;
            doorOpenCroosshair.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("reach"))
        {
            doorInReach = false;
            doorOpenCroosshair.SetActive(false);
        }
    }

    private void Update()
    {
        if (doorInReach && !doorHasBeenOpened && Input.GetMouseButtonDown(0))
        {
            doorSound.Play();
            StartCoroutine(OpenDoor());
            doorHasBeenOpened = true;
        }
        else if (doorInReach && openandclose.GetCurrentAnimatorStateInfo(0).IsName("Opening") && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(CloseDoor());
        }
        else if (doorInReach && doorHasBeenOpened && Input.GetMouseButtonDown(0))
        {
            lockSound.Play();
        }
    }

    private IEnumerator OpenDoor()
    {
        openandclose.Play("Opening");
        yield return new WaitForSeconds(0f);
    }

    private IEnumerator CloseDoor()
    {
        openandclose.Play("Closing");
        yield return new WaitForSeconds(0.5f);
        doorSound.Play();
    }
}
