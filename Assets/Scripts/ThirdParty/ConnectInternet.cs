using UnityEngine;
using System.Collections;
using System.Net;

public class ConnectInternet : MonoBehaviour
{

    public static ConnectInternet instance;

    void Awake()
    {
        instance = this;
    }

    public static bool IsInternetConnection()
    {
        return Application.internetReachability != NetworkReachability.NotReachable;
    }
}
