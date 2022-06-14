using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor( typeof( CollisionManager ) )]
public class CollisionManagerEditor : Editor
{
    bool showAdjMatrix;
    RectOffset rctOff;

    public override void OnInspectorGUI()
    {
        CollisionManager colManager = (CollisionManager) target;

        GUIStyle headFoldout = new GUIStyle( EditorStyles.foldout );
        
        headFoldout.fontSize = 12;
        headFoldout.fontStyle = FontStyle.Bold;
        headFoldout.normal.textColor = Color.white;

        showAdjMatrix = EditorGUILayout.Foldout( showAdjMatrix, "Adjacency Matrix", true, headFoldout );

        if ( showAdjMatrix )
        {
            GUIStyle tableLabelStyle = new GUIStyle();
            tableLabelStyle.fontSize = 12;
            tableLabelStyle.fontStyle = FontStyle.Normal;
            tableLabelStyle.normal.textColor = Color.white;
            tableLabelStyle.alignment = TextAnchor.MiddleCenter;


            EditorGUILayout.BeginVertical();

            if ( colManager.adjacencyMatrix.Count > 0 )
            {
                EditorGUILayout.BeginHorizontal();
                GUI.enabled = false;
                EditorGUILayout.TextField( "Formas", tableLabelStyle );

                for ( int j = 0; j < colManager.adjacencyMatrix.Count; j++ )
                {
                    GUI.enabled = false;
                    EditorGUILayout.TextField( j.ToString(), tableLabelStyle );
                }
                EditorGUILayout.EndHorizontal();

                for ( int i = 0; i < colManager.adjacencyMatrix.Count; i++ )
                {

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.TextField( i.ToString(), tableLabelStyle );
                    for ( int j = 0; j < colManager.adjacencyMatrix[i].Count; j++ )
                    {
                        GUI.enabled = false;
                        EditorGUILayout.EnumPopup( colManager.adjacencyMatrix[i][j] );
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }

            EditorGUILayout.EndVertical();

        }


        DrawDefaultInspector();
    }


    
}