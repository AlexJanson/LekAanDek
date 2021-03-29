using System;
using UnityEngine;

namespace Beweegmaatje.Variables
{
    [Serializable]
    public class BaseReference<TBase, TVariable> : BaseReference where TVariable : BaseVariable<TBase>
    {
        public BaseReference() { }
        public BaseReference(TBase baseValue)
        {
            _useConstant = true;
            _constantValue = baseValue;
        }

        [SerializeField]
        protected bool _useConstant = false;
        [SerializeField]
        protected TBase _constantValue = default(TBase);
        [SerializeField]
        protected TVariable _variable = default(TVariable);

        public TBase Value
        {
            get
            {
                return (_useConstant || _variable == null) ? _constantValue : _variable.Value;
            }
            set
            {
                if (!_useConstant && _variable != null)
                {
                    _variable.Value = value;
                }
                else
                {
                    _useConstant = true;
                    _constantValue = value;
                }
            }
        }

        public bool IsValueDefined
        {
            get
            {
                return _useConstant || _variable != null;
            }
        }

        public BaseReference CreateCopy()
        {
            BaseReference<TBase, TVariable> copy = (BaseReference<TBase, TVariable>) Activator.CreateInstance(GetType());
            copy._useConstant = _useConstant;
            copy._constantValue = _constantValue;
            copy._variable = _variable;

            return copy;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator TBase(BaseReference<TBase, TVariable> reference)
        {
            return reference.Value;
        }
    }

    public abstract class BaseReference { }
}
