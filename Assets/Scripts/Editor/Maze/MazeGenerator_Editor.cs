//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Class MazeGenerator_Editor
/// </summary>
[CustomEditor(typeof(MazeGenerator))]
public class MazeGenerator_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MazeGenerator m_script = (MazeGenerator)target;

        GUILayout.Space(10);

        if (GUILayout.Button("Generate New Random Maze")) m_script.Generate();
    }
}
