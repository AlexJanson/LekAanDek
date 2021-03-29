using System;
using UnityEngine.Events;
using UnityEngine;

namespace Beweegmaatje.Events
{
    [Serializable]
    public sealed class UnityVector2Event : UnityEvent<Vector2>
    {
    }
}