using UnityEngine;
using UnityEngine.Events;

namespace Beweegmaatje.Events
{
    public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour,
        IBaseGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T>
    {
        public E Event;
        public UER Response;

        private void OnEnable()
        {
            Event.RegisterListeners(this);
        }

        private void OnDestroy()
        {
            Event.UnregisterListeners(this);
        }

        public void OnEventRaised(T arg)
        {
            Response.Invoke(arg);
        }
    }
}