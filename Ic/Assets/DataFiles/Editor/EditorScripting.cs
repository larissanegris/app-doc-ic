using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorScripting : EditorWindow
{

    [MenuItem("Window/Custom/CustomControl")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(EditorScripting));
    }

    private void OnGUI()
    {
        GUILayout.Label( "Settings" );
    }
}
