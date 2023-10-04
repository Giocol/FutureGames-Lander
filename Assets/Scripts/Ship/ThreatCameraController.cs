using System;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Ship {
    public class ThreatCameraController : MonoBehaviour {
        [SerializeField] private RawImage turretRenderTextureImage;

        private GameObject currentTarget;
        private GameObject[] turrets;
        private bool hasTarget;

        private void Awake() {
            turrets = GameObject.FindGameObjectsWithTag("Turret");
            hasTarget = false;
        }

        private void Update() {
            if(!hasTarget) {
                currentTarget = SortingUtils.GetClosestTarget(transform.position, turrets);
            }
        }

    }
}
