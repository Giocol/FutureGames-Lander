using AI;
using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Ship {
    public class ThreatCameraController : MonoBehaviour {
        [SerializeField] private RawImage turretRenderTextureImage;
        [SerializeField] private float dangerCameraGrowingSpeed = 0.01f;
        [SerializeField] private float maxDistance;

        private GameObject currentTarget;
        private GameObject[] turrets;
        private bool hasTarget;
        private float distanceFromCurrentTarget;
        private Vector2 initialAnchoredPosition;
        private Vector2 initialSizeDelta;


        private void Awake() {
            turrets = GameObject.FindGameObjectsWithTag("Turret");
            hasTarget = false;
            initialAnchoredPosition = turretRenderTextureImage.rectTransform.anchoredPosition;
            initialSizeDelta= turretRenderTextureImage.rectTransform.sizeDelta;
        }

        private void Update() {
            if(turrets.Length > 0) {
                if(!hasTarget) {
                    currentTarget = SortingUtils.GetClosestTarget(transform.position, turrets);
                    hasTarget = true;
                    currentTarget.GetComponent<TurretAI>().ToggleCamera(true);
                    //TODO: run a "danger" sound when new target is acquired
                }
                else if(distanceFromCurrentTarget >= maxDistance) {
                    hasTarget = false;
                    distanceFromCurrentTarget = 0;
                    currentTarget.GetComponent<TurretAI>().ToggleCamera(false);
                }
                else {
                    distanceFromCurrentTarget = Vector3.Distance(transform.position, currentTarget.transform.position);
                    ResizeThreatRenderTexture();
                }
            }
        }

        //To resize the render texture proportionally to the distance between turret and ship,
        // I normalize the distance and clamp the min to zero, then calculate the target position and sizedelta
        // proportionally, then lerp between current values and target values
        private void ResizeThreatRenderTexture() {
            float normalizedDistance = Math.Clamp(distanceFromCurrentTarget / maxDistance, 0, 1);
            Vector2 newAnchoredPosition = initialAnchoredPosition * normalizedDistance;
            Vector2 newSizeDelta = initialSizeDelta * normalizedDistance;
            turretRenderTextureImage.rectTransform.anchoredPosition = new Vector2(Mathf.Lerp(turretRenderTextureImage.rectTransform.anchoredPosition.x, newAnchoredPosition.x, dangerCameraGrowingSpeed), Mathf.Lerp(turretRenderTextureImage.rectTransform.anchoredPosition.y, newAnchoredPosition.y, dangerCameraGrowingSpeed));
            turretRenderTextureImage.rectTransform.sizeDelta = new Vector2(Mathf.Lerp(turretRenderTextureImage.rectTransform.sizeDelta.x, newSizeDelta.x, dangerCameraGrowingSpeed), Mathf.Lerp(turretRenderTextureImage.rectTransform.sizeDelta.y, newSizeDelta.y, dangerCameraGrowingSpeed));
        }
    }
}
