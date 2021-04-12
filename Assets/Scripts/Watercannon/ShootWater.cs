using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace LekAanDek.Puzzles.WaterCannon
{
    /// <summary>
    /// This class checks if the player is pressing the trigger button and shoots water if he does
    /// </summary>
    [RequireComponent(typeof(ParticleSystem))]
    public class ShootWater : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _system;

        private ParticleSystem.Particle[] _particles;

        [SerializeField]
        private float _drift = -0.05f;

        [SerializeField]
        private CannonMovement _cm;

        [SerializeField]
        private SteamVR_Action_Boolean _trigger;
        [SerializeField]
        private SteamVR_Input_Sources _inputSource = SteamVR_Input_Sources.Any;//which controller
                                                                             // Use this for initialization
        private bool _includeChildren = true;

        private void Start()
        {
            _system.Stop(_includeChildren, ParticleSystemStopBehavior.StopEmitting);
        }

        private void Update()
        {
            if (_trigger.GetState(_inputSource))
            {
                FiringWater();
            }
        }
        //In this function the particle system wil be called to play and fire particles that with go down at a given speed
        private void FiringWater()
        {

            if(_cm.puzzleStarted == true)
            {
                _system.Play(_includeChildren);
            }
            else
            {
                _system.Stop(_includeChildren, ParticleSystemStopBehavior.StopEmitting);
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
