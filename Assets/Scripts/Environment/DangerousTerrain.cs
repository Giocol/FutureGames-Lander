using Ship;
using UnityEngine;

namespace Environment {
    public class DangerousTerrain : MonoBehaviour {

        private void OnCollisionEnter(Collision other) {
            ShipComputer shipComputer = other.gameObject.GetComponent<ShipComputer>();
            if(shipComputer) {
                shipComputer.OnCrash();
            }
        }
    }

}
