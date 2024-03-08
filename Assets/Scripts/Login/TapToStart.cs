using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;

public class TapToStart : MonoBehaviour {

    public void Tap()
    {
        LoadingScreen.Load(Scenes.MAIN_MENU);
    }

    [Button]
    private void AddGem(int amount)
    {
        Attributes.AddGem(amount);
    }
    
    [Button]
    private void AddGold(int amount)
    {
        Attributes.AddGold(amount);
    }
}
