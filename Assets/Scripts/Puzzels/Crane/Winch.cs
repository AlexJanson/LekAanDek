using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LekAanDek.CranePuzzle
{
    /// <summary>
    /// This class handles all the winching logic for the crane, moving the object up and down
    /// </summary>
    public class Winch : MonoBehaviour
    {
        [SerializeField]
        private Transform _attachedObject;
        [SerializeField]
        private float _maxLimit = 6f;
        [SerializeField]
        private float _minLimit = 0.1f;
        [Range(0.0f, 1f)]
        [SerializeField]
        private float _speed = 1f;

        private bool _raising = false;
        private bool _lowering = false;

        LineRenderer _lr;
        ConfigurableJoint _joint;

        // Start is called before the first frame update
        void Start()
        {
            _lr = this.GetComponent<LineRenderer>();
            _joint = _attachedObject.GetComponent<ConfigurableJoint>();
        }

        // Update is called once per frame
        void Update()
        {
            // Raises the winch
            if (_raising)
            {
                SoftJointLimit limit = _joint.linearLimit;
                limit.limit = limit.limit -= _speed;
                // Limits the winch to a specified length
                if ((limit.limit -= _speed) >= _minLimit)
                {
                    _joint.linearLimit = limit;
                }
            }
            // Lowers the winch
            else if (_lowering)
            {
                SoftJointLimit limit = _joint.linearLimit;
                limit.limit = limit.limit += _speed;
                // Limits the winch to a specified length
                if ((limit.limit += _speed) <= _maxLimit)
                {
                    _joint.linearLimit = limit;
                }
            }

            UpdateLine();
        }

        public void StartRaising()
        {
            _raising = true;
            _lowering = false;
        }

        public void StartLowering()
        {
            _raising = false;
            _lowering = true;
        }

        public void StopWinching()
        {
            _raising = false;
            _lowering = false;  
        }

        // Updates the line renderer to always be attached to the attached object
        void UpdateLine()
        {
            // Set starting position
            _lr.SetPosition(0, this.transform.position);
            // Set end position
            _lr.SetPosition(1, _attachedObject.position);
        }
    }
}
