using Ship;
using System;
using UnityEngine;

namespace Environment {
    public class LandingZone : MonoBehaviour{

        private void OnCollisionEnter(Collision other) {
            //TODO: get the right component, the one that handles touchdowns and crashes, not ShipPhysics
            var shipComputer = other.gameObject.GetComponent<ShipPhysics>();
            if(shipComputer) {
                //TODO: call shipComputer.OnLanding instead
                OnLanding();
            }
        }

        //TODO: delete this and call shipComputer.OnLanding();
        private void OnLanding() {
            Debug.Log("LANDED!!!!!");
        }
    }
}
