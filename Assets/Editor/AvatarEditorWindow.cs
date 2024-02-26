using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarEditorWindow : EditorWindow {

	public static AvatarEditorWindow instance;

	public static List<Avatar> mData;
	private Vector2 scroll;

	static AvatarEditorWindow(){
		mData = AvatarEditor.GetData ();
		if (mData == null) {
			mData = new List<Avatar>();
		}
	}

	public static void OpenWindow(){
		instance = (AvatarEditorWindow)EditorWindow.GetWindow (typeof(AvatarEditorWindow));
		//instance.title = "Avatar Editor";
	}

	void OnGUI(){
		EditorGUILayout.BeginVertical ("box");
		EditorGUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Insert New")) {
			mData.Add(new Avatar());
		}

		if (GUILayout.Button ("Remove All")) {

		}

		if (GUILayout.Button ("Save")) {
			Save();
		}

		if (GUILayout.Button ("Backup")) {
			Save();
		}

		if (GUILayout.Button("Load Backup"))
		{
			Load();
		}

		EditorGUILayout.EndHorizontal();
		EditorGUILayout.EndVertical();
		GUILayout.Label("Avatar List:", EditorStyles.boldLabel);

		scroll = GUILayout.BeginScrollView(scroll);
		for (int i = 0; i < mData.Count; i++) {

			EditorGUILayout.BeginVertical("box");

			EditorGUILayout.BeginHorizontal();
			mData[i].name = EditorGUILayout.TextField("Name", mData[i].name);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.Separator();
			GUILayout.Label("Description: ");
			mData[i].description = EditorGUILayout.TextArea(mData[i].description);
			EditorGUILayout.Separator();

			EditorGUILayout.BeginHorizontal();
			//mData[i].activeMoney = EditorGUILayout.TextField("Active Money: ", mData[i].activeMoney);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			mData[i].gold = EditorGUILayout.IntField("Gold: ", mData[i].gold);
			mData[i].gem = EditorGUILayout.IntField("Gem: ", mData[i].gem);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			mData[i].id = i + 1;
			GUILayout.Label("Avatar: " + mData[i].id, EditorStyles.boldLabel);

			if(GUILayout.Button("Insert Above"))
				mData.Insert(i, new Avatar());
			if(GUILayout.Button("Insert"))
				mData.Insert(i + 1, new Avatar());
			if(GUILayout.Button("Remove"))
				mData.Remove(mData[i]);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.EndVertical();
		}
		GUILayout.EndScrollView();
	}

	void Save(){
		AvatarEditor.Save ();
	}

	void Load(){
		AvatarEditor.GetData ();
	}
}
