using UnityEngine;

namespace Beweegmaatje.Events
{
    [CreateAssetMenu(fileName = "BoolEvent.asset", menuName = "Events/Bool")]
    public sealed class BoolEvent : BaseGameEvent<bool>
    {
    }
}
