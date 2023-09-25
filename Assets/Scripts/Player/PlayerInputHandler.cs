using Ship;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputHandler : MonoBehaviour {
        private ShipPhysics shipPhysics;
        private ShipComputer shipComputer;
        private PlayerControls controls;
        private InputAction directionalThrusterAction;
        private InputAction takeoffThrusterAction;

        private void Awake() {
            shipPhysics = gameObject.GetComponent<ShipPhysics>();
            shipComputer = gameObject.GetComponent<ShipComputer>();
            //TODO: make this less brittle and less coupled
            if(!shipPhysics) {
                Debug.LogError("No ShipPhysics script attached to the ship found");
            }
            if(!shipComputer) {
                Debug.LogError("No ShipComputer script attached to the ship found");
            }
            controls = new PlayerControls();
            directionalThrusterAction = controls.Player.DirectionalThrusters;
            takeoffThrusterAction = controls.Player.TakeoffThruster;
        }

        private void Update() {
            ReadDirectionalInput(directionalThrusterAction.ReadValue<Vector2>());
            ReadTakeoffInput(takeoffThrusterAction.inProgress);
        }

        private void ReadTakeoffInput(bool pressed) {
            if(pressed) {
                shipPhysics.EngageTakeoffThruster();
            }
            else {
                shipPhysics.DisengageTakeoffThruster();
            }
        }

        private void ReadDirectionalInput(Vector2 direction) {
            shipPhysics.EngageDirectionalThrusters(direction);
        }

        private void OnEnable() {
            controls.Player.Enable();
        }

        private void OnDisable() {
            controls.Player.Disable();
        }
    }
}
