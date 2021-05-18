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
        private Animator _animator;
        // Cache the property for faster results.
        private static readonly int IsOpen = Animator.StringToHash("isOpen");

        private void Start()
        {
            _animator = GetComponent<Animator>();
            isOpen.OnChange += HandleDoorStateChange;
        }

        private void HandleDoorStateChange(bool state)
        {
            if (state) OpenDoor();
            else CloseDoor();
        }

        private void OpenDoor() => _animator.SetBool(IsOpen, isOpen.Value);
        private void CloseDoor() => _animator.SetBool(IsOpen, isOpen.Value);
    }
}
