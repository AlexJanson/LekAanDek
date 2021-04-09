using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace LekAanDek.WaterCannon
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ShootWater : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _system;
        private ParticleSystem.Particle[] _particles;

        private bool _shooting = false;

        [SerializeField]
        private float _drift = -0.05f;

        [SerializeField]
        private CannonMovement _cm;

        [SerializeField]
        private SteamVR_Action_Boolean _trigger; //Grab Pinch is the trigger, select from inspecter
        [SerializeField]
        private SteamVR_Input_Sources _inputSource = SteamVR_Input_Sources.Any;//which controller
                                                                             // Use this for initialization

        private bool includeChildren = true;

        private void Start()
        {
            _system.Stop(includeChildren, ParticleSystemStopBehavior.StopEmitting);
        }

        private void Update()
        {
            if (_trigger.GetStateDown(_inputSource))
            {
                FiringWater();
            }
        }

        private void FiringWater()
        {

            if(_shooting == true && _cm.puzzleStarted == true)
            {
                _system.Play(includeChildren);
            }
            else
            {
                _system.Stop(includeChildren, ParticleSystemStopBehavior.StopEmitting);
            }
            InitializeIfNeeded();
            // GetParticles is allocation free because we reuse the _particles buffer between updates
            int numParticlesAlive = _system.GetParticles(_particles);

            // Change only the particles that are alive
            for (int i = 0; i < numParticlesAlive; i++)
            {
                _particles[i].velocity += Vector3.up * _drift;
            }

            // Apply the particle changes to the Particle System
            _system.SetParticles(_particles, numParticlesAlive);
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
