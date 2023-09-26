using Ship;
using UnityEngine;

namespace Environment {
    public class DangerousTerrain : MonoBehaviour {

        [SerializeField] private int damageToHull = 100;

        private void OnCollisionEnter(Collision other) {
            ShipComputer shipComputer = other.gameObject.GetComponent<ShipComputer>();
            if(shipComputer) {
                shipComputer.OnTakeDamage(damageToHull);
            }
        }

    }
}
