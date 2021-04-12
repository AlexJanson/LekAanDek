using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace LekAanDek.WaterCannon
{
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

        private float _rotSpeed = 50.0f;

        private Quaternion _lookRotation;
        private Quaternion _lookRotationLeftHandle;
        private Quaternion _lookRotationRightHandle;
        private Vector3 _direction;
        private Vector3 _directionLeftHandle;
        private Vector3 _directionRightHandle;

        [SerializeField]
        private SteamVR_Action_Boolean _grabPinch; //Grab Pinch is the trigger, select from inspecter
        [SerializeField]
        private SteamVR_Input_Sources _leftHand = SteamVR_Input_Sources.LeftHand;
        [SerializeField]
        private SteamVR_Input_Sources _rightHand = SteamVR_Input_Sources.RightHand;

        private void Start()
        {
            _rotationTarget.SetActive(false);
        }

        private void Update()
        {

            if (_grabPinch.GetStateDown(_leftHand) && _grabPinch.GetStateDown(_rightHand))
            {
                puzzleStarted = true;
            }
            else
            {
               //puzzleStarted = false;
            }

            float _leftDist = Vector3.Distance(_hands[0].transform.position, _handles[0].transform.position);
            float _rightDist = Vector3.Distance(_hands[1].transform.position, _handles[1].transform.position);


            if (_leftDist < 0.55f && _rightDist < 0.55f && puzzleStarted == true)
                RotatingCannon();
        }

        private void RotatingCannon()
        {  
    
            _rotationTarget.SetActive(true);

            _rotationTarget.transform.position = 0.5f * (_hands[0].transform.position + _hands[1].transform.position);

            _direction = (_rotationTarget.transform.position - _waterCannon.transform.position).normalized;

            _lookRotation = Quaternion.LookRotation(_direction);

            _waterCannon.transform.rotation = Quaternion.RotateTowards(_waterCannon.transform.rotation, _lookRotation, Time.deltaTime * _rotSpeed);

        }
    }
}
