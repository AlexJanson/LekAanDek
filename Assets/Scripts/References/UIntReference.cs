using System;

namespace LekAanDek.Variables
{
    [Serializable]
    public class UIntReference : BaseReference<uint, UIntVariable>
    {
        public UIntReference() : base() { }
        public UIntReference(uint value) : base(value) { }
    }
}
