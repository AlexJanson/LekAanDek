using UnityEngine;

namespace LekAanDek.Environment
{
    /// <summary>
    /// Handling the door state and animations.
    /// </summary>
    public sealed class Door : MonoBehaviour
    {
        private bool _isOpen;
        private Animator _animator;
        // Cache the property for faster results.
        private static readonly int IsOpen = Animator.StringToHash("isOpen");

        private void Start() => _animator = GetComponent<Animator>();

        // API functions.
        public void OpenDoor()
        {
            _isOpen = true;
            _animator.SetBool(IsOpen, _isOpen);
        }
        public void CloseDoor()
        {
            _isOpen = false;
            _animator.SetBool(IsOpen, _isOpen);
        }
    }
}
