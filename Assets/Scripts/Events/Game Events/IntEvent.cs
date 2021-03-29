using UnityEngine;

namespace Beweegmaatje.Events
{
    [CreateAssetMenu(fileName = "IntEvent.asset", menuName = "Events/Int")]
    public sealed class IntEvent : BaseGameEvent<int>
    {
    }
}
