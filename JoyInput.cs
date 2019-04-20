/*
 * By Jason Hein
 */


using UnityEngine;

/// <summary>
/// Wrapper class for unity's input system that handles joystick input being different for each platform.
/// If you use the constants and helper functions provided and have the input manager setup properly,
/// the input will be the same regardless of what platform you are building for.
/// When you call any input method, you must specify a player to get input for.
/// 0 gets input from all players, 1-4 will get input from that player.
/// </summary>
public class JoyInput
{
#if UNITY_STANDALONE_WIN || UNITY_XBOXONE || UNITY_WSA
    const string JOY_L_HORIZONTAL = "XJoyL";
    const string JOY_L_VERTICAL = "YJoyL";
    const string JOY_R_HORIZONTAL = "XJoyRWin";
    const string JOY_R_VERTICAL = "YJoyRWin";
    const string JOY_D_HORIZONTAL = "XJoyDWin";
    const string JOY_D_VERTICAL = "YJoyDWin";

    const string JOY_L_TRIGGER = "TriggerLWin";
    const string JOY_R_TRIGGER = "TriggerRWin";

    const KeyCode JOY_BOTTOM_BUTTON = KeyCode.JoystickButton0;
    const KeyCode JOY_RIGHT_BUTTON = KeyCode.JoystickButton1;
    const KeyCode JOY_LEFT_BUTTON = KeyCode.JoystickButton2;
    const KeyCode JOY_TOP_BUTTON = KeyCode.JoystickButton3;

    const KeyCode JOY_LEFT_BUMPER = KeyCode.JoystickButton4;
    const KeyCode JOY_RIGHT_BUMPER = KeyCode.JoystickButton5;

    const KeyCode JOY_SELECT = KeyCode.JoystickButton6;
    const KeyCode JOY_START = KeyCode.JoystickButton7;

    const KeyCode JOY_L_CLICK = KeyCode.JoystickButton8;
    const KeyCode JOY_R_CLICK = KeyCode.JoystickButton9;
#elif UNITY_STANDALONE_OSX
    const string JOY_L_HORIZONTAL = "XJoyL";
    const string JOY_L_VERTICAL = "YJoyL";
    const string JOY_R_HORIZONTAL = "XJoyRMac";
    const string JOY_R_VERTICAL = "YJoyRMac";

    const string JOY_L_TRIGGER = "TriggerLMac";
    const string JOY_R_TRIGGER = "TriggerRMac";

    const KeyCode JOY_BOTTOM_BUTTON = KeyCode.JoystickButton16;
    const KeyCode JOY_RIGHT_BUTTON = KeyCode.JoystickButton17;
    const KeyCode JOY_LEFT_BUTTON = KeyCode.JoystickButton18;
    const KeyCode JOY_TOP_BUTTON = KeyCode.JoystickButton19;

    const KeyCode JOY_LEFT_BUMPER = KeyCode.JoystickButton13;
    const KeyCode JOY_RIGHT_BUMPER = KeyCode.JoystickButton14;

    const KeyCode JOY_SELECT = KeyCode.JoystickButton10;
    const KeyCode JOY_START = KeyCode.JoystickButton9;

    const KeyCode JOY_L_CLICK = KeyCode.JoystickButton11;
    const KeyCode JOY_R_CLICK = KeyCode.JoystickButton12;
#elif UNITY_STANDALONE_LINUX
    const string JOY_L_HORIZONTAL = "XJoyL";
    const string JOY_L_VERTICAL = "YJoyL";
    const string JOY_R_HORIZONTAL = "XJoyRWin";
    const string JOY_R_VERTICAL = "YJoyRWin";
    const string JOY_D_HORIZONTAL = "XJoyDLin";
    const string JOY_D_VERTICAL = "YJoyDLin";

    const string JOY_L_TRIGGER = "TriggerLLin";
    const string JOY_R_TRIGGER = "TriggerRLin";

    const KeyCode JOY_BOTTOM_BUTTON = KeyCode.JoystickButton0;
    const KeyCode JOY_RIGHT_BUTTON = KeyCode.JoystickButton1;
    const KeyCode JOY_LEFT_BUTTON = KeyCode.JoystickButton2;
    const KeyCode JOY_TOP_BUTTON = KeyCode.JoystickButton3;

