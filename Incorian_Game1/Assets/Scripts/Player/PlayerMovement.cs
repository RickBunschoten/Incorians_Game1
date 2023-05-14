using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class PlayerMovement
{ 
    [SerializeField] private AnimationCurve movementMultiplierForward;
    [SerializeField] private AnimationCurve movementMultiplierBackward;
    [SerializeField] private AnimationCurve movementMultiplierLeft;
    [SerializeField] private AnimationCurve movementMultiplierRight;
    [SerializeField] private AnimationCurve movementMultiplierJump;
    [SerializeField] private AnimationCurve movementMultiplierFalling;
    public void MoveForward(Player p, uint PressTimeCount)
    {
        p.transform.Translate(p.transform.forward * movementMultiplierForward.Evaluate(Mathf.Min((PressTimeCount/100), 1)));
    }
    public void MoveBackwards(Player p, uint PressTimeCount)
    {
        p.transform.Translate(-p.transform.forward * movementMultiplierBackward.Evaluate(Mathf.Min((PressTimeCount / 100), 1)));
    }
}
