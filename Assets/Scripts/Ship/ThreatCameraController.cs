using System;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Ship {
    public class ThreatCameraController : MonoBehaviour {
        [SerializeField] private RawImage turretRenderTextureImage;
        [SerializeField] private float dangerCameraGrowingSpeed = 0.01f;
        private GameObject currentTarget;
        private GameObject[] turrets;
        private bool hasTarget;

        private void Awake() {
            turrets = GameObject.FindGameObjectsWithTag("Turret");
            hasTarget = false;
        }

        private void Update() {
            if(!hasTarget && turrets.Length > 0) {
                currentTarget = SortingUtils.GetClosestTarget(transform.position, turrets);
                hasTarget = true;
            }
            //TODO: final position, need to smoothly do the transition
            //turretRenderTextureImage.rectTransform.anchoredPosition = Vector3.one;
            //turretRenderTextureImage.rectTransform.sizeDelta = Vector2.one;

            turretRenderTextureImage.rectTransform.anchoredPosition = new Vector2(Mathf.Lerp(turretRenderTextureImage.rectTransform.anchoredPosition.x, 1f, dangerCameraGrowingSpeed), Mathf.Lerp(turretRenderTextureImage.rectTransform.anchoredPosition.y, 1f, dangerCameraGrowingSpeed));
            turretRenderTextureImage.rectTransform.sizeDelta = new Vector2(Mathf.Lerp(turretRenderTextureImage.rectTransform.sizeDelta.x, 1f, dangerCameraGrowingSpeed), Mathf.Lerp(turretRenderTextureImage.rectTransform.sizeDelta.y, 1f, dangerCameraGrowingSpeed));

        }



    }
}
