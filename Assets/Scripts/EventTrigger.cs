using UnityEngine;
using UnityEngine.Events;

namespace LekAanDek.Trackers
{
    /// <summary>
    /// This script allows for executing things in certain trigger zones
    /// </summary>
    public class EventTrigger : MonoBehaviour
    {
        [Header("Trigger")]
        private bool _triggered = false;
        [SerializeField]
        [Tooltip("Possible functions that could be executed when hint appeared.")]
        private UnityEvent _response;
        [SerializeField]
        [Tooltip("The audiosource of the hint.")]
        private AudioSource _audio;
        [SerializeField]
        [Tooltip("The greeting clip for the area.")]
        private AudioClip _triggerClip;


        [Header("Puzzle hint")]
        [SerializeField]
        [Tooltip("Enable hint after time.")]
        private bool _hintEnabled;
        [SerializeField]
        [Tooltip("Repeat hint until done properly.")]
        private bool _repeat = false;
        [SerializeField]
        [Tooltip("Possible functions that could be executed when hint appeared.")]
        private UnityEvent _hintResponse;
        private bool _hintTracking, _hintNeeded = true;
        public float _time;
        [SerializeField]
        [Tooltip("Target time before audio is being played in seconds.")]
        private float _timeBeforeHint = 30;
        [SerializeField]
        [Tooltip("The hint clip.")]
        private AudioClip _hintClip;

        //Check if player entered the trigger and start tracking
        void OnTriggerEnter(Collider other)
        {
            if (!_triggered)
            {
                _triggered = true;
                if (_response != null) _response.Invoke();
                if (_audio) PlayClip(_triggerClip);
                if (_hintEnabled) _hintTracking = true;
            }
        }

        //Track time whenever needed
        private void Update()
        {
            if (_hintTracking && _hintNeeded)
            {
                _time += Time.deltaTime;
                if (_time >= _timeBeforeHint)
                {
                    if (_hintResponse != null) _hintResponse.Invoke();
                    if (_audio) PlayClip(_hintClip);
                    if (!_repeat) ConditionsMet();
                    else _time = 0;
                }
            }
        }

        //Play instructions
        public void PlayClip(AudioClip clip)
        {
            _audio.clip = clip;
            _audio.Play();
        }

        //If the conditions are met disable tracking
        public void ConditionsMet()
        {
            _hintNeeded = false;
            this.enabled = false;
        }
    }
}
