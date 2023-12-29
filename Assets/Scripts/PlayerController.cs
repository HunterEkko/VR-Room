using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum GrabMode{
    LEFT_GRAB,
    RIGHT_GRAB,
    NO_GRAB
}
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionProperty leftHandShootAction;
    public InputActionProperty LeftHandShootAction
    {
        get => leftHandShootAction;
        set => leftHandShootAction = value;
    }

    [SerializeField] private InputActionProperty rightHandShootAction;
    public InputActionProperty RightHandShootAction
    {
        get => rightHandShootAction;
        set => rightHandShootAction = value;
    }

    //----------------------------------------------------------------------------------
    public event Action LeftShooted;
    public event Action RightShooted;
    private void Update()
    {
        if (leftHandShootAction.action.WasPressedThisFrame())
            LeftShooted?.Invoke();

        if (rightHandShootAction.action.WasPressedThisFrame())
            RightShooted?.Invoke();
    }
}
