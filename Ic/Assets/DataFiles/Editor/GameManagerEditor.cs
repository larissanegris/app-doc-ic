using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameManager gameManager = (GameManager)target;

        //[Tooltip("Indica se devem aparecer os volumes de interações de cada objeto")]
        gameManager.displayVolume = EditorGUILayout.Toggle( "Display Volume", gameManager.displayVolume );

        DrawDefaultInspector();
    }
}
