/*
 * By Jason Hein
 */



using UnityEngine;

public class MouseInput : MonoBehaviour
{
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX

    const string MOUSE_WHEEL = "MouseWheel";
    const string MOUSE_X = "MouseX";
    const string MOUSE_Y = "MouseY";

    /// <summary>
    /// Mouse movement input.
    /// </summary>
    public static Vector2 Mouse()
    {
        return new Vector2(Input.GetAxisRaw(MOUSE_X), Input.GetAxisRaw(MOUSE_Y));
    }

    /// <summary>
    /// Mouse X movement input.
    /// </summary>
    public static float MouseX()
    {
        return Input.GetAxisRaw(MOUSE_X);
    }

    /// <summary>
    /// Mouse Y movement input.
    /// </summary>
    public static float MouseY()
    {
        return Input.GetAxisRaw(MOUSE_Y);
    }

    /// <summary>
    /// Mouse wheel input.
    /// </summary>
    public static float MouseWheel()
    {
        return Input.GetAxisRaw(MOUSE_WHEEL);
    }
#endif
}
