using UnityEngine;

namespace Beweegmaatje.Events
{
    [CreateAssetMenu(fileName = "ObjectEvent.asset", menuName = "Events/Object")]
    public sealed class ObjectEvent : BaseGameEvent<Object>
    {
    }
}
