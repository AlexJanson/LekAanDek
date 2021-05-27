using UnityEngine;


namespace LekAanDek.Watercannon
{
    /// <summary>
    /// This script calculates the distance between particles and object and changes the size of the object if the particle is too close
    /// </summary>
    public class Target : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _system;

        [SerializeField]
        private GameObject _fire;

        private ParticleSystem.Particle[] _particles;

        [SerializeField]
        private float _healthFire;

        [SerializeField]
        private float _damageToFire = 0.1f;
        [SerializeField]
        private float _hittingRange;
        [Range(0.0f, 0.5f)]
        [SerializeField]
        private float _minSize;
        private float _defaultHealth;

        [SerializeField]
        private int _roundEveryNumberParticle;

        // Update is called once per frame
        private void Start()
        {
            _defaultHealth = _healthFire;
        }

        void Update()
        {
            ExtinguishFire();
        }

        private void ExtinguishFire()
        {

            float tmp = _healthFire / _defaultHealth;
            _fire.transform.localScale = new Vector3(tmp, tmp, tmp);

            if (_fire.transform.localScale.x <= _minSize && _fire.transform.localScale.y <= _minSize && _fire.transform.localScale.z <= _minSize)
                _fire.transform.localScale = new Vector3(_minSize, _minSize, _minSize);

            InitializeIfNeeded();

            int numParticlesAlive = _system.GetParticles(_particles);

            for (int i = 0; i < numParticlesAlive; i += 5)
            {
                float distance = Vector3.Distance(_particles[i].position, transform.position);
                if (distance < _hittingRange && distance > -_hittingRange)
                {
                    _healthFire -= _damageToFire;
                }
            }

            if(_healthFire <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        private void InitializeIfNeeded()
        {
            if (_system == null)
                _system = GetComponent<ParticleSystem>();

            if (_particles == null || _particles.Length < _system.main.maxParticles)
                _particles = new ParticleSystem.Particle[_system.main.maxParticles];
        }
    }
}
