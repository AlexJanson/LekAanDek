using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LekAanDek.Variables;

namespace LekAanDek.Puzzles.Marlin
{
    public class ExplosionsAndFire : MonoBehaviour
    {

        [SerializeField]
        private BoolVariable _targetHit;
        [SerializeField]
        private BoolVariable _allTargetsHit;

        [SerializeField]
        private Light _fireLight;

        [SerializeField]
        private Light _bigFireLight;

        [SerializeField]
        private ParticleSystem _fireSystem;
        [SerializeField]
        private ParticleSystem _explosionSystem;
        [SerializeField]
        private ParticleSystem _bigFireSystem;
        [SerializeField]
        private ParticleSystem _bigExplosionSystem;

        [SerializeField]
        private AudioSource _explosion;
        [SerializeField]
        private AudioSource _fireAudio;

        private bool smallDamage = false;
        // Start is called before the first frame update
        void Start()
        {
            _fireLight.enabled = false;
            _bigFireLight.enabled = false;
            _fireSystem.Stop();
            _bigFireSystem.Stop();
            _bigExplosionSystem.Stop();
            _explosionSystem.Stop();
        }

        private void Update()
        {
            TargetDestroyed();
        }

        private void TargetDestroyed()
        {
         
            if (_targetHit.Value)
            {
                _explosion.transform.parent = null;
                _explosionSystem.transform.parent = null;
                _fireAudio.transform.parent = null;
                _fireSystem.transform.parent = null;
                _fireLight.transform.parent = null;

                _explosion.Play();
                _explosionSystem.Play();
                StartCoroutine(DelayFire());
            }

            if (Input.GetKeyDown("b"))
            {
                _allTargetsHit.Value = true;
                if (_allTargetsHit)
                {
                    _explosion.Play();
                    _bigExplosionSystem.Play();
                    StartCoroutine(DelayBigFire());
                }
            }
        }

        private void ShipDestroyed()
        {

        }

        IEnumerator DelayFire()
        {
            yield return new WaitForSeconds(0.2f);
            _fireAudio.Play();
            _fireSystem.Play();
            _fireLight.enabled = true;
        }

        IEnumerator DelayBigFire()
        {
            yield return new WaitForSeconds(0.2f);
            _fireAudio.Play();
            _bigFireSystem.Play();
            _bigFireLight.enabled = true;
        }
    }
}
