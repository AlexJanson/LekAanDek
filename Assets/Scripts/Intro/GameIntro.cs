using System.Collections;
using LekAanDek.Variables;
using UnityEngine;

namespace LekAanDek.Intro
{
    public class GameIntro : MonoBehaviour
    {
        public GameIntroSO gameIntroSo;
        public BoolVariable gameHasStarted;
        
        [Tooltip("Source where the audio clips will be played")]
        [SerializeField]
        private AudioSource _audioSource;

        private Animator _animator;
        private static readonly int AnimationState = Animator.StringToHash("AnimationState");

        private void Start()
        {
            gameHasStarted.Value = false;
            _animator = GetComponent<Animator>();
        }

        public void StartIntro() => StartCoroutine(IntroParts());

        IEnumerator IntroParts()
        {
            foreach (var part in gameIntroSo.introParts)
            {
                PlayAudioClip(part.clip);
                _animator.SetInteger(AnimationState,(int)part.animation);
                yield return new WaitWhile(() => _audioSource.isPlaying);
                yield return new WaitForSeconds(part.waitDuration);
                _animator.SetInteger(AnimationState,(int)OfficerAnimation.Idle);
            }

            _animator.SetInteger(AnimationState,(int)OfficerAnimation.Idle);
            gameHasStarted.Value = true;
        }

        void PlayAudioClip(AudioClip clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}
