using LekAanDek.Variables;
using LekAanDek.Events;
using UnityEngine;
using Valve.VR;

namespace LekAanDek.Puzzles.WaterCannon
{
    /// <summary>
    /// This class handles the movement of the water cannon
    /// </summary>
    public class CannonMovement : MonoBehaviour
    {
        [SerializeField]
        private VoidEvent _startedPuzzle;
        [SerializeField]
        private BoolVariable _startedWCPuzzle;

        [SerializeField]
        private GameObject[] _hands;
        [SerializeField]
        private GameObject[] _handles;
        [SerializeField]
        private GameObject _waterCannon;
        [SerializeField]
        private GameObject _rotationTarget;

        [Range(0.0f, 1.0f)]
        [SerializeField]
        private float _posY, _posZ;

        [SerializeField]
        private float _rotSpeed = 100.0f;

        private Quaternion _lookRotation;

        private Vector3 _direction;

        [SerializeField]
        private SteamVR_Action_Boolean _grabPinch; 

        [SerializeField]
        private SteamVR_Input_Sources _leftHand = SteamVR_Input_Sources.LeftHand;
        [SerializeField]
        private SteamVR_Input_Sources _rightHand = SteamVR_Input_Sources.RightHand;

        private void Start() => _startedWCPuzzle.Value = false;

        private bool _started;

        private void Update()
        {
            float _leftDist = Vector3.Distance(_hands[0].transform.position, _handles[0].transform.position);
            float _rightDist = Vector3.Distance(_hands[1].transform.position, _handles[1].transform.position);

            //This checks if the player is pressing the grib button and if the players hands are close enough to the handel
            _startedWCPuzzle.Value = (_grabPinch.GetState(_leftHand) && _grabPinch.GetState(_rightHand) && _leftDist < 0.7f && _rightDist < 0.7f) ? true : false;
      
            if (_startedWCPuzzle.Value == true)
                RotatingCannon();
        }

        // in this function an gameobject will be placed between the left and the right hand and it wil stay in between them
        // the water cannon wil rotate towards the gameobject so that it will look like you are rotating the cannon with your hands
        private void RotatingCannon()
        {
            if (!_started)
            {
                _started = true;
                _startedPuzzle.Raise();
            }

            _rotationTarget.transform.position = 0.5f * (_hands[0].transform.position + _hands[1].transform.position);

            _rotationTarget.transform.position = new Vector3(_rotationTarget.transform.position.x, _rotationTarget.transform.position.y - _posY, _rotationTarget.transform.position.z - _posZ);

            _direction = (_rotationTarget.transform.position - _waterCannon.transform.position).normalized;

            _lookRotation = Quaternion.LookRotation(_direction);

            _waterCannon.transform.rotation = Quaternion.RotateTowards(_waterCannon.transform.rotation, _lookRotation, Time.deltaTime * _rotSpeed);
        }
    }
}
