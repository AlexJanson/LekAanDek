using System;
using UnityEngine;

namespace LekAanDek.Variables
{
    [Serializable]
    public class ColorReference : BaseReference<Color, ColorVariable>
    {
        public ColorReference() : base() { }
        public ColorReference(Color value) : base(value) { }
    }
}
