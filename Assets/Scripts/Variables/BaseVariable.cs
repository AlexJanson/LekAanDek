using System;
using UnityEngine;
using Type = System.Type;

namespace LekAanDek.Variables
{
    public class BaseVariable<T> : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif

        public event Action<T> OnChange;

        public virtual T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = SetValue(value);
                OnChange?.Invoke(value);
            }
        }

        public Type Type
        {
            get
            {
                return typeof(T);
            }
        }

        public object BaseValue
        {
            get
            {
                return _value;
            }
            set
            {
                _value = SetValue((T)value);
            }
        }

        [SerializeField]
        protected T _value = default(T);

        public T SetValue(BaseVariable<T> value)
        {
            return SetValue(value.Value);
        }

        public T SetValue(T value)
        {
            _value = value;
            return value;
        }

        public override string ToString()
        {
            return _value == null ? "null" : _value.ToString();
        }

        public static implicit operator T(BaseVariable<T> variable)
        {
            return variable.Value;
        }
    }
}
