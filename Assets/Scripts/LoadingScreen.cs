using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{

    public Image cooldown;
    public static string sceneToLoad = Scenes.MAIN_MENU; // Default scene is main menu

    void Start()
    {
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        AsyncOperation async = Application.LoadLevelAsync(sceneToLoad);
        while (!async.isDone)
        {
            cooldown.fillAmount = async.progress;
            yield return (0);
        }
        Application.LoadLevel(sceneToLoad);
        //while (loadingPercent < 100)
        //{
        //    yield return new WaitForEndOfFrame();
        //}
        //Application.LoadLevel(Scenes.MAIN_MENU);
    }

    /// <summary>
    /// Loading a scene with loading screen, scene list is stored in Scenes class;
    /// </summary>
    /// <param name="scene">scene name</param>
    public static void Load(string scene)
    {
        if (scene != Scenes.LOADING)
        {
            sceneToLoad = scene;
            Application.LoadLevel(Scenes.LOADING);
        }
        else
        {
            // fail save loading main menu if scene is loading scene
            Load(Scenes.MAIN_MENU);
        }


    }
}