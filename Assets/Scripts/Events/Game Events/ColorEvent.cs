using UnityEngine;

namespace Beweegmaatje.Events
{
    [CreateAssetMenu(fileName = "ColorEvent.asset", menuName = "Events/Color")]
    public sealed class ColorEvent : BaseGameEvent<Color>
    {
    }
}
