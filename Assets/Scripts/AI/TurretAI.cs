using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Utils;
using Random = UnityEngine.Random;

namespace AI {
    public class TurretAI : MonoBehaviour {
        [SerializeField] private float turretRotationSpeed = 1f;
        [SerializeField] private float minTimeBeforeShooting = 4f;
        [SerializeField] private float maxTimeBeforeShooting = 8f;
        [SerializeField] private float reloadingTime = 2f;
        [SerializeField] private GameObject missilePrefab;
        [SerializeField] private float missileSpeed = 100f;
        [SerializeField] private float missileTimeToLive = 10f;

        private float timeBeforeShooting;
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
                    timeBeforeShooting = Random.Range(minTimeBeforeShooting, maxTimeBeforeShooting);
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
            WaitSecondsAndDestroyMissile(missile);

            needsToReload = true;
            StartCoroutine(Reload());

        }

        private IEnumerator Reload() {
            //Reset variables and acquire new target
            timeSpentAiming = 0;
            hasCurrentTarget = false;
            Debug.Log(timeBeforeShooting);
            yield return new WaitForSeconds(reloadingTime);
            timeBeforeShooting += Random.Range(minTimeBeforeShooting, maxTimeBeforeShooting);
            needsToReload = false;
        }

        private void WaitSecondsAndDestroyMissile(GameObject missile) {
            Destroy(missile, missileTimeToLive);
        }

        public void ToggleCamera(bool enable) {
            turretCamera.SetActive(enable);
        }
    }
}
