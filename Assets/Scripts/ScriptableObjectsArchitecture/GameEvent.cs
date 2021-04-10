using System.Collections.Generic;
using UnityEngine;

namespace InnovamatTechnicalChallenge.SOArchitecture
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();

        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised();
        }

        public void RegisterListener(GameEventListener _listener) => listeners.Add(_listener);

        public void UnregisterListener(GameEventListener _listener) => listeners.Remove(_listener);
    }
}