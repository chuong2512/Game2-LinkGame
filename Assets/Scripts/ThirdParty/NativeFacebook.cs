using UnityEngine;
using System.Collections;
using System.IO;
public class NativeFacebook : MonoBehaviour
{
#if UNITY_ANDROID
    AndroidJavaObject contextActivity;
    AndroidJavaObject pluginObject;
#endif

    string imageData = "";

    // Use this for initialization
    void Start()
    {
        Init();
    }

    void Init()
    {
		#if UNITY_ANDROID && !UNITY_EDITOR
        Debug.Log("FB: init");
        if (contextActivity == null)
        {
            using (var actClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                contextActivity = actClass.GetStatic<AndroidJavaObject>("currentActivity");
                Debug.Log("FB: init");
            }

            using (var pluginClass = new AndroidJavaClass("vn.brine.facebookunity.UnityController"))
            {
                if (pluginClass != null)
                {
                    pluginObject = pluginClass.CallStatic<AndroidJavaObject>("getInstance");
                    pluginObject.Call("setActivity", contextActivity);
                    Debug.Log("FB: init");
                }
            }
        }
		#endif
    }

    public void TakeScreenshot()
    {
        StartCoroutine(TakeScreenshotCoroutine());
    }

    private IEnumerator TakeScreenshotCoroutine()
    {
        yield return new WaitForEndOfFrame();

        var width = Screen.width;
        var height = Screen.height;
        var tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        byte[] screenshot = tex.EncodeToPNG();
        imageData = System.Convert.ToBase64String(screenshot);
		#if UNITY_ANDROID && !UNITY_EDITOR
		pluginObject.Call("shareImage", imageData);
		#endif
    }

    public void ShareScreenshot()
    {
        StartCoroutine(TakeAndShareScreenshot());
    }

    string mensaje = "New Score with FarmLink :D";
    public IEnumerator TakeAndShareScreenshot()
    {

        // wait for graphics to render
        yield return new WaitForEndOfFrame();
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
        // create the texture
        print(1);
        Texture2D screenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        // put buffer into texture
        screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0);
        // apply
        screenTexture.Apply();
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
        byte[] dataToSave = screenTexture.EncodeToPNG();
        string destination = Path.Combine(Application.persistentDataPath, System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");
        File.WriteAllBytes(destination, dataToSave);
        //txt.text = Application.persistentDataPath;
        if (!Application.isEditor)
        {
            // block to open the file and share it ------------START
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);

            intentObject.Call<AndroidJavaObject>("setType", "text/plain");
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "" + mensaje);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "SUBJECT");

            intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

            currentActivity.Call("startActivity", intentObject);
        }
    }
 }
