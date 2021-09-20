using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public GameObject settings;
    private int defaultQuality;
    public void Play(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/0.9f);
            slider.value = progress;

            yield return null;
        }
    }

    public void SetQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
        defaultQuality = QualityIndex;
    }
    public void Back()
    {
        settings.SetActive(false);

    }
    public void settingButton()
    {
        settings.SetActive(true);

    }
}
