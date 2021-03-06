using System.Collections;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;
using LekAanDek.Variables;

namespace LekAanDek.EndGame
{
    /// <summary>
    /// This script checks if the player has won or lost the game 
    /// </summary>
    public class EndGame : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        private bool _won;

        [SerializeField]
        private float _waitForReset = 10.0f;

        private static readonly int _hasWon = Animator.StringToHash("hasWon");

        [SerializeField]
        private Teleport[] _teleport;

        [SerializeField]
        private Interactable[] _interactable;

        [SerializeField]
        private AudioSource _winAudio;
        [SerializeField]
        private AudioSource _loseAudio;

        private string _sceneName;

        [SerializeField]
        private BoolVariable _countingDown;

        private void Start()
        {
            _interactable = FindObjectsOfType<Interactable>();
            _teleport = FindObjectsOfType<Teleport>();
            _sceneName = SceneManager.GetActiveScene().name;
        }

        public void WonGame()
        {
            _countingDown.Value = false;
            _won = true;
            _animator.SetBool(_hasWon, _won);
            StartCoroutine(GameWon());
        }

        public void LostGame()
        {
            foreach(Teleport teleport in _teleport)
            {
                teleport.enabled = false;
            }
            foreach (Interactable interactable in _interactable)
            {
                interactable.enabled = false;
            }
            
            StartCoroutine(GameLost());
        }

        IEnumerator GameWon()
        {
            if (_winAudio != null)
            {
                _winAudio.Play();
            }
            yield return new WaitForSeconds(_waitForReset);

            SteamVR_LoadLevel.Begin(_sceneName);
        }

        IEnumerator GameLost()
        {
            if (_loseAudio != null)
            {
                _loseAudio.Play();
            }
            yield return new WaitForSeconds(_waitForReset);

            SteamVR_LoadLevel.Begin(_sceneName);
        }
    }
}
