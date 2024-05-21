using UnityEngine;
using UnityEngine.Events;

public class DebugButton : MonoBehaviour
{
    // Define a public UnityEvent that can be assigned in the inspector
    public UnityEvent OnButtonPressed;

    // Method to invoke the event
    public void InvokeButtonEvent()
    {
        if (OnButtonPressed != null)
        {
            OnButtonPressed.Invoke();
        }
    }
}
