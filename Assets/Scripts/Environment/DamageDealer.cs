using Ship;
using UnityEngine;

namespace Environment {
    public class DamageDealer : MonoBehaviour {

        [SerializeField] private int damageToHull;

        private void OnCollisionEnter(Collision other) {
            ShipComputer shipComputer = other.gameObject.GetComponent<ShipComputer>();
            if(shipComputer) {
                shipComputer.OnTakeDamage(damageToHull);
            }
        }

    }
}
