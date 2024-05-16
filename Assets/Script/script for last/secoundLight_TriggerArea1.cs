using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class secoundLight_TriggerArea1 : MonoBehaviour
{
    public Light lightToTurnOn;
    public float delay = 1.0f;
    public GameObject audioObjectOn;
    public GameObject audioObjectFail;
    public GameObject timeTriggerObject;
    private bool playerEntered = false;
    private bool lightTurnedOn = false;
    private bool hasFailed = false;
    private float timeLeft;

    private void Start()
    {
        lightToTurnOn.enabled = false;
        //timeLeft = timeTriggerObject.GetComponent<timeTrigger>().time;
    }

    private void Update()
    {
        if (playerEntered && !lightTurnedOn)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0f)
            {
                FailLevel();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !lightTurnedOn)
        {
            playerEntered = true;
            //timeLeft = timeTriggerObject.GetComponent<timeTrigger>().time;
            Invoke("TurnOnLight", delay);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = false;
            CancelInvoke("TurnOnLight");
            TurnOffLight();
        }
    }

    private void TurnOnLight()
    {
        if (playerEntered && !lightTurnedOn)
        {
            lightToTurnOn.enabled = true;
            lightTurnedOn = true;
            if (audioObjectOn != null)
            {
                audioObjectOn.GetComponent<AudioSource>().Play();
            }
        }
    }

    private void FailLevel()
    {
        if (!hasFailed)
        {
            hasFailed = true;
            if (audioObjectFail != null)
            {
                audioObjectFail.GetComponent<AudioSource>().Play();
            }
            Invoke("ReloadLevel", audioObjectFail.GetComponent<AudioSource>().clip.length);
        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void TurnOffLight()
    {
        lightToTurnOn.enabled = false;
    }
}
