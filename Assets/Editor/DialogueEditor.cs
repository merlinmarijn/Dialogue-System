using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


[CustomEditor(typeof(Dialogue))]
[CanEditMultipleObjects]
public class DialogueEditor : Editor
{

    //Dialogue dialogue;
    public override void OnInspectorGUI()
    {
        Dialogue dialogue = (Dialogue)target;

        EditorGUILayout.LabelField("Dialogue Text");
        dialogue.DialogueText = EditorGUILayout.TextField(dialogue.DialogueText, GUILayout.Width(300), GUILayout.Height(100));
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Dialogue Option 1");
        EditorGUILayout.BeginHorizontal();
        dialogue.Option1 = EditorGUILayout.TextField("", dialogue.Option1);
        dialogue.Option1Object = EditorGUILayout.ObjectField("", dialogue.Option1Object, typeof(Dialogue), true) as Dialogue;
        EditorGUILayout.EndHorizontal();
        if (GUILayout.Button("Create Dialogue")&& dialogue.Option1Object == null)
        {
            dialogue.Option1Object = dialogue.Option1Object = CreateDialogue();
        }
        EditorGUILayout.LabelField("Dialogue Option 2");
        EditorGUILayout.BeginHorizontal();
        dialogue.Option2 = EditorGUILayout.TextField("", dialogue.Option2);
        dialogue.Option2Object = EditorGUILayout.ObjectField("", dialogue.Option2Object, typeof(Dialogue), true) as Dialogue;
        EditorGUILayout.EndHorizontal();
        if (GUILayout.Button("Create Dialogue")&& dialogue.Option2Object == null)
        {
            dialogue.Option2Object = dialogue.Option2Object = CreateDialogue();
        }
        EditorGUILayout.LabelField("Dialogue Option 3");
        EditorGUILayout.BeginHorizontal();
        dialogue.Option3 = EditorGUILayout.TextField("", dialogue.Option3);
        dialogue.Option3Object = EditorGUILayout.ObjectField("", dialogue.Option3Object, typeof(Dialogue), true) as Dialogue;
        EditorGUILayout.EndHorizontal();
        if (GUILayout.Button("Create Dialogue")&& dialogue.Option3Object == null)
        {
            dialogue.Option3Object = dialogue.Option3Object = CreateDialogue();
        }
    }


    Dialogue CreateDialogue()
    {

        //instantiate scriptable object
        Dialogue asset = ScriptableObject.CreateInstance<Dialogue>();

        //get current file location and info about .asset #
        string AssetFolderPath = Application.dataPath;
        string DialogueFolderPath = AssetFolderPath + "/ScriptableObjects/Dialogue_Sequence_1";
        DirectoryInfo dir = new DirectoryInfo(DialogueFolderPath);
        FileInfo[] info = dir.GetFiles("*.asset");
        //Debug.Log(info.Length);

        //create asset and save it
        AssetDatabase.CreateAsset(asset, "Assets/ScriptableObjects/Dialogue_Sequence_1/" + (info.Length + 1) + "_" + "Dialogue" + ".asset");
        AssetDatabase.SaveAssets();
        //Selection.activeObject = asset;
        return asset;
    }

}
