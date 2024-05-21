using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DebugButton))]
public class DebugButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();

        // Reference to the DebugButton script
        DebugButton debugButton = (DebugButton)target;

        // Add a button to the inspector
        if (GUILayout.Button("Debug"))
        {
            // Invoke the event when the button is pressed
            debugButton.InvokeButtonEvent();
        }
    }
}
