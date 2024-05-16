using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_E_TimeLimitTrigger : MonoBehaviour
{
    public float timeLimit = 10.0f;
    public GameObject player;
    public GameObject reSWPM;
    public GameObject successTriggerArea;
    public GameObject soundObject;
    //public GameObject nextTriggerArea;

    private bool playerEntered = false;
    private bool timerStarted = false;
    private bool timeExpired = false;

    private void Start()
    {
        playerEntered = false;
        timerStarted = false;
        timeExpired = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = true;
            if (!timerStarted)
            {
                timerStarted = true;
                StartCoroutine(StartTimer());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = false;
        }
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timeLimit);
        if (!playerEntered)
        {
            timeExpired = true;
            if (soundObject != null)
            {
                soundObject.GetComponent<AudioSource>().Play();
            }
            player.transform.position = reSWPM.transform.position;
            successTriggerArea.SetActive(false);
        }
        else
        {
            successTriggerArea.SetActive(false);
            //if (nextTriggerArea != null)
            //{//
               // nextTriggerArea.SetActive(true);
            //}
        }
    }

    public void Reactivate()
    {
        playerEntered = false;
        timerStarted = false;
        timeExpired = false;
        if (soundObject != null && soundObject.GetComponent<AudioSource>().isPlaying)
        {
            soundObject.GetComponent<AudioSource>().Stop();
        }
        successTriggerArea.SetActive(true);
        //if (nextTriggerArea != null)
        //{
            //nextTriggerArea.SetActive(false);
        //}
    }
}