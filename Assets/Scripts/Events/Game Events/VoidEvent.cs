using UnityEngine;

namespace LekAanDek.Events
{
    [CreateAssetMenu(fileName = "VoidEvent.asset", menuName = "Events/Void")]
    public sealed class VoidEvent : BaseGameEvent<Void>
    {
        public void Raise() => Raise(new Void());
    }
}
