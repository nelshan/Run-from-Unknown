using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class settingMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    //for controlling the resolution of the window.
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;
    private int currrntRefreshrate;

    void Start() 
    {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currrntRefreshrate = Screen.currentResolution.refreshRate;

        for(int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currrntRefreshrate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i = 0;  i < filteredResolutions.Count; i++)
        {
            string option = filteredResolutions[i].width + " x " + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate + "Hz";
            options.Add(option);

            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resesolutionIndex)
    {
        Resolution resolution = filteredResolutions[resesolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
    ///
    
    //for controlling the main sound of game.
    public void SetVolume (float volum)
    {
        audioMixer.SetFloat("AllSound_VolumMixer", volum);
    }

    //for controlling the main Graphics of the game.
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //for controlling the FUllscreen of the window
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
