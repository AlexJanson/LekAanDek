using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LekAanDek.Events;

namespace LekAanDek.Puzzles.Marlin
{
    /// <summary>
    /// This class handles the joystick logic to move the crane left and right
    /// </summary>
    public class MarlinJoystick : MonoBehaviour
    {
        //[SerializeField]
        //private Transform _forwardPoint;
        //[SerializeField]
        //private Transform _backwardPoint;
        //[SerializeField]
        //private Transform _rightPoint;
        //[SerializeField]
        //private Transform _leftPoint;
        //[SerializeField]
        //private Transform _forwardRightPoint;
        //[SerializeField]
        //private Transform _forwardLeftPoint;
        //[SerializeField]
        //private Transform _backwardRightPoint;
        //[SerializeField]
        //private Transform _backwardLeftPoint;

        [SerializeField]
        private Transform[] _points;
        [SerializeField]
        private GameObject _marlinCannon;
        [SerializeField]
        private float _speed = 1f;

        private MarlinCannonRotation _marlinMotor;

        private void Start()
        {
            _marlinMotor = _marlinCannon.GetComponentInChildren<MarlinCannonRotation>();
        }

        // Update is called once per frame
        void Update()
        {
            Transform shortest = null;
            float shortestDistance = 999999f;
            foreach(Transform t in _points)
            {
                if(Vector3.Distance(transform.position, t.transform.position) < shortestDistance)
                {
                    shortest = t;
                    shortestDistance = Vector3.Distance(transform.position, t.transform.position);
                }
            }
            if(shortestDistance <= 0.1)
            {
                switch (shortest.gameObject.name)
                {
                    case "FORWARD":
                        _marlinMotor.RotateDown(_speed); 
                        break;
                    case "BACKWARD":
                        _marlinMotor.RotateUp(_speed);
                        break;
                    case "RIGHT":
                        _marlinMotor.RotateRight(_speed);
                        break;
                    case "LEFT":
                        _marlinMotor.RotateLeft(_speed);
                        break;
                    case "FR":
                        _marlinMotor.RotateDown(_speed / 2);
                        _marlinMotor.RotateRight(_speed / 2);
                        break;
                    case "FL":
                        _marlinMotor.RotateDown(_speed / 2);
                        _marlinMotor.RotateLeft(_speed / 2);
                        break;
                    case "BR":
                        _marlinMotor.RotateUp(_speed / 2);
                        _marlinMotor.RotateRight(_speed / 2);
                        break;
                    case "BL":
                        _marlinMotor.RotateUp(_speed / 2);
                        _marlinMotor.RotateLeft(_speed / 2);
                        break;
                    default:
                        Debug.Log("uhhh this shouldn't be possible");
                        break;
                }
            }
        }
    }
}
