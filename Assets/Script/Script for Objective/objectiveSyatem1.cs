using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectiveSyatem1 : MonoBehaviour
{
    public GameObject ObjectiveTrigger;
    public GameObject ObjectText;

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
            StartCoroutine(missionOnjective());  
    }

    private IEnumerator missionOnjective()
    {
        ObjectText.GetComponent<Text>().text = "Follow The Light";
        yield return new WaitForSeconds(4f);
        ObjectText.GetComponent<Text>().text = "";
        ObjectiveTrigger.SetActive(false);
    }
}
