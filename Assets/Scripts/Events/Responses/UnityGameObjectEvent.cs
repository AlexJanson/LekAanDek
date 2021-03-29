using System;
using UnityEngine;
using UnityEngine.Events;

namespace Beweegmaatje.Events
{
    [Serializable]
    public sealed class UnityGameObjectEvent : UnityEvent<GameObject>
    {
    }
}