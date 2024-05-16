using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tolevel : MonoBehaviour
{
    [SerializeField] public string Level;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
       
    }
}
