using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine.UI;
using Facebook.MiniJSON;

public class FacebookController : MonoBehaviour
{
    public static FacebookController instance;

    System.Action onInitCallback;
    System.Action onLoginCallback;

	public List<object> scoreList = null;

    void Awake()
    {
        instance = this;
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
    }

    public void Login(System.Action callback = null)
    {
        var perms = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogInWithReadPermissions(perms, AuthCallback);
        onLoginCallback = callback;
    }

    public void PostScore(int score)
    {
        var scoreData = new Dictionary<string, string>() { { "score", score.ToString() } };
        FB.API("/me/scores", HttpMethod.POST, HandleResult, scoreData);
    }
	//---------------------------




	//-----------------------------------------
    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }

    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            if (onLoginCallback != null) onLoginCallback();
        }
        else
        {
            Debug.Log("User cancelled login");
        }
    }

    protected void HandleResult(IResult result)
    {
        if (result == null)
        {
            return;
        }
        Debug.Log("FACEBOOK: " + result.ToString());
    }

	public bool IsLoggedIn(){
		return FB.IsLoggedIn;
	}

}
