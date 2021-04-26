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

        [SerializeField]
        private Transform _joyStickTop;

        private float _horizontalTilt = 0f;
        private float _yRot = 0f;

        [SerializeField]
        private FloatEvent _craneRight;
        [SerializeField]
        private FloatEvent _craneLeft;

        // Rotation constants
        private const int _leftYRot = 270;
        private const int _rightYRot = 90;
        private const float _startingRotation = 270;
        private const float _maxRotation = 359;

        // Update is called once per frame
        void Update()
        {
            _horizontalTilt = this.transform.rotation.eulerAngles.x;
            _yRot = Mathf.Round(this.transform.rotation.eulerAngles.y);

            // IF joystick is facing right
            if (_horizontalTilt > _startingRotation && _horizontalTilt < _maxRotation && _yRot == _leftYRot)
            {
                _horizontalTilt = Mathf.Abs(_horizontalTilt - 360);
                // Turn crane left
                _craneLeft.Raise(_horizontalTilt);
            }
            // IF joystick is facing left
            else if (_horizontalTilt > _startingRotation && _horizontalTilt < _maxRotation && _yRot == _rightYRot)
            {
                // Turn crane right
                _craneRight.Raise(_horizontalTilt);
            }
        }

        // Allow the player to "hold" the joystick and move it around
        private void OnTriggerStay(Collider col)
        {
            if(col.gameObject.tag == "PlayerHand")
            {
                Vector3 targetPos = col.transform.position;
                targetPos.z = transform.position.z;
                transform.LookAt(targetPos);
            }
        }

        // Reset the joystick
        private void OnTriggerExit(Collider other)
        {
            transform.LookAt(this.transform.position + new Vector3(0,10,0));
            _horizontalTilt = 0f;
        }
    }
}
