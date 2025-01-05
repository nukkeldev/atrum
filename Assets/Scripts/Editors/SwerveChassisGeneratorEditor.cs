using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SwerveChassisGenerator))]
public class SwerveChassisGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GUILayout.Space(16);

        SwerveChassisGenerator gen = (SwerveChassisGenerator)target;
        if (GUILayout.Button("Build"))
        {
            gen.Build();
        }
    }
}