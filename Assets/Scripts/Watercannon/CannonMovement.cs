using System.Collections;
using System.Collections.Generic;
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
        private GameObject[] _hands;
        [SerializeField]
        private GameObject[] _handles;
        [SerializeField]
        private GameObject _waterCannon;
        [SerializeField]
        private GameObject _rotationTarget;

        public bool puzzleStarted = false;

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

        private void Update()
        {
            float _leftDist = Vector3.Distance(_hands[0].transform.position, _handles[0].transform.position);
            float _rightDist = Vector3.Distance(_hands[1].transform.position, _handles[1].transform.position);

            //This checks if the player is pressing the grib button and if the players hands are close enough to the handels
            if (_grabPinch.GetState(_leftHand) && _grabPinch.GetState(_rightHand) && _leftDist < 0.7f && _rightDist < 0.7f)
            {
                puzzleStarted = true;
            }
            else
            {
               puzzleStarted = false;
            }

            if (puzzleStarted == true)
                RotatingCannon();
        }

        // in this function an transform will be placed between the left and the right hand and it wil stay in between them
        // the water cannon wil rotate towards the transform so that it will look like you are rotating the cannon with your hands
        private void RotatingCannon()
        {  
            _rotationTarget.transform.position = 0.5f * (_hands[0].transform.position + _hands[1].transform.position);

            _direction = (_rotationTarget.transform.position - _waterCannon.transform.position).normalized;

            _lookRotation = Quaternion.LookRotation(_direction);

            _waterCannon.transform.rotation = Quaternion.RotateTowards(_waterCannon.transform.rotation, _lookRotation, Time.deltaTime * _rotSpeed);
        }
    }
}
