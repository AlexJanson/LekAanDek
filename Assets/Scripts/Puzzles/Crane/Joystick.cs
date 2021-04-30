using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LekAanDek.Events;

namespace LekAanDek.Puzzles.Crane
{
    /// <summary>
    /// This class handles the joystick logic to move the crane left and right
    /// </summary>
    public class Joystick : MonoBehaviour
    {
        private float _horizontalTilt = 0f;

        [SerializeField]
        private FloatEvent _craneRight;
        [SerializeField]
        private FloatEvent _craneLeft;

        // Rotation constants
        private const float _minLeftRot = 15;
        private const float _maxLeftRot = 40;
        private const float _minRightRot = 320;
        private const float _maxRightRot = 345;

        // Update is called once per frame
        void Update()
        {
            _horizontalTilt = this.transform.rotation.eulerAngles.z;

            // IF joystick is facing right
            if (_horizontalTilt < _maxRightRot && _horizontalTilt > _minRightRot)
            {
                _horizontalTilt = Mathf.Abs(_horizontalTilt - 360);
                // Turn crane left
                _craneRight.Raise(_horizontalTilt);
            }
            // IF joystick is facing left
            else if (_horizontalTilt > _minLeftRot && _horizontalTilt < _maxLeftRot)
            {
                // Turn crane right
                _craneLeft.Raise(_horizontalTilt);
            }
        }
    }
}
