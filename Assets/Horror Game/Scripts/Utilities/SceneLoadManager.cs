using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadManager : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingBar;
    [SerializeField] private float loadingTimeDelay = 2.0f;

    private float progressValue = 0f;

    public void LoadSceneAsync(int sceneIndex) 
    {
        // Enable loading screen
        loadingScreen.SetActive(true);

        StartCoroutine(LoadLevelAsync(sceneIndex));
    }

    IEnumerator LoadLevelAsync(int sceneIndex)
    {
        // Delay the loading process
        // Give time for players to see the loading screen
        yield return new WaitForSeconds(loadingTimeDelay);

        // Measure the loading of a new scene
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!loadOperation.isDone && loadingBar.value != loadingBar.maxValue)
        {
            // Convert the progress to a value between 0 and 1
            progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            // Apply progress
            loadingBar.value = progressValue;   
            yield return null;
        }
    }
}
