using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LekAanDek.Controls;

namespace LekAanDek.Puzzles.Crane
{
    /// <summary>
    /// This class controls the left and right rotation of the crane
    /// </summary>
    public class CraneController : JoystickControllable
    {
        [Range(0.0f, 10f)]
        [SerializeField]
        private float _speed = 1.5f;

        private Transform _crane;

        private AudioSource _audioSource;

        // Start is called before the first frame update
        void Start()
        {
            _crane = GetComponent<Transform>();
            _audioSource = GetComponent<AudioSource>();
        }

        public override void RotateYaw(float amount)
        {
            _audioSource.Play();
            _crane.Rotate(new Vector3(0, _speed * Time.deltaTime * amount, 0));
            
        }
    }
}
