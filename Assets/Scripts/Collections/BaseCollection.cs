using System.Collections;
using UnityEngine;
using Type = System.Type;

namespace Beweegmaatje.Collections
{
    public abstract class BaseCollection : ScriptableObject, IEnumerable
    {
        public object this[int index]
        {
            get
            {
                return List[index];
            }
            set
            {
                List[index] = value;
            }
        }

        public int Count 
        { 
            get 
            { 
                return List.Count; 
            } 
        }

        public abstract IList List { get; }
        public abstract Type Type { get; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return List.GetEnumerator();
        }
        
        public bool Contains(object o)
        {
            return List.Contains(o);
        }
    }
}
