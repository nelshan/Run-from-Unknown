using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject MainMenu;
    public Slider loadingSlider;

    public void LoadLevelButton(string LeveltoLoad)
    {
        MainMenu.SetActive(false);
        LoadingScreen.SetActive(true);

        StartCoroutine(LoadLevelafterLoading(LeveltoLoad));
    }

    IEnumerator LoadLevelafterLoading(string LeveltoLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(LeveltoLoad);

        while(!loadOperation.isDone)
        {
            float progrssValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = progrssValue;
            yield return null;
        }
    }
}
