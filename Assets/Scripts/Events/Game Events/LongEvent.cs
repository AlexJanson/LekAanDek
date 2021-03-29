using UnityEngine;

namespace Beweegmaatje.Events
{
    [CreateAssetMenu(fileName = "LongEvent.asset", menuName = "Events/Long")]
    public sealed class LongEvent : BaseGameEvent<long>
    {
    }
}
