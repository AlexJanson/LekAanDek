using System;
using UnityEngine;

namespace Beweegmaatje.Variables
{
    [Serializable]
    public class GameObjectReference : BaseReference<GameObject, GameObjectVariable>
    {
        public GameObjectReference() : base() { }
        public GameObjectReference(GameObject value) : base(value) { }
    }
}
