using System;
using UnityEngine;

namespace LekAanDek.Variables
{
    [Serializable]
    public class GameObjectReference : BaseReference<GameObject, GameObjectVariable>
    {
        public GameObjectReference() : base() { }
        public GameObjectReference(GameObject value) : base(value) { }
    }
}
