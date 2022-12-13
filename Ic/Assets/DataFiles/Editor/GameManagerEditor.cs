using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    bool showForms = true;
    bool showCreatedForms = false;
    bool showRelations = true;
    /*
    public override void OnInspectorGUI()
    {
        GameManager gameManager = (GameManager)target;

        GUIStyle headFoldout = new GUIStyle(EditorStyles.foldout);
        headFoldout.fontSize = 12;
        headFoldout.fontStyle = FontStyle.Bold;
        headFoldout.normal.textColor = Color.white;

        GUIStyle bodyField = new GUIStyle();
        bodyField.fontSize = 12;
        bodyField.fontStyle = FontStyle.Normal;
        bodyField.normal.textColor = Color.white;


        gameManager.displayVolume = EditorGUILayout.Toggle("Display Volume", gameManager.displayVolume);
        gameManager.selectMultipleObjects = EditorGUILayout.Toggle("Select Multiple Objects", gameManager.selectMultipleObjects);
        EditorGUILayout.Space();

        showForms = EditorGUILayout.BeginFoldoutHeaderGroup(showForms, "Forms", headFoldout);

        if (showForms)
        {
            EditorGUILayout.ObjectField("Selected Form", gameManager.selectedObject, typeof(GameObject), false);
            EditorGUILayout.IntField("Number of Forms", gameManager.number);
            EditorGUILayout.IntField("Number of Cubes", gameManager.numberCube);
            EditorGUILayout.IntField("Number of Spheres", gameManager.numberSphere);

            EditorGUILayout.BeginHorizontal();
            showCreatedForms = EditorGUILayout.BeginFoldoutHeaderGroup(showCreatedForms, "Created Forms", headFoldout);
            EditorGUILayout.EndFoldoutHeaderGroup();
            EditorGUILayout.IntField(gameManager.createdForms.Count);
            EditorGUILayout.EndHorizontal();

            if (showCreatedForms)
            {
                for (int i = 0; i < gameManager.createdForms.Count; i++)
                {
                    Form form = gameManager.createdForms[i];
                    EditorGUILayout.ObjectField("Form " + form.GetId(), form, typeof(Form), false);
                }
            }
        }

        EditorGUILayout.Space();

        showRelations = EditorGUILayout.Foldout(showRelations, "Relations Info", headFoldout);
        if (showRelations)
        {
            EditorGUILayout.IntField("Interaction Type", gameManager.interactionType);
            EditorGUILayout.IntField("Connection Type", gameManager.connectionType);
            gameManager.cameraObject = (GameObject)EditorGUILayout.ObjectField("Camera", gameManager.cameraObject, typeof(GameObject), true);
            gameManager.moveCamera = EditorGUILayout.Toggle("Move Camera", gameManager.moveCamera);
        }



        //DrawDefaultInspector();
    }
    */
}
