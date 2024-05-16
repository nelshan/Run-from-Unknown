using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectInteractDialogue : MonoBehaviour
{
    public Text texts;
    public string description;
    public bool objectInReach;
    public GameObject interactText;


    // Start is called before the first frame update
    void Start()
    {
        texts.GetComponent<Text>().enabled = false;
        interactText.SetActive(false);
        objectInReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
            objectInReach = true;
            interactText.SetActive(true);
            texts.GetComponent<Text>().enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
            objectInReach = false;
            interactText.SetActive(false);
            texts.GetComponent<Text>().enabled = false;
            texts.GetComponent<Text>().text = "";
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && objectInReach)
        {
            texts.text = description.ToString();
            interactText.SetActive(false);
        }   
    }
}
