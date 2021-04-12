using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LekAanDek.Variables;
using LekAanDek.Events;

namespace LekAanDek.KeyCode
{
    public class KeyPad : MonoBehaviour
    {
        [SerializeField]
        private StringVariable _currentInput;
        [SerializeField]
        private StringVariable _correctCode;
        [SerializeField]
        private VoidEvent _unlockDoor, _update;
        [SerializeField]
        private BoolEvent _attemptSuccesful;
        private bool _unlocked;

        void Start() => Clear();

        public void RemoveKey()
        {
            if (_currentInput.Value.Length > 0)
                _currentInput.Value = _currentInput.Value.Remove(_currentInput.Value.Length - 1);
            _update.Raise();
        }

        public void CheckCode()
        {
            if (_currentInput == _correctCode)
            {
                _attemptSuccesful.Raise(true);
                _unlocked = true;
            }
            else
            {
                _attemptSuccesful.Raise(false);
                Clear();
            }
            _update.Raise();
        }

        public void InputKey(string _input)
        {
            print(_input);
            if (_currentInput.Value.Length < _correctCode.Value.Length)
                _currentInput.Value = _currentInput.Value + _input;
            else
                _attemptSuccesful.Raise(false);
            _update.Raise();
        }

        public void Clear()
        {
            _currentInput.Value = "";
            _update.Raise();
        }
    }
}