    const KeyCode JOY_LEFT_BUMPER = KeyCode.JoystickButton4;
    const KeyCode JOY_RIGHT_BUMPER = KeyCode.JoystickButton5;

    const KeyCode JOY_SELECT = KeyCode.JoystickButton6;
    const KeyCode JOY_START = KeyCode.JoystickButton7;

    const KeyCode JOY_L_CLICK = KeyCode.JoystickButton9;
    const KeyCode JOY_R_CLICK = KeyCode.JoystickButton10;
#endif


    // COMMON JOYSTICK AXIS - PC AND CONSOLE

#if !UNITY_ANDROID

    /// <summary>
    /// Left thumbstick input normalized.
    /// </summary>
    public static Vector2 LeftThumbstick(ushort player)
    {
        string playerStr = player.ToString();
        return new Vector2( Input.GetAxisRaw(JOY_L_HORIZONTAL + playerStr),
                            Input.GetAxisRaw(JOY_L_VERTICAL + playerStr));
    }

    /// <summary>
    /// Right thumbstick input normalized.
    /// </summary>
    public static Vector2 RightThumbstick(ushort player)
    {
        string playerStr = player.ToString();
        return new Vector2( Input.GetAxisRaw(JOY_R_HORIZONTAL + playerStr),
                            Input.GetAxisRaw(JOY_R_VERTICAL + playerStr));
    }

#endif

#if UNITY_STANDALONE_WIN || UNITY_XBOXONE || UNITY_WSA || UNITY_STANDALONE_LINUX

    /// <summary>
    /// D-PAD input normalized.
    /// Mac does not support the D-pad, and Linux only supports it for wired controllers.
    /// </summary>
    public static Vector2 DPad(ushort player)
    {
        string playerStr = player.ToString();
        return new Vector2( Input.GetAxisRaw(JOY_D_HORIZONTAL + playerStr),
                            Input.GetAxisRaw(JOY_D_VERTICAL + playerStr));
    }

    public static float DPadX(ushort player)
    {
        return Input.GetAxisRaw(JOY_D_HORIZONTAL + player.ToString());
    }

    public static float DPadY(ushort player)
    {
        return Input.GetAxisRaw(JOY_D_VERTICAL + player.ToString());
    }

#endif


    // JOYSTICK TRIGGER INPUT

#if UNITY_STANDALONE_WIN || UNITY_XBOXONE || UNITY_WSA || UNITY_STANDALONE_LINUX

    /// <summary>
    /// Left trigger input (0 to 1).
    /// </summary>
    public static float LeftTrigger(ushort player)
    {
        return Input.GetAxisRaw(JOY_L_TRIGGER + player.ToString());
    }

    /// <summary>
    /// Right trigger input (0 to 1).
    /// </summary>
    public static float RightTrigger(ushort player)
    {
        return Input.GetAxisRaw(JOY_R_TRIGGER + player.ToString());
    }

    // Trigger input is initially different on Mac
#elif UNITY_STANDALONE_OSX

    /// <summary>
    /// Left trigger input (0 to 1).
    /// </summary>
    public static float LeftTrigger()
    {
        return (Input.GetAxisRaw(JOY_L_TRIGGER) + 1f) / 2f;
    }

    /// <summary>
    /// Right trigger input (0 to 1).
    /// </summary>
    public static float RightTrigger()
    {
        return (Input.GetAxisRaw(JOY_R_TRIGGER) + 1f) / 2f;
    }

#endif

    // JOYSTICK BUTTON INPUT

#if !UNITY_ANDROID

    const ushort BUTTON_COUNT = 20;
    static KeyCode getButton (KeyCode button, ushort player)
    {
        return (KeyCode)((ushort)(button) + player * BUTTON_COUNT);
    }

    public static bool BottomButton (ushort player)
    {
        return Input.GetKey(getButton(JOY_BOTTOM_BUTTON, player));
    }

    public static bool BottomButtonUp(ushort player)
    {
        return Input.GetKeyUp(getButton(JOY_BOTTOM_BUTTON, player));
    }

    public static bool BottomButtonDown(ushort player)
    {
        return Input.GetKeyDown(getButton(JOY_BOTTOM_BUTTON, player));
    }

    public static bool RightButton(ushort player)
    {
        return Input.GetKey(getButton(JOY_RIGHT_BUTTON, player));
    }

    public static bool RightButtonUp(ushort player)
    {
        return Input.GetKeyUp(getButton(JOY_RIGHT_BUTTON, player));
    }

    public static bool RightButtonDown(ushort player)
    {
        return Input.GetKeyDown(getButton(JOY_RIGHT_BUTTON, player));
    }

    public static bool LeftButton(ushort player)
    {
        return Input.GetKey(getButton(JOY_LEFT_BUTTON, player));
    }

    public static bool LeftButtonUp(ushort player)
    {
        return Input.GetKeyUp(getButton(JOY_LEFT_BUTTON, player));
    }

    public static bool LeftButtonDown(ushort player)
    {
        return Input.GetKeyDown(getButton(JOY_LEFT_BUTTON, player));
    }

    public static bool TopButton(ushort player)
    {
        return Input.GetKey(getButton(JOY_TOP_BUTTON, player));
    }

    public static bool TopButtonUp(ushort player)
    {
        return Input.GetKeyUp(getButton(JOY_TOP_BUTTON, player));
    }

    public static bool TopButtonDown(ushort player)
    {
        return Input.GetKeyDown(getButton(JOY_TOP_BUTTON, player));
    }

    public static bool LeftBumper(ushort player)
    {
        return Input.GetKey(getButton(JOY_LEFT_BUMPER, player));
    }

    public static bool LeftBumperUp(ushort player)
    {
        return Input.GetKeyUp(getButton(JOY_LEFT_BUMPER, player));
    }

    public static bool LeftBumperDown(ushort player)
    {
        return Input.GetKeyDown(getButton(JOY_LEFT_BUMPER, player));
    }

    public static bool RightBumper(ushort player)
    {
        return Input.GetKey(getButton(JOY_RIGHT_BUMPER, player));
    }

    public static bool RightBumperUp(ushort player)
    {
        return Input.GetKeyUp(getButton(JOY_RIGHT_BUMPER, player));
    }

    public static bool RightBumperDown(ushort player)
    {
        return Input.GetKeyDown(getButton(JOY_RIGHT_BUMPER, player));
    }

    public static bool Select(ushort player)
    {
        return Input.GetKey(getButton(JOY_SELECT, player));
    }

    public static bool SelectUp(ushort player)
    {
        return Input.GetKeyUp(getButton(JOY_SELECT, player));
    }

    public static bool SelectDown(ushort player)
    {
        return Input.GetKeyDown(getButton(JOY_SELECT, player));
    }

    public static bool Start(ushort player)
    {
        return Input.GetKey(getButton(JOY_START, player));
    }

    public static bool StartUp(ushort player)
    {
        return Input.GetKeyUp(getButton(JOY_START, player));
    }

    public static bool StartDown(ushort player)
    {
        return Input.GetKeyDown(getButton(JOY_START, player));
    }

    public static bool LeftThumbstickClick(ushort player)
    {
        return Input.GetKey(getButton(JOY_L_CLICK, player));
    }

    public static bool LeftThumbstickClickUp(ushort player)
    {
        return Input.GetKeyUp(getButton(JOY_L_CLICK, player));
    }

    public static bool LeftThumbstickClickDown(ushort player)
    {
        return Input.GetKeyDown(getButton(JOY_L_CLICK, player));
    }

    public static bool RightThumbstickClick(ushort player)
    {
        return Input.GetKey(getButton(JOY_R_CLICK, player));
    }

    public static bool RightThumbstickClickUp(ushort player)
    {
        return Input.GetKeyUp(getButton(JOY_R_CLICK, player));
    }

    public static bool RightThumbstickClickDown(ushort player)
    {
        return Input.GetKeyDown(getButton(JOY_R_CLICK, player));
    }
#endif
}
