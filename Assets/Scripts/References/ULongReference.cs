using System;

namespace LekAanDek.Variables
{
    [Serializable]
    public class ULongReference : BaseReference<ulong, ULongVariable>
    {
        public ULongReference() : base() { }
        public ULongReference(ulong value) : base(value) { }
    }
}
