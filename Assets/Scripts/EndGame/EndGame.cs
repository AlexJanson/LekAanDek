using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LekAanDek.EndGame
{
    /// <summary>
    /// This script checks if the player has won or lost the game 
    /// </summary>
    public class EndGame : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        private bool _hasWon;

        private static readonly int HasWon = Animator.StringToHash("hasWon");

        [SerializeField]
        private AudioSource _loseAudio;

        // Update is called once per frame
        void Update()
        {
        
        }

        public void WonGame()
        {
            _hasWon = true;
            _animator.SetBool(HasWon, _hasWon);
        }

        public void LostGame(AudioClip clip)
        {
            _loseAudio.clip = clip;
            _loseAudio.Play();
        }
    }
}
