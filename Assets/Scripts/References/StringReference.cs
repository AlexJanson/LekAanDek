using System;

namespace LekAanDek.Variables
{
    [Serializable]
    public class StringReference : BaseReference<string, StringVariable>
    {
        public StringReference() : base() { }
        public StringReference(string value) : base(value) { }
    }
}