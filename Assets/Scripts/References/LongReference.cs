using System;

namespace LekAanDek.Variables
{
    [Serializable]
    public class LongReference : BaseReference<long, LongVariable>
    {
        public LongReference() : base() { }
        public LongReference(long value) : base(value) { }
    }
}
