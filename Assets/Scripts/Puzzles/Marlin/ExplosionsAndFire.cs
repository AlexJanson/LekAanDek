using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LekAanDek.Variables;

namespace LekAanDek.Puzzles.Marlin
{
    /// <summary>
    /// This script is used to activate the fire and explosion particle when a target is hit
    /// </summary>
    public class ExplosionsAndFire : MonoBehaviour
    {

        [SerializeField]
        private BoolVariable[] _targetsHit;
        [SerializeField]
        private BoolVariable _allTargetsHit;

        [SerializeField]
        private Light[] _fireLight;

        [SerializeField]
        private Light _bigFireLight;

        [SerializeField]
        private ParticleSystem[] _fireSystem;
        [SerializeField]
        private ParticleSystem[] _explosionSystem;
        [SerializeField]
        private ParticleSystem _bigFireSystem;
        [SerializeField]
        private ParticleSystem _bigExplosionSystem;

        [SerializeField]
        private AudioSource _explosion;
        [SerializeField]
        private AudioSource _fireAudio;

        private bool[] _hitTarget = new bool[4];
        private bool _shipDestroyed = false;

        private int _targetNumber;

        [SerializeField]
        private float _waitForSinking;
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < _targetsHit.Length; i++)
            {
                _hitTarget[i] = false;
                _fireLight[i].enabled = false;
                _fireSystem[i].Stop();
                _explosionSystem[i].Stop();
            }

            _bigFireLight.enabled = false;
            _bigFireSystem.Stop();
            _bigExplosionSystem.Stop();
        }

        private void Update()
        {
            TargetDestroyed();
        }

        private void TargetDestroyed()
        {

            if (_targetsHit[0].Value && !_hitTarget[0])
                _targetNumber = 0;

            if (_targetsHit[1].Value && !_hitTarget[1])
                _targetNumber = 1;

            if (_targetsHit[2].Value && !_hitTarget[2])
                _targetNumber = 2;

            if (_targetsHit[3].Value && !_hitTarget[3])
                _targetNumber = 3;


            if (_targetsHit[_targetNumber].Value && !_hitTarget[_targetNumber])
            {
                _explosion.Play();
                _explosionSystem[_targetNumber].Play();
                _fireAudio.Play();
                _fireSystem[_targetNumber].Play();
                _fireLight[_targetNumber].enabled = true;
                _hitTarget[_targetNumber] = true;
            }

            if (_allTargetsHit)
                StartCoroutine(DelaySinkingShip());
        }

        private void ShipDestroyed()
        {
            if (_allTargetsHit && !_shipDestroyed)
            {
                _explosion.Play();
                _bigExplosionSystem.Play();
                _fireAudio.Play();
                _bigFireSystem.Play();
                _bigFireLight.enabled = true;
                _shipDestroyed = true;
            }
        }

        IEnumerator DelaySinkingShip()
        {
            yield return new WaitForSeconds(_waitForSinking);
            ShipDestroyed();
        }
    }
}
