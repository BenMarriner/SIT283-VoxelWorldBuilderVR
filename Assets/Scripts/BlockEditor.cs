using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;

[CustomEditor(typeof(BlockComponent))]
public class BlockEditor : Editor
{
    BlockComponent component;

    private void OnSceneGUI()
    {
        component = target as BlockComponent;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if (GUILayout.Button("Reset"))
        {
            //component.Regenerate();
        }
    }
}