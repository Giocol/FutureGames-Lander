using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

namespace Ship {
    [CreateAssetMenu(menuName = "Scriptable Objects/ShipHull")]
    public class ShipHull : ScriptableObject {

        [SerializeField] private int currentHullHealth;
        [SerializeField] private int maxHullHealth;

        public int HullHealth => currentHullHealth;

        public void TakeDamage(int damage) {
            currentHullHealth -= damage;
            if(currentHullHealth < 0) {
                currentHullHealth = 0;
            }
        }

        public void RestoreMaxHullHp() {
            currentHullHealth = maxHullHealth;
        }
    }
}
