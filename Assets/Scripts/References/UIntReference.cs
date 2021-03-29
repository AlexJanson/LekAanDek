using System;

namespace Beweegmaatje.Variables
{
    [Serializable]
    public class UIntReference : BaseReference<uint, UIntVariable>
    {
        public UIntReference() : base() { }
        public UIntReference(uint value) : base(value) { }
    }
}
