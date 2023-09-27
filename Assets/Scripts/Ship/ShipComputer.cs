using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace Ship {
    // Class that contains all the ship's status
    public class ShipComputer : MonoBehaviour {

        [SerializeField] private ShipHull shipHull;
        private bool isShipDestroyed;

        //TODO: consider if it's better to detect collisions here rather than in the terrain

        private void Awake() {
            shipHull.RestoreMaxHullHp();
            isShipDestroyed = false;
        }

        public void OnLanding() {
            Debug.Log("Landed!");
            SceneUtils.LoadNextScene();
        }

        public void OnTakeDamage(int damage) {
            shipHull.TakeDamage(damage, out isShipDestroyed);

            if(isShipDestroyed) {
                OnShipDestroyed();
            }
            Debug.Log($"Took damage, {shipHull.HullHealth} HP remaining");
        }

        private void OnShipDestroyed() {
            Debug.Log("Crashed!");
        }
    }
}
