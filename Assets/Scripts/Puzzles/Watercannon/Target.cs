using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LekAanDek.Variables;

namespace LekAanDek.Watercannon
{
    public class Target : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _system;

        private ParticleSystem.Particle[] _particles;

        [SerializeField]
        private float _healthFire;
        [SerializeField]
        private FloatVariable _damage;

        // Update is called once per frame
        void Update()
        {
            ExtinguishFire();
        }

        private void ExtinguishFire()
        {
            InitializeIfNeeded();

            int numParticlesAlive = _system.GetParticles(_particles);

            for (int i = 0; i < numParticlesAlive; i++)
            {
                float distance = Vector3.Distance(_particles[i].position, transform.position);
                if (distance < 1 && distance > -1)
                {
                    _healthFire -= _damage;
                }
            }

            if(_healthFire <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        void InitializeIfNeeded()
        {
            if (_system == null)
                _system = GetComponent<ParticleSystem>();

            if (_particles == null || _particles.Length < _system.main.maxParticles)
                _particles = new ParticleSystem.Particle[_system.main.maxParticles];
        }
    }
}
