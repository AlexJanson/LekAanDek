using System;
using UnityEngine.Events;
using UnityEngine;

namespace Beweegmaatje.Events
{
    [Serializable]
    public sealed class UnityVector3Event : UnityEvent<Vector3>
    {
    }
}