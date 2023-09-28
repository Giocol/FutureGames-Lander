using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace AI {
    public class TurretAI : MonoBehaviour {
        [SerializeField] private float turretRotationSpeed = 1f;
        [SerializeField] private float timeBeforeShooting = 4f;
        [SerializeField] private float reloadingTime = 2f;

        private GameObject[] targetShips;
        private bool hasCurrentTarget;
        private GameObject currentTarget;
        private float timeSpentAiming;
        private bool needsToReload;

        private void Awake() {
            targetShips = GameObject.FindGameObjectsWithTag("Ship");
            hasCurrentTarget = false;
            timeSpentAiming = 0;
            needsToReload = false;
        }

        private void Update() {
            if(!needsToReload) {
                if(!hasCurrentTarget) { // Select closest ship to target
                    currentTarget = GetClosestTarget();
                    hasCurrentTarget = true;
                }
                RotateTowardsTarget();
            }
        }

        private GameObject GetClosestTarget() {
            Debug.Log("Acquiring target");
            Array.Sort(targetShips, (a, b) => {
                Vector3 position = transform.position;
                return Vector3.Distance(a.transform.position, position).CompareTo(Vector3.Distance(b.transform.position, position));
            });
            return targetShips[0];
        }

        private void RotateTowardsTarget() {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, currentTarget.transform.position - transform.position, turretRotationSpeed * Time.deltaTime, 0.0f);

            Debug.DrawRay(transform.position, newDirection, Color.red);

            transform.rotation = Quaternion.LookRotation(newDirection);

            timeSpentAiming += Time.deltaTime;

            if(timeSpentAiming >= timeBeforeShooting) {
                ShootMissile();
            }
        }

        private void ShootMissile() {
            Debug.Log("Shoot missile!");

            needsToReload = true;
            StartCoroutine(Reload());

        }

        private IEnumerator Reload() {
            //Reset variables and acquire new target
            timeSpentAiming = 0;
            hasCurrentTarget = false;
            Debug.Log("reloading");
            yield return new WaitForSeconds(reloadingTime);
            needsToReload = false;
        }
    }
}
