using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PokeInteractionManager))]
public class PokeInteractionManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();

        // Reference to the DebugButton script
        PokeInteractionManager debugButton = (PokeInteractionManager)target;

        // Add a button to the inspector
        if (GUILayout.Button("Debug"))
        {
            // Invoke the event when the button is pressed
            debugButton.DebugButton();
        }
    }
}
