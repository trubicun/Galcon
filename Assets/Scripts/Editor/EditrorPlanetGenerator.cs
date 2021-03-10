using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlanetGenerator))]
public class EditrorPlanetGenerator : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        PlanetGenerator generator = (PlanetGenerator)target;
        if (generator.IsAuto) generator.GeneratePlanetsInEditor();
        if (GUILayout.Button("Generate")) generator.GeneratePlanetsInEditor();
    }
}
