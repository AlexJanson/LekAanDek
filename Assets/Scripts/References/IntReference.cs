using System;

namespace Beweegmaatje.Variables
{
    [Serializable]
    public class IntReference : BaseReference<int, IntVariable>
    {
        public IntReference() : base() { }
        public IntReference(int value) : base(value) { }
    }
}