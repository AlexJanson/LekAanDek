using System;
using UnityEngine;
using UnityEditor;
using LekAanDek.Controls;
using Valve.VR;
using LekAanDek.Events;

namespace LekAanDek.Controls
{
    /// <summary>
    /// One joystick to use for every usecase
    /// </summary>
    public class UniversalJoystick : MonoBehaviour
    {
        [SerializeField]
        private VoidEvent _interactedInformer;
        private bool _interacted;
        [SerializeField]
        private Transform _joystickTop;
        [SerializeField]
        private Transform _joystickDefaultPosition;
        [SerializeField]
        [Range(0, 5f)]
        private float _speed = 0.1f;
        [SerializeField]
        [Range(0.01f, 0.2f)]
        private float _deadzone = 0.1f;
        [SerializeField]
        private joyStickType _type = joyStickType.horizontal;

        [SerializeField]
        private SteamVR_Action_Boolean _trigger;

        [SerializeField]
        private JoystickControllable _controlledObject;

        // Update is called once per frame
        void Update()
        {
            // IF joystick is of type vertical or dual axis
            if (_type == joyStickType.vertical || _type == joyStickType.dualAxis)
            {
                // VERTICAL
                float _verticalTilt = _joystickTop.localToWorldMatrix.GetPosition().z - _joystickDefaultPosition.localToWorldMatrix.GetPosition().z;
                // IF joystick is facing up
                if (_verticalTilt > _deadzone)
                {
                    // Rotate up
                    _controlledObject.RotateUp(_verticalTilt * _speed);
                }
                // IF joystick is facing down
                else if (_verticalTilt < _deadzone * -1)
                {
                    _verticalTilt = Math.Abs(_verticalTilt);
                    // Rotate down
                    _controlledObject.RotateDown(_verticalTilt * _speed);

                }
            }

            // IF joystick is of type horizontal or dual axis
            if (_type == joyStickType.horizontal || _type == joyStickType.dualAxis)
            {
                // HORIZONTAL
                float _horizontalTilt = _joystickTop.localToWorldMatrix.GetPosition().x - _joystickDefaultPosition.localToWorldMatrix.GetPosition().x;
                // IF joystick is facing left
                if (_horizontalTilt < _deadzone * -1)
                {
                    // Rotate left
                    _horizontalTilt = Math.Abs(_horizontalTilt);
                    _controlledObject.RotateLeft(_horizontalTilt * _speed);
                }
                // IF joystick is facing right
                else if (_horizontalTilt > _deadzone)
                {
                    // Rotate right
                    _controlledObject.RotateRight(_horizontalTilt * _speed);
                }
            }

            // Snap joystick back to starting position when grip is released
            if (!_trigger.GetState(SteamVR_Input_Sources.Any))
            {
                transform.LookAt(_joystickDefaultPosition, transform.up);
            }

        }

        private void OnTriggerStay(Collider col)
        {
            if (!_interacted && _interactedInformer != null)
            {
                _interacted = true; _interactedInformer.Raise();
            }
            if (col.CompareTag("PlayerHand") && _trigger.GetState(SteamVR_Input_Sources.Any))
            {
                Vector3 targetPosition = new Vector3(0, 0, 0);
                switch (_type)
                {
                    case joyStickType.horizontal:
                        targetPosition = new Vector3(col.transform.position.x, col.transform.position.y, transform.position.z);
                        break;
                    case joyStickType.vertical:
                        targetPosition = new Vector3(transform.position.x, col.transform.position.y, col.transform.position.z);
                        break;
                    case joyStickType.dualAxis:
                        targetPosition = col.transform.position;
                        break;
                }
                transform.LookAt(targetPosition, transform.up);
            }
            else if (col.CompareTag("PlayerHand") && !_trigger.GetState(SteamVR_Input_Sources.Any))
            {
                transform.LookAt(_joystickDefaultPosition, transform.up);
            }

        }

        private void OnTriggerExit()
        {
            if (!_trigger.GetState(SteamVR_Input_Sources.Any))
            {
                transform.LookAt(_joystickDefaultPosition, transform.up);
            }

        }
    }

    enum joyStickType
    {
        horizontal,
        vertical,
        dualAxis
    }
}