using System;
using UnityEngine;
using UnityEditor;
using LekAanDek.Puzzles.Marlin;
using LekAanDek.Puzzles.Crane;

/// <summary>
/// One joystick to use for every usecase
/// </summary>
public class UniversalJoystick : MonoBehaviour
{
	[SerializeField]
	private Transform _joystickTop;
	[SerializeField]
	private Transform _joystickDefaultPosition;
	[SerializeField]
	private float _speed = 0.1f;
	[SerializeField]
	[Range(0.01f, 0.2f)]
	private float _deadzone = 0.1f;
	[SerializeField]
	private joyStickType _type = joyStickType.horizontal;

	[SerializeField]
	private MarlinCannonRotation _marlinController;
	[SerializeField]
	private CraneController _craneController;

	// Update is called once per frame
	void Update()
	{
		// IF joystick is of type vertical or dual axis
		if (_type == joyStickType.vertical || _type == joyStickType.dualAxis)
        {
			// VERTICAL
			float _verticalTilt = _joystickDefaultPosition.localToWorldMatrix.GetPosition().z - _joystickTop.localToWorldMatrix.GetPosition().z;
            // IF joystick is facing down
            if (_verticalTilt > _deadzone)
            {
				// Rotate down
				if (_marlinController != null)
					_marlinController.RotateDown(_verticalTilt);
            }
            // IF joystick is facing up
            else if (_verticalTilt < _deadzone * -1)
            {
				_verticalTilt = Math.Abs(_verticalTilt);
				// Rotate up
				if (_marlinController != null)
					_marlinController.RotateUp(_verticalTilt);

			}
        }

		// IF joystick is of type horizontal or dual axis
		if (_type == joyStickType.horizontal || _type == joyStickType.dualAxis)
        {
			// HORIZONTAL
			float _horizontalTilt = _joystickDefaultPosition.localToWorldMatrix.GetPosition().x - _joystickTop.localToWorldMatrix.GetPosition().x;
			// IF joystick is facing left
			if (_horizontalTilt < _deadzone * -1)
			{
				_horizontalTilt = Math.Abs(_horizontalTilt);
				// Rotate left
				if (_marlinController != null)
					_marlinController.RotateLeft(_horizontalTilt);
				if(_craneController != null)
					_craneController.RotateLeft(_horizontalTilt);
			}
			// IF joystick is facing right
			else if (_horizontalTilt > _deadzone)
			{
				// Rotate right
				if (_marlinController != null)
					_marlinController.RotateRight(_horizontalTilt);
				if(_craneController != null)
					_craneController.RotateRight(_horizontalTilt);
			}
		}

	}

	private void OnTriggerStay(Collider col)
	{
		if (col.CompareTag("PlayerHand"))
		{
			Vector3 targetPosition = new Vector3(0,0,0);
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
	}

    private void OnTriggerExit()
    {
		transform.LookAt(_joystickDefaultPosition, transform.up);
    }
}

enum joyStickType
{
	horizontal,
	vertical,
	dualAxis
}
