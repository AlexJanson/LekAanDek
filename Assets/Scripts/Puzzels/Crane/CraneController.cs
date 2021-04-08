using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LekAanDek.CranePuzzle
{
    /// <summary>
    /// This class controls the left and right rotation of the crane
    /// </summary>
    public class CraneController : MonoBehaviour
    {
        [Range(0.0f, 10f)]
        [SerializeField]
        private float _speed = 1f;

        private Transform _crane;

        // Start is called before the first frame update
        void Start()
        {
            _crane = this.GetComponent<Transform>();
        }

        // Rotates the crane left
        public void RotateLeft(float inputSpeed)
        {
            _crane.Rotate(new Vector3(0, -_speed, 0));
        }

        // Rotates the crane right
        public void RotateRight(float inputSpeed)
        {
            _crane.Rotate(new Vector3(0, _speed, 0));
        }
    }
}
