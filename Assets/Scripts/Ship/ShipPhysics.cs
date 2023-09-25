using UnityEngine;

namespace Ship {
    public class ShipPhysics : MonoBehaviour {
        [SerializeField] private float directionalThrustersForce = 10f;
        [SerializeField] private float takeoffThrusterForce = 5f;

        private Vector3 currentDirectionalForce;
        private Vector3 currentTakeoffForce;
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
        }

        public void EngageTakeoffThruster() {
            //Debug.Log("Takeoff thrusters engaged");
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

    }
}
