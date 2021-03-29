using System;
using UnityEngine.Events;
using UnityEngine;

namespace Beweegmaatje.Events
{
    [Serializable]
    public sealed class UnityColorEvent : UnityEvent<Color>
    {
    }
}