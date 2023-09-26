using System;
using UnityEngine;

namespace Ship {
    public class ShipComputer : MonoBehaviour {

        [SerializeField] private ShipHull shipHull;

        //TODO: consider if it's better to detect collisions here rather than in the terrain

        private void Awake() {
            shipHull.RestoreMaxHullHp();
        }

        public void OnLanding() {
            Debug.Log("Landed!");
        }

        public void OnCrash(int damage) {
            shipHull.TakeDamage(damage);
            Debug.Log("Crashed!");
        }

    }
}
