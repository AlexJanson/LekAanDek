using System;
using UnityEngine;

namespace Beweegmaatje.Variables
{
    [Serializable]
    public class ColorReference : BaseReference<Color, ColorVariable>
    {
        public ColorReference() : base() { }
        public ColorReference(Color value) : base(value) { }
    }
}
