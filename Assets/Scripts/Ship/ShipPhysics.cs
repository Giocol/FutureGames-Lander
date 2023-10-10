using UnityEngine;

namespace Ship {
    public class ShipPhysics : MonoBehaviour {
        [SerializeField] private float directionalThrustersForce = 10f;
        [SerializeField] private float takeoffThrusterForce = 5f;
        [SerializeField] private float yawThrusterForce = 0.5f;

        private Vector3 currentDirectionalForce;
        private Vector3 currentTakeoffForce;
        private Vector3 currentTorque;

        private new Rigidbody rigidbody;
        private bool isTakeoffThrusterEngaged;

        private void Awake() {
            rigidbody = GetComponent<Rigidbody>();
            if(!rigidbody) {
                Debug.LogError("No rigidbody component attached to the ship found");
            }
            isTakeoffThrusterEngaged = false;
        }


        private void FixedUpdate() {
            rigidbody.AddRelativeForce(currentDirectionalForce, ForceMode.Impulse);
            rigidbody.AddRelativeForce(currentTakeoffForce, ForceMode.Acceleration);
            rigidbody.AddTorque(currentTorque, ForceMode.Acceleration);
        }

        public void EngageTakeoffThruster() {
            if(!isTakeoffThrusterEngaged) {
                currentTakeoffForce = Vector3.up * takeoffThrusterForce;
                isTakeoffThrusterEngaged = true;
            }
        }

        public void DisengageTakeoffThruster() {
            if(isTakeoffThrusterEngaged) {
                currentTakeoffForce = Vector3.zero;
                isTakeoffThrusterEngaged = false;
            }
        }

        public void EngageDirectionalThrusters(Vector2 direction) {
            currentDirectionalForce = new Vector3(direction.x, 0, direction.y) * directionalThrustersForce;
        }

        public void EngageYawThrusters(float yaw) {
            currentTorque = new Vector3(0, yaw * yawThrusterForce, 0);
        }

    }
}
