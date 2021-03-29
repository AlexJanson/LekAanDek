using System;

namespace Beweegmaatje.Variables
{
    [Serializable]
    public class ShortReference : BaseReference<short, ShortVariable>
    {
        public ShortReference() : base() { }
        public ShortReference(short value) : base(value) { }
    }
}
