using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LekAanDek.Puzzles.Crane
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

        // Sound
        [SerializeField]
        private AudioClip _raisingSound;
        [SerializeField]
        private AudioClip _loweringSound;

        private bool _raising = false;
        private bool _lowering = false;

        LineRenderer _lr;
        ConfigurableJoint _joint;
        AudioSource _audioSource;

        // Start is called before the first frame update
        void Start()
        {
            _lr = GetComponent<LineRenderer>();
            _joint = _attachedObject.GetComponent<ConfigurableJoint>();
            _audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            // Raises the winch
            if (_raising)
            {
                // Audio
                if (!_audioSource.isPlaying)
                    _audioSource.PlayOneShot(_raisingSound);

                SoftJointLimit limit = _joint.linearLimit;
                limit.limit = limit.limit -= _speed;
                // Limits the winch to a specified length
                if ((limit.limit -= _speed) >= _minLimit)
                {
                    _joint.linearLimit = limit;
                }
                else
                {
                    StopWinching();
                    Debug.Log("wut");
                }
            }
            // Lowers the winch
            else if (_lowering)
            {
                // Audio
                if (!_audioSource.isPlaying)
                    _audioSource.PlayOneShot(_loweringSound);

                SoftJointLimit limit = _joint.linearLimit;
                limit.limit = limit.limit += _speed;
                // Limits the winch to a specified length
                if ((limit.limit += _speed) <= _maxLimit)
                {
                    _joint.linearLimit = limit;
                }
                else
                {
                    StopWinching();
                    Debug.Log("wut");
                }
            }
            else
            {
                _audioSource.Stop();
            }

            UpdateLine();
        }

        public void StartRaising()
        {
            _raising = true;
            _lowering = false;
            _audioSource.Stop();
        }

        public void StartLowering()
        {
            _raising = false;
            _lowering = true;
            _audioSource.Stop();
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
