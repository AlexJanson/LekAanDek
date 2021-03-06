using System;
using UnityEngine;

namespace LekAanDek.Variables
{
    [Serializable]
    public class QuaternionReference : BaseReference<Quaternion, QuaternionVariable>
    {
        public QuaternionReference() : base() { }
        public QuaternionReference(Quaternion value) : base(value) { }
    }
}
