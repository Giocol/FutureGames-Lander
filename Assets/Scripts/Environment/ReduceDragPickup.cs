using UnityEngine;

namespace Environment {
    public class ReduceDragPickup  : MonoBehaviour{
        [SerializeField] private float dragReduction;

        private void OnTriggerEnter(Collider other) {
            Rigidbody collidedRb = other.gameObject.GetComponent<Rigidbody>();
            if(collidedRb) {
                collidedRb.drag -= dragReduction;
                Destroy(gameObject);
            }
        }
    }
}
