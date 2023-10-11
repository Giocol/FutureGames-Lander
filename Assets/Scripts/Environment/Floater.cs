using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Environment {
    public class Floater : MonoBehaviour{
        [SerializeField] private float floatingSpeed = 5f;
        [SerializeField] private float floatingAmplitude = 1f;
        private float floatingCenter;
        private Vector3 currentPosition;

        private void Start() {
            floatingCenter = transform.position.y;
        }

        private void Update() {
            currentPosition = transform.position;
            transform.position = new Vector3(currentPosition.x, Mathf.Sin(Time.time * floatingSpeed) * floatingAmplitude + floatingCenter, currentPosition.z);
        }
    }
}
