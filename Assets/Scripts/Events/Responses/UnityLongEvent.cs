using System;
using UnityEngine.Events;

namespace Beweegmaatje.Events
{
    [Serializable]
    public sealed class UnityLongEvent : UnityEvent<long>
    {
    }
}