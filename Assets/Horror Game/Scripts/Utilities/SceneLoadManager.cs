using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private GameObject loadingCanvas;

    [SerializeField] private Slider loadingBar;

    private float progressValue = 0f;

    public void LoadSceneAsync(int sceneIndex) 
    {
        loadingCanvas.SetActive(true);
        StartCoroutine(LoadLeveAsync(sceneIndex));
    }

    IEnumerator LoadLeveAsync(int sceneIndex)
    {

        yield return new WaitForSeconds(2);
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!loadOperation.isDone && loadingBar.value != loadingBar.maxValue)
        {
            progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingBar.value = progressValue;   
            yield return null;
        }
    }
}
