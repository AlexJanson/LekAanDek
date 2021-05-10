using System;
using LekAanDek.Variables;
using UnityEngine;

namespace LekAanDek.Puzzles.Marlin
{
    /// <summary>
    /// Script that's on the projectiles that the Marlin cannon shoots.
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        public FloatReference speed;
        
        private Rigidbody _rigidbody;
        
        private void Start() => _rigidbody = GetComponent<Rigidbody>();

        private void Update() => _rigidbody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    }
}
