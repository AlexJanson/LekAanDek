using System;
using UnityEngine;
using UnityEngine.Events;

namespace LekAanDek.Events
{
    [Serializable]
    public sealed class UnityGameObjectEvent : UnityEvent<GameObject>
    {
    }
}