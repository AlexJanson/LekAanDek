using System;
using System.Collections.Generic;
using UnityEngine;

namespace Beweegmaatje.Events
{
    public abstract class BaseGameEvent<T> : ScriptableObject
    {
        private readonly List<IBaseGameEventListener<T>> _listeners = new List<IBaseGameEventListener<T>>();

        public virtual void Raise(T arg)
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
                _listeners[i].OnEventRaised(arg);
        }

        public virtual void RegisterListeners(IBaseGameEventListener<T> listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }
        public virtual void UnregisterListeners(IBaseGameEventListener<T> listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }
    }
}