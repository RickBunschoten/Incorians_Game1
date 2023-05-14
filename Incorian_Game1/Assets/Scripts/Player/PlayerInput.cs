using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void OnKeyboardInputTimed(KeyCode code, uint time);
    public OnKeyboardInputTimed OnKeyPressing;
    public OnKeyboardInputTimed OnKeyDown;
    public OnKeyboardInputTimed OnKeyUp;

    private Dictionary<KeyCode, uint> TimedKey = new Dictionary<KeyCode, uint>();

    void Update()
    {
        TrackAllKeyStatesForKey(KeyCode.A);
        TrackAllKeyStatesForKey(KeyCode.W);
        TrackAllKeyStatesForKey(KeyCode.S);
        TrackAllKeyStatesForKey(KeyCode.D);
        TrackAllKeyStatesForKey(KeyCode.Space);
    }

    private void TrackAllKeyStatesForKey(KeyCode kc)
    {
        SendKeyDownIfDownStartCount(kc);
        SendKeyPressedIfPressed(kc);
        SendKeyUpIfUpStopCount(kc);
        UpdateCountringTrackerForKeycode(kc);
    }
    private void SendKeyPressedIfPressed(KeyCode kc)
    {
        if (Input.GetKey(kc))
        {
            OnKeyPressing?.Invoke(kc, TimedKey[kc]);
        }
    }
    private void SendKeyDownIfDownStartCount(KeyCode kc)
    {
        if (Input.GetKeyDown(kc))
        {
            StartCountingForTimedKey(kc);
            OnKeyDown?.Invoke(kc, TimedKey[kc]);
        }
    }
    private void SendKeyUpIfUpStopCount(KeyCode kc)
    {
        if (Input.GetKeyUp(kc))
        {
            OnKeyUp?.Invoke(kc, TimedKey[kc]);
            StopCountingForTimedKey(kc);
        }
    }

    private void StartCountingForTimedKey(KeyCode kc)
    {
        if (TimedKey.ContainsKey(kc) == false)
        {
            TimedKey.Add(kc, 0);
        }else
        {
            //TODO: A second key down event where the item wasn't removed?
        }
    }
    private void StopCountingForTimedKey(KeyCode kc)
    {
        if (TimedKey.ContainsKey(kc) == false)
        {
            //TODO: Decide on throw error or not (key up without a key down?)
        }
        else
        {
            TimedKey.Remove(kc);
        }
    }
    private void UpdateCountringTrackerForKeycode(KeyCode kc)
    {
        if (TimedKey.ContainsKey(kc))
        {
            TimedKey[kc] += 1;
        }
    }
}
