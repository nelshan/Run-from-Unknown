using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushMenu : MonoBehaviour
{
    public GameObject GamePaused;
    public static bool isPaused = false;
    public GameObject playerObject; // assign to player game object in the inspector

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Escape))
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(isPaused)
            {
                Resumed();
            }
            else
            {
                Paused();
            }
        }
    }

    public void Paused()
    {
        // Disable player movement script while game is paused
        playerObject.GetComponent<footsound>().enabled = false;
        playerObject.GetComponent<FirstPersonController>().enabled = false;
        
        // Show cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Show pause menu
        GamePaused.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resumed()
    {
        // Enable player movement script when Resumed
        playerObject.GetComponent<footsound>().enabled = true;
        playerObject.GetComponent<FirstPersonController>().enabled = true;

        // Hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Hide pause menu
        GamePaused.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void LoadMainMenu()
    {    
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("game exited");
    }
}
