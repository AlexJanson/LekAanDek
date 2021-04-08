using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LekAanDek.Events;

namespace LekAanDek.CranePuzzle
{
    /// <summary>
    /// This class handles the winching events for the winch class
    /// </summary>
    public class WinchEffect : MonoBehaviour
    {
        [SerializeField]
        private VoidEvent _winchUp;

        [SerializeField]
        private VoidEvent _winchDown;

        [SerializeField]
        private VoidEvent _winchStop;

        public void StartWinchUp()
        {
            _winchUp.Raise();
        }

        public void StartWinchDown()
        {
            _winchDown.Raise();
        }

        public void OnButtonUp()
        {
            _winchStop.Raise();
        }
    }
}
