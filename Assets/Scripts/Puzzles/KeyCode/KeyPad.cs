using UnityEngine;
using LekAanDek.Variables;
using LekAanDek.Events;

namespace LekAanDek.KeyCode
{
    /// <summary>
    /// The behind the scenes of the keypad, it compares values, receives input and invokes conditions.
    /// </summary>
    public class KeyPad : MonoBehaviour
    {
        [SerializeField] [Tooltip("The current playerinput")]
        private StringVariable _currentInput;
        [SerializeField] [Tooltip("The correct code to unlock")]
        private StringVariable _correctCode;
        [SerializeField] [Tooltip("An event to unlock the door and update the display")]
        private VoidEvent _unlockDoor, _displayUpdate;
        [SerializeField] [Tooltip("A bool to tell the display wether the attempt was succesful or not")]
        private BoolEvent _attemptSuccesful;
        //Local bool to stop it from tracking once it's over.
        bool _unlocked;

        //Make sure the playerinput is empty before beginning
        void Start() => Clear();

        public void RemoveKey()
        {
            if (!_unlocked)
            {
                if (_currentInput.Value.Length > 0)
                    _currentInput.Value = _currentInput.Value.Remove(_currentInput.Value.Length - 1);
                else
                    _attemptSuccesful.Raise(false);
                _displayUpdate.Raise();
            }
        }

        public void CheckCode()
        {
            if (!_unlocked)
            {
                if (_currentInput.Value == _correctCode.Value)
                {
                    _attemptSuccesful.Raise(true);
                    _unlockDoor.Raise();
                    _unlocked = true;
                }
                else
                {
                    _attemptSuccesful.Raise(false);
                    Clear();
                }
                _displayUpdate.Raise();
            }
        }

        public void InputKey(string _input)
        {
            if (!_unlocked)
            {
                if (_currentInput.Value.Length < _correctCode.Value.Length)
                    _currentInput.Value = _currentInput.Value + _input;
                else
                    _attemptSuccesful.Raise(false);
                _displayUpdate.Raise();
            }
        }

        public void Clear()
        {
            _currentInput.Value = "";
            _displayUpdate.Raise();
        }
    }
}
