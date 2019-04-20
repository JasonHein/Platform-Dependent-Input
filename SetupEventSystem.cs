/*
 * By Jason Hein
 */


using UnityEngine;

#if UNITY_STANDALONE_OSX
using UnityEngine.EventSystems;
#endif

/// <summary>
/// Sets the values of an event system to read different joystick inputs on a mac.
/// </summary>
public class SetupEventSystem : MonoBehaviour
{
    void Awake ()
    {
        // Horizontal and vertical axis for the event system are the same across platforms
        // By default the buttons will be setup for windows/xbox/wsa and linux.
        // These all use the same confirm and cancel buttons on a joystick.

#if UNITY_STANDALONE_OSX
        EventSystem eventSystem = GetComponent<EventSystem>();
		eventSystem.submitButton = "SubmitMac";
		eventSystem.cancelButton = "CancelMac";
#endif
    }
}
