using System;
using UnityEngine.Events;

namespace Beweegmaatje.Events
{
    [Serializable]
    public sealed class UnityStringEvent : UnityEvent<string>
    {
    }
}