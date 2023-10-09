using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

namespace Ship {
    [CreateAssetMenu(menuName = "Scriptable Objects/ShipHull")]
    public class ShipHull : ScriptableObject {

        [SerializeField] private int currentHullHealth;
        [SerializeField] private int maxHullHealth;

        public int HullHealth => currentHullHealth;
        public int MaxHullHealth => maxHullHealth;


        /// <summary>
        /// The method diminishes the current HP
        /// and signals the ship's destruction if HP is less than 0
        /// </summary>
        /// <param name="damage">damage taken</param>
        /// <param name="isShipDestroyed">out parameter, will be set to true if the ship hull goes to 0 hp</param>
        public void TakeDamage(int damage, out bool isShipDestroyed) {
            currentHullHealth -= damage;
            if(currentHullHealth <= 0) {
                currentHullHealth = 0;
                isShipDestroyed = true;
            }
            else {
                isShipDestroyed = false;
            }
        }

        public void RestoreMaxHullHp() {
            currentHullHealth = maxHullHealth;
        }

        public void RepairHull(int hpRepaired) {
            currentHullHealth += hpRepaired;
            if(currentHullHealth > maxHullHealth) {
                currentHullHealth = maxHullHealth;
            }
        }
    }
}
