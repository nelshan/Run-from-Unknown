using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_openClose_T_L_sound_T : MonoBehaviour
{
    public Animator openandclose;
    public bool open;
    public GameObject doorOpenCroosshair;
    public AudioSource OpendoorSound;
    public AudioSource ClosedoorSound;
    public bool DoorinReach;



    void Start()
    {
		DoorinReach = false;
        open = false;
        doorOpenCroosshair.SetActive(false);
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
			DoorinReach = true;
            doorOpenCroosshair.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
			DoorinReach = false;
            doorOpenCroosshair.SetActive(false);
        }
    }

    void Update()
    {
        if (DoorinReach == true && open == false && Input.GetMouseButtonDown(0))
        {
            OpendoorSound.Play();
            StartCoroutine(OpenDoor());
        }
        else if (DoorinReach == true && open == true && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(CloseDoor());
        }
    }

    private IEnumerator OpenDoor()
    {
        openandclose.Play("DoorOpen");
        open = true;
        yield return new WaitForSeconds(0f);
    }

    private IEnumerator CloseDoor()
    {
        openandclose.Play("DoorClose");
        open = false;
        yield return new WaitForSeconds(.5f);
		ClosedoorSound.Play();
    }
}
