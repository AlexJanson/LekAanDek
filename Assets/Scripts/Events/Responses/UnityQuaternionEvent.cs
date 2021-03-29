using System;
using UnityEngine.Events;
using UnityEngine;

namespace LekAanDek.Events
{
    [Serializable]
    public sealed class UnityQuaternionEvent : UnityEvent<Quaternion>
    {
    }
}