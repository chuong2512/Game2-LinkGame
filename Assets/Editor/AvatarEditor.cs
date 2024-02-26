using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class AvatarEditor : Editor {

	public static string dataFilePath = Path.Combine(Path.Combine(Path.Combine(Application.dataPath, "Resources"), "Data"), "Avatar.xml");

	[MenuItem("Tools/Avatar Editor/Open Editor Window #%E")]
	static void ShowEditorWindow(){
		AvatarEditorWindow.OpenWindow ();
	}

	[MenuItem("Tools/Avatar Editor/Save")]
	public static void Save(){
		XmlSerializer xml = new XmlSerializer (typeof(List<Avatar>));

		FileStream fs = new FileStream (dataFilePath, FileMode.Create);
		//StreamReader sr = new StreamReader (fs);
		StreamWriter sw = new StreamWriter (fs, Encoding.UTF8);
		xml.Serialize (sw, AvatarEditorWindow.mData);
		fs.Close ();

        Avatars avatars = new Avatars();
        avatars.avatars = AvatarEditorWindow.mData.ToArray();


        AssetDatabase.CreateAsset(avatars, "Assets/Resources/avatars.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

    }

	public static List<Avatar> GetData(){
		List<Avatar> data = new List<Avatar> ();
		TextAsset file = Resources.Load ("Data/Avatar") as TextAsset;
		XmlSerializer xml = new XmlSerializer (typeof(List<Avatar>));
		StringReader textData = new StringReader (file.text);
		data = xml.Deserialize (textData) as List<Avatar>;
		textData.Close ();
		return data;
	}
}
