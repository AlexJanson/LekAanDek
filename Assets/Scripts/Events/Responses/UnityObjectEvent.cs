using UnityEngine;
using UnityEngine.Events;

namespace Beweegmaatje.Events
{
    [System.Serializable]
    public sealed class UnityObjectEvent : UnityEvent<Object>
    {
    }
}