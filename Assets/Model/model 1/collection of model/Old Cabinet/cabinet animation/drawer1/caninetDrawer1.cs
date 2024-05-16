using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caninetDrawer1 : MonoBehaviour
{
    public Animator _animator;
    public bool open;
    public GameObject Croosshair;
	public AudioSource drawerSound;
	public bool drawerinReach;
    
    // Start is called before the first frame update
    void Start()
    {
        drawerinReach = false;
        open = false;
        Croosshair.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
			drawerinReach = true;
            Croosshair.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
			drawerinReach = false;
            Croosshair.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (drawerinReach == true && open == false && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(OpenDrawer());
        }
        else if (drawerinReach == true && open == true && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(CloseDrawer());
        }
    }

    private IEnumerator OpenDrawer()
    {
        drawerSound.Play();
        _animator.Play("opencabinetdrawer1");
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    private IEnumerator CloseDrawer()
    {
        drawerSound.Play();
        _animator.Play("closecabinetdrawer1");
        open = false;
        yield return new WaitForSeconds(.5f);
    }
}
