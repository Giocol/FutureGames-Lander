using Ship;
using System;
using UnityEngine;

namespace Environment {
    public class RepairPickup : MonoBehaviour {
        [SerializeField] private int hpHealed;

        private void OnTriggerEnter(Collider other) {
            ShipComputer ship = other.gameObject.GetComponent<ShipComputer>();

            if(ship) {
                ship.RepairHull(hpHealed);
                Destroy(gameObject);
            }
        }
    }
}
