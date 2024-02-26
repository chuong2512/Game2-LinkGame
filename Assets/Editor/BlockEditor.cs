using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class BlockEditor : Editor {
	/*
	public static string dataFilePath = Path.Combine(Path.Combine(Path.Combine(Application.dataPath, "Resources"), "Data"), "Block.xml");
	
	[MenuItem("Tools/Block Editor/Open Editor Window")]
	static void ShowEditorWindow(){
		BlockEditorWindow.OpenWindow ();
	}
	
	[MenuItem("Tools/Block Editor/Save")]
	public static void Save(){
		XmlSerializer xml = new XmlSerializer (typeof(List<Block>));
		
		FileStream fs = new FileStream (dataFilePath, FileMode.Create);
		//StreamReader sr = new StreamReader (fs);
		StreamWriter sw = new StreamWriter (fs, Encoding.UTF8);
		xml.Serialize (sw, BlockEditorWindow.mData);
		fs.Close ();
	}
	
	public static List<Block> GetData(){
		List<Block> data = new List<Block> ();
		TextAsset file = Resources.Load ("Data/Block") as TextAsset;
		XmlSerializer xml = new XmlSerializer (typeof(List<Block>));
		StringReader textData = new StringReader (file.text);
		data = xml.Deserialize (textData) as List<Block>;
		textData.Close ();
		return data;
	}
	*/
}
