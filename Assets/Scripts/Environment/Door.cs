using LekAanDek.Variables;
using UnityEngine;

namespace LekAanDek.Environment
{
    /// <summary>
    /// Handling the door state and animations.
    /// </summary>
    public sealed class Door : MonoBehaviour
    {
        public BoolVariable isOpen;
        public Animator animator;
        // Cache the property for faster results.
        private static readonly int IsOpen = Animator.StringToHash("isOpen");
        
        private void Start() => isOpen.OnChange += HandleDoorStateChange;

        private void HandleDoorStateChange(bool state)
        {
            if (state) OpenDoor();
        }

        private void OpenDoor() => animator.SetBool(IsOpen, isOpen.Value);
    }
}
