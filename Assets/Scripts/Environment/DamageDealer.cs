using Ship;
using UnityEngine;

namespace Environment {
    public class DamageDealer : MonoBehaviour {

        [SerializeField] private int damageToHull;

        private void OnCollisionEnter(Collision other) {
            ShipComputer shipComputer = other.gameObject.GetComponent<ShipComputer>();
            if(!shipComputer) {
                return;
            }
            shipComputer.OnTakeDamage(damageToHull);

            if(this.GetComponent<Rigidbody>()) { //Rigidbody damage-dealer (like missiles) will be destroyed on crash
                Destroy(this.gameObject);
            }
        }
    }
}
