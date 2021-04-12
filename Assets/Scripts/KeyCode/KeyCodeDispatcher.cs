using UnityEngine;
using LekAanDek.Events;
using Valve.VR.InteractionSystem;

namespace LekAanDek.KeyCode
{
    public class KeyCodeDispatcher : MonoBehaviour
    {
        public StringEvent _keyInputString;
        private BoolEvent _correctAttemptBool;
        public void Dispatch(string input)
        {
            _keyInputString.Raise(input);
        }
        public void Dispatch(bool input)
        {
            _correctAttemptBool.Raise(input);
        }
    }
}
