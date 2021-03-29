using System;

namespace Beweegmaatje.Variables
{
    [Serializable]
    public class FloatReference : BaseReference<float, FloatVariable>
    {
        public FloatReference() : base() { }
        public FloatReference(float value) : base(value) { }
    }
}