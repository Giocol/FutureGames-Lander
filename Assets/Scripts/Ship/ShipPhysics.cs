using System;
using UnityEngine;

namespace Ship
{
    public class ShipPhysics : MonoBehaviour
    {
        [SerializeField] private float directionalThrustersForce = 10f;
        [SerializeField] private float takeoffThrusterForce = 5f;
        
        private Vector3 currentDirectionalForce;
        private Vector3 currentTakeoffForce;
        private new Rigidbody rigidbody;
        
        private void Awake()
        {
            rigidbody = this.GetComponent<Rigidbody>();
            if (!rigidbody)
            {
                Debug.LogError("No rigidbody component attached to the ship found");
            }
        }

        
        private void FixedUpdate()
        {
            rigidbody.AddForce(currentDirectionalForce, ForceMode.Impulse);
            rigidbody.AddForce(currentTakeoffForce, ForceMode.Acceleration);
        }
        
        public void EngageTakeoffThruster()
        {
            Debug.Log("Takeoff thrusters engaged");
            currentTakeoffForce = Vector3.up * takeoffThrusterForce;
        }

        public void DisengageTakeoffThruster()
        {
            Debug.Log("Takeoff thrusters disengaged");
            currentTakeoffForce = Vector3.zero;
        }
        
        public void EngageDirectionalThrusters(Vector2 direction)
        {
            //Debug.Log($"Thrusters activated on direction {direction.x} {direction.y}");
            currentDirectionalForce = new Vector3(direction.x, 0, direction.y) * directionalThrustersForce;
        }

    }
}