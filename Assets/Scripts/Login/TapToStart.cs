using UnityEngine;
using System.Collections;

public class TapToStart : MonoBehaviour {

    public void Tap()
    {
        LoadingScreen.Load(Scenes.MAIN_MENU);
    }
}
