using UnityEngine;
using UnityEditor;
using System.Collections;

public class CreateDataWindow : EditorWindow
{
    private static CreateDataWindow instance;

    private static MonoScript mapObject;
    private static string fileName = "";
    private static string path = "Resources";

    public static void OpenWindow()
    {
        if (instance == null)
            instance = (CreateDataWindow)EditorWindow.GetWindow(typeof(CreateDataWindow));
        instance.Show();
    }

    void OnGUI()
    {
        mapObject = EditorGUILayout.ObjectField("Data:", mapObject, typeof(MonoScript), false) as MonoScript;
        fileName = EditorGUILayout.TextField("File name: ", fileName);
        path = EditorGUILayout.TextField("Path: ", path);

        if (GUILayout.Button("Create"))
        {
            if (mapObject == null)
            {
                Debug.Log("You must choose a class file");
                return;
            }
            if (fileName == "")
            {
                Debug.Log("Asset File Name is blank!");
                return;
            } 
            var asset = ScriptableObject.CreateInstance(mapObject.GetClass());
            if (asset != null)
            {
                string filePath = "Assets/";
                if (path != "")
                {
                    filePath += path + "/";
                }
                filePath += fileName + ".asset";
                Debug.Log(filePath);
                AssetDatabase.CreateAsset(asset, filePath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                instance.Close();
            }
            else
            {
                Debug.LogError("Cannot create asset!!!!!!!");
            }
            //instance.Close();
        }
    }
}
