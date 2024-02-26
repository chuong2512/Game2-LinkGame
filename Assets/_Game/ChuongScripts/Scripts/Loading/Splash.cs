using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    public string sceneToLoad;

    //public TextMeshProUGUI _loadingTMP;

    public void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        StartCoroutine(StartLoad());
    }

    IEnumerator StartLoad()
    {
        yield return StartCoroutine(FadeLoadingScreen(2));
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!operation.isDone)
        {
            yield return null;
        }
    }

    IEnumerator FadeLoadingScreen(float duration)
    {
        float time = 0;

        var dot = 0;
        var dotString = ".";

        while (time < duration)
        {
            dot++;
            switch (dot % 3)
            {
                case 0:
                    dotString = ".";
                    break;
                case 1:
                    dotString = "..";
                    break;
                case 2:
                    dotString = "...";
                    break;
            }

            time += Time.deltaTime;
            // _loadingTMP.SetText($"Loading{dotString}");
            yield return null;
        }
    }
}