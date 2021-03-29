using UnityEngine;

namespace Beweegmaatje.Events
{
    [CreateAssetMenu(fileName = "QuaternionEvent.asset", menuName = "Events/Quaternion")]
    public sealed class QuaternionEvent : BaseGameEvent<Quaternion>
    {
    }
}
