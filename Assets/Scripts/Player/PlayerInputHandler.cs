using System;
using System.Collections;
using System.Collections.Generic;
using Ship;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private ShipPhysics shipPhysics;
    private PlayerControls controls;
    private InputAction directionalThrusterAction;
    private InputAction takeoffThrusterAction;

    void Awake()
    {
        shipPhysics = gameObject.GetComponent<ShipPhysics>();
        //TODO: make this less brittle and less coupled
        if (!shipPhysics)
        {
            Debug.LogError("No ShipPhysics script attached to the ship found");
        }
        controls = new PlayerControls();
        directionalThrusterAction = controls.Player.DirectionalThrusters;
        takeoffThrusterAction = controls.Player.TakeoffThruster;
    }

    private void Update()
    {
        ReadDirectionalInput(directionalThrusterAction.ReadValue<Vector2>());
        ReadTakeoffInput(takeoffThrusterAction.inProgress);
    }
    
    private void ReadTakeoffInput(bool pressed)
    {
        if (pressed)
        {
            shipPhysics.EngageTakeoffThruster();
        }
        else
        {
            //TODO: optimize this, call it only if thrusters are engaged (isEngaged property in ShipPhysics?)
            shipPhysics.DisengageTakeoffThruster();
        }
    }

    private void ReadDirectionalInput(Vector2 direction)
    {
        shipPhysics.EngageDirectionalThrusters(direction);
    }
    
    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }
}
