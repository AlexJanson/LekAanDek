using System;

namespace Beweegmaatje.Variables
{
    [Serializable]
    public class UShortReference : BaseReference<ushort, UShortVariable>
    {
        public UShortReference() : base() { }
        public UShortReference(ushort value) : base(value) { }
    }
}
