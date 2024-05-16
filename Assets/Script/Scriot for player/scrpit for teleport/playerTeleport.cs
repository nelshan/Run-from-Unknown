using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTeleport : MonoBehaviour
{
    public Transform teleportTatget;
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = teleportTatget.transform.position;   
        }    
    }
}
