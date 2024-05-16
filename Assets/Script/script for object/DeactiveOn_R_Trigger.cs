using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveOn_R_Trigger : MonoBehaviour
{
    public GameObject objectToDeactivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "reach")
        {
            objectToDeactivate.SetActive(false);
        }
    }
}
