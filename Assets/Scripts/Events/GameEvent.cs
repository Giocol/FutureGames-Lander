using System.Collections.Generic;
using UnityEngine;

namespace Events {
    //Took heavy inspiration from Ryan Hipple's Scriptable Objects talk @Unite2017 (https://www.youtube.com/watch?v=raQ3iHhE_Kk)

    [CreateAssetMenu(menuName = "Scriptable Objects/Game Event")]
    public class GameEvent : ScriptableObject {
        private List<GameEventListener> listeners = new List<GameEventListener>();

        public void Raise() {
            for(int i = listeners.Count - 1; i >= 0; i--) {
                listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListener listener) {
            listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener) {
            listeners.Remove(listener);
        }

    }
}
