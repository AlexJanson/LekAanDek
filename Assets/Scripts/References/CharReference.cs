using System;

namespace LekAanDek.Variables
{
    [Serializable]
    public class CharReference : BaseReference<char, CharVariable>
    {
        public CharReference() : base() { }
        public CharReference(char value) : base(value) { }
    }
}