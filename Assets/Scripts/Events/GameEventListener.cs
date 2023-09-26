using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Events {
    //Took heavy inspiration from Ryan Hipple's Scriptable Objects talk @Unite2017 (https://www.youtube.com/watch?v=raQ3iHhE_Kk)
    
    public class GameEventListener : MonoBehaviour {
        public GameEvent gameEvent;
        public UnityEvent response;

        private void OnEnable() {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable() {
            gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised() {
            response.Invoke();
        }
    }
}
