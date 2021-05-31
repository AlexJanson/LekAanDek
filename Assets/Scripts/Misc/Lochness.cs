using UnityEngine;

/// <summary>
/// A small script that handles showing a creature when the time is almost running out
/// </summary>
namespace LekAanDek.Secret
{
    public class Lochness : MonoBehaviour
    {
        bool _state;
        [SerializeField]
        private float _multiplier = 500;

        Vector3 _defaultScale;

        void Start()
        {
            _defaultScale = transform.localScale;
        }

        void OnBecameVisible()
        {
            if (_state)
            {
                this.transform.localScale = _defaultScale * _multiplier;
            }
        }

        void OnBecameInvisible()
        {
            if (transform.localScale == _defaultScale * _multiplier)
            {
                _state = false;
                this.transform.localScale = _defaultScale;
            }
        }

        public void Spawn()
        {
            _state = true;
        }
    }
}
