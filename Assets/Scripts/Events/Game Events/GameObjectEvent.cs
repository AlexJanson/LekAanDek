using UnityEngine;

namespace LekAanDek.Events
{
    [CreateAssetMenu(fileName = "GameObjectEvent.asset", menuName = "Events/GameObject")]
    public sealed class GameObjectEvent : BaseGameEvent<GameObject>
    {
    }
}
