using System;

namespace Beweegmaatje.Variables
{
    [Serializable]
    public class DoubleReference : BaseReference<double, DoubleVariable>
    {
        public DoubleReference() : base() { }
        public DoubleReference(double value) : base(value) { }
    }
}
