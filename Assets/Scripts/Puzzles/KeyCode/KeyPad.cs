using UnityEngine;
using LekAanDek.Variables;
using LekAanDek.Events;
using System.Collections.Generic;

namespace LekAanDek.KeyCode
{
    /// <summary>
    /// The behind the scenes of the keypad, it compares values, receives input and invokes conditions.
    /// </summary>
    public class KeyPad : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The current playerinput")]
        private StringVariable _currentInput;
        [SerializeField]
        [Tooltip("The correct code to unlock")]
        private StringVariable _correctCode;
        [SerializeField]
        [Tooltip("An event to unlock the door and update the display")]
        private VoidEvent _unlockDoor, _displayUpdate;
        [SerializeField]
        [Tooltip("A bool to tell the display wether the attempt was succesful or not")]
        private BoolEvent _attemptSuccesful;

        [Header("- Optional -")]
        [SerializeField]
        [Tooltip("The audiosource for the keypad.")]
        private AudioSource _audio;
        [SerializeField]
        private List<AudioClip> _buttonClips;
        [SerializeField]
        private AudioClip _correctClip, _incorrectClip, _removeClip;

        //Local bool to stop it from tracking once it's over.
        private bool _unlocked, _paused;

        //Make sure the playerinput is empty before beginning
        void Start() => Clear();

        public void RemoveKey()
        {
            if (_unlocked || _paused) return;

            if (_currentInput.Value.Length > 0)
            {
                PlayClip(_removeClip);
                _currentInput.Value = _currentInput.Value.Remove(_currentInput.Value.Length - 1);
            }
            else
            {
                _attemptSuccesful.Raise(false);
                PlayClip(_incorrectClip);
            }
            _displayUpdate.Raise();
        }

        public void CheckCode()
        {
            if (_unlocked || _paused) return;

            if (_currentInput.Value == _correctCode.Value)
            {
                _attemptSuccesful.Raise(true);
                _unlockDoor.Raise();
                _unlocked = true;
                PlayClip(_correctClip);
            }
            else
            {
                _attemptSuccesful.Raise(false);
                PlayClip(_incorrectClip);
                Clear();
            }
            _displayUpdate.Raise();
        }

        public void InputKey(string _input)
        {
            if (_unlocked || _paused) return;

            if (_currentInput.Value.Length < _correctCode.Value.Length)
            {
                _currentInput.Value = _currentInput.Value + _input;

                if(_buttonClips.Count > 0)
                PlayClip(_buttonClips[_buttonClips.Count >= int.Parse(_input) ? int.Parse(_input) : 0]);
            }
            else
            {
                PlayClip(_incorrectClip);
                _attemptSuccesful.Raise(false);
            }
            _displayUpdate.Raise();
        }

        public void PlayClip(AudioClip track)
        {
            if (!_audio || !track) return;
            _audio.clip = track;
            _audio.Play();
        }

        public void Clear()
        {
            _currentInput.Value = "";
            _displayUpdate.Raise();
        }

        public void Pausing(bool input)
        {
            _paused = input;
        }
    }
}
