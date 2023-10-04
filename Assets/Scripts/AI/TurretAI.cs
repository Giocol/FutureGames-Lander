using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Utils;

namespace AI {
    public class TurretAI : MonoBehaviour {
        [SerializeField] private float turretRotationSpeed = 1f;
        [SerializeField] private float timeBeforeShooting = 4f;
        [SerializeField] private float reloadingTime = 2f;
        [SerializeField] private GameObject missilePrefab;
        [SerializeField] private float missileSpeed = 100f;
        [SerializeField] private float missileTimeToLive = 10f;

        private GameObject[] targetShips;
        private bool hasCurrentTarget;
        private GameObject currentTarget;
        private float timeSpentAiming;
        private bool needsToReload;
        private GameObject turretCamera;

        private void Awake() {
            targetShips = GameObject.FindGameObjectsWithTag("Ship");
            hasCurrentTarget = false;
            timeSpentAiming = 0;
            needsToReload = false;
            turretCamera = transform.Find("TurretCamera").gameObject;
        }

        private void Update() {
            if(!needsToReload) {
                if(!hasCurrentTarget) { // Select closest ship to target
                    currentTarget = SortingUtils.GetClosestTarget(transform.position, targetShips);
                    hasCurrentTarget = true;
                }
                RotateTowardsTarget();
            }
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
            GameObject missile = Instantiate(missilePrefab, transform.position, transform.rotation);
            missile.GetComponentInChildren<Rigidbody>().AddRelativeForce(Vector3.forward * (missileSpeed *Time.fixedDeltaTime), ForceMode.VelocityChange);
            StartCoroutine(WaitSecondsAndDestroyMissile(missile));

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

        private IEnumerator WaitSecondsAndDestroyMissile(GameObject missile) {
            yield return new WaitForSeconds(missileTimeToLive);
            Destroy(missile);
        }

        public void ToggleCamera(bool enable) {
            turretCamera.SetActive(enable);
        }
    }
}
