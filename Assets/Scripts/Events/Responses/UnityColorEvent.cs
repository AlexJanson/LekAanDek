using System;
using UnityEngine.Events;
using UnityEngine;

namespace LekAanDek.Events
{
    [Serializable]
    public sealed class UnityColorEvent : UnityEvent<Color>
    {
    }
}