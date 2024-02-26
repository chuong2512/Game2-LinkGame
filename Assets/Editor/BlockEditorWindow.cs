using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEditorWindow : EditorWindow {

	/*
	public static BlockEditorWindow instance;
	
	public static List<Block> mData;
	private Vector2 scroll;
	
	static BlockEditorWindow(){
		mData = BlockEditor.GetData ();
		if (mData == null) {
			mData = new List<Block>();
		}
	}
	
	public static void OpenWindow(){
		instance = (BlockEditorWindow)EditorWindow.GetWindow (typeof(BlockEditorWindow));
	}
	
	void OnGUI(){
		EditorGUILayout.BeginVertical ("box");
		EditorGUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Insert New")) {
			mData.Add(new Block());
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
		GUILayout.Label("Block List:", EditorStyles.boldLabel);
		
		scroll = GUILayout.BeginScrollView(scroll);
		for (int i = 0; i < mData.Count; i++) {
			
			EditorGUILayout.BeginVertical("box");
			
			EditorGUILayout.BeginHorizontal();
			mData[i].name = EditorGUILayout.TextField("Name", mData[i].name);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			mData[i].score = EditorGUILayout.IntField("Score: ", mData[i].score);
			mData[i].condition = EditorGUILayout.TextField("Condition: ", mData[i].condition);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			mData[i].scoreCondition = EditorGUILayout.IntField("Score Condition: ", mData[i].scoreCondition);
			mData[i].percent = EditorGUILayout.FloatField("Percent: ", mData[i].percent);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			mData[i].id = i + 1;
			GUILayout.Label("Block: " + mData[i].id, EditorStyles.boldLabel);
			
			if(GUILayout.Button("Insert Above"))
				mData.Insert(i, new Block());
			if(GUILayout.Button("Insert"))
				mData.Insert(i + 1, new Block());
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
	*/
}
