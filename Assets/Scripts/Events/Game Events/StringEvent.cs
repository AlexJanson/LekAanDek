using UnityEngine;

namespace LekAanDek.Events
{
    [CreateAssetMenu(fileName = "StringEvent.asset", menuName = "Events/String")]
    public sealed class StringEvent : BaseGameEvent<string>
    {
    }
}
