using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_animatio_on_door : MonoBehaviour
{
    public Animator openandclose;
    //public Animator playerOpenDoorAnimation;
    public bool open;
    public GameObject doorOpenCroosshair;
	public AudioSource doorSound;
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
            doorSound.Play();
            StartCoroutine(OpenDoor());
        }
        else if (DoorinReach == true && open == true && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(CloseDoor());
        }
    }

    private IEnumerator OpenDoor()
    {
        //playerOpenDoorAnimation.Play("Open Door Outwards");
        openandclose.Play("Opening");
        open = true;
        yield return new WaitForSeconds(0f);
    }

    private IEnumerator CloseDoor()
    {
        openandclose.Play("Closing");
        open = false;
        yield return new WaitForSeconds(.5f);
		doorSound.Play();
    }
}
