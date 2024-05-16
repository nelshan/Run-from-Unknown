using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawer : MonoBehaviour
{
    public Animator draweranimation;

    public GameObject opendrawerText;
    public GameObject closeddrawerText;

    public AudioSource opendrawerSound;
    public AudioSource closedrawerSound;

    private bool open;

    private bool drawerinReach;


    void Start()
    {
        opendrawerText.SetActive(false);
        closeddrawerText.SetActive(false);

        draweranimation.SetBool("open", false);
        draweranimation.SetBool("close", false);

        open = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "reach" && !open)
        {
            drawerinReach = true;
            opendrawerText.SetActive(true);
        }

        else if (other.gameObject.tag == "reach" && open)
        {
            drawerinReach = true;
            closeddrawerText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
            drawerinReach = false;
            opendrawerText.SetActive(false);
            closeddrawerText.SetActive(false);
        }
    }



    void Update()
    {
        if (!open && drawerinReach && Input.GetKey(KeyCode.E))
        {
            opendrawerSound.Play();
            draweranimation.SetBool("open", true);
            draweranimation.SetBool("close", false);
            open = true;
            opendrawerText.SetActive(false);
            drawerinReach = false;
        }

        else if (open && drawerinReach && Input.GetKey(KeyCode.E))
        {
            closedrawerSound.Play();
            draweranimation.SetBool("open", false);
            draweranimation.SetBool("close", true);
            open = false;
            closeddrawerText.SetActive(false);
            drawerinReach = false;
        }

    }
}
