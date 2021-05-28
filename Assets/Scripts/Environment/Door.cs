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
        public AudioSource source;
        // Cache the property for faster results.
        private static readonly int IsOpen = Animator.StringToHash("isOpen");
        private bool _audioPlayed;

        private void Start() => isOpen.OnChange += HandleDoorStateChange;

        private void HandleDoorStateChange(bool state)
        {
            if (state) OpenDoor();
        }

        private void OpenDoor()
        {
            if (!_audioPlayed)
            {
                source.Play();
                _audioPlayed = true;
            }
            animator.SetBool(IsOpen, isOpen.Value);
        }
    }
}
