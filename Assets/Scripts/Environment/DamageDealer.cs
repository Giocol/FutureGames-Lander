using Ship;
using UnityEngine;

namespace Environment {
    public class DamageDealer : MonoBehaviour {

        [SerializeField] private int damageToHull;
        [SerializeField] private bool destroyOnCrash;

        private void OnCollisionEnter(Collision other) {
            ShipComputer shipComputer = other.gameObject.GetComponent<ShipComputer>();
            if(!shipComputer) {
                return;
            }
            shipComputer.OnTakeDamage(damageToHull);

            if(destroyOnCrash) { //Rigidbody damage-dealer (like missiles) will be destroyed on crash
                Destroy(this.gameObject);
            }
        }
    }
}
