using UnityEngine;
using Type = System.Type;

namespace Beweegmaatje.Variables
{
    public class BaseVariable<T> : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif

        public virtual T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = SetValue(value);
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

        public virtual T SetValue(BaseVariable<T> value)
        {
            return SetValue(value.Value);
        }

        public virtual T SetValue(T value)
        {
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
