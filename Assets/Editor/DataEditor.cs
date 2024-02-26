using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class LevelEditor : Editor
{
    public static string levelPath = Path.Combine(Path.Combine(Application.dataPath, "Resources"), "Level");

    public static string mapFile;
    


    [MenuItem("Data Editor/Create Data %#C")]
    public static void CreateMap()
    {
        CreateDataWindow.OpenWindow();
    }

    [MenuItem("Data Editor/Convert Data %#D")]
    public static void ConvertData()
    {
    }
}
