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

        private float _durationAudio;

        private static readonly int _hasWon = Animator.StringToHash("hasWon");

        [SerializeField]
        private Teleport[] _teleport;

        [SerializeField]
        private Interactable[] _interactable;

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
        }

        public void LostGame(AudioClip clip)
        {
            foreach(Teleport teleport in _teleport)
            {
                teleport.enabled = false;
            }
            foreach (Interactable interactable in _interactable)
            {
                interactable.enabled = false;
            }
            _loseAudio.clip = clip;
            _durationAudio = _loseAudio.clip.length;
            StartCoroutine(GameLost());
        }

        IEnumerator GameLost()
        {
            _loseAudio.Play();

            yield return new WaitForSeconds(_durationAudio);

            SteamVR_LoadLevel.Begin(_sceneName);
        }
    }
}
