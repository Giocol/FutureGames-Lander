using UnityEngine;

namespace Ship {
    public class ShipComputer : MonoBehaviour {

        //TODO: consider if it's better to detect collisions here rather than in the terrain
        public void OnLanding() {
            Debug.Log("Landed!");
        }

        public void OnCrash() {
            Debug.Log("Crashed!");
        }
    }
}
