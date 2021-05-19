using System.Collections;
using LekAanDek.Variables;
using LekAanDek.Events;
using UnityEngine;

namespace LekAanDek.Intro
{
    /// <summary>
    /// Handles the intro animation and starting the game.
    /// </summary>
    public class GameIntro : MonoBehaviour
    {
        public GameIntroSO gameIntroSo;
        public BoolVariable gameHasStarted;
        public VoidEvent gameStart;
        
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

        // This is to loop over the parts in the SO and play the right animation + audio clip
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

            // Reseting the animation to the Idle state
            _animator.SetInteger(AnimationState,(int)OfficerAnimation.Idle);
            gameHasStarted.Value = true;
            gameStart.Raise();
        }

        void PlayAudioClip(AudioClip clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}
