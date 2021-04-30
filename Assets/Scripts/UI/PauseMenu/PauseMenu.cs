using LekAanDek.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;
using LekAanDek.Variables;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using Valve.VR.Extras;

namespace LekAanDek.UI
{
    public class PauseMenu : MonoBehaviour
    {

        [SerializeField]
        private Canvas _pauseMenuCs;

        [SerializeField]
        private Teleport[] _teleport;

        [SerializeField]
        private Interactable[] _interactable;

        [SerializeField]
        private BoolVariable _countingDown;
        [SerializeField]
        private BoolVariable _startedWcPuzzle;

        [SerializeField]
        private BoolEvent _pausedGame;

        [SerializeField]
        private Collider[] _canvasColliders;

        private int _OnOffInt = 0;
        
        [SerializeField]
        private AudioSource _audio;

        [Range(0, 1)]
        [SerializeField]
        private float _minVolume;

        private string _sceneName;

        [SerializeField]
        private SteamVR_Action_Boolean _clickAction;

        [SerializeField]
        private Transform _camTransform;

        [SerializeField]
        private Transform _canvasTransform;

        [SerializeField]
        private SteamVR_Input_Sources _rightHand = SteamVR_Input_Sources.RightHand;

        [SerializeField]
        private GameObject _laserPointer;

        // Start is called before the first frame update
        void Start()
        {
            _laserPointer.SetActive(false);

            _sceneName = SceneManager.GetActiveScene().name;

            _canvasColliders = _pauseMenuCs.GetComponentsInChildren<Collider>();
            _teleport = FindObjectsOfType<Teleport>();
            _interactable = FindObjectsOfType<Interactable>();

            foreach (Collider collider in _canvasColliders)
            {
                collider.enabled = false;
            }

            _pauseMenuCs.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {

            _canvasTransform.position = new Vector3(_canvasTransform.position.x, _camTransform.position.y, _camTransform.position.z);
            _canvasTransform.rotation = Quaternion.Euler(_canvasTransform.rotation.x, _camTransform.eulerAngles.y + 90, _canvasTransform.rotation.z);


            if (_clickAction.GetStateDown(_rightHand) == true || Input.GetKeyDown("p"))
            {
                _OnOffInt++;

                if (_OnOffInt == 1)
                {
                    GamePaused();
                }
                else if (_OnOffInt == 2)
                {
                    ContinueGame();
                    _OnOffInt = 0;
                }
            }
        }

        private void GamePaused()
        {
            _laserPointer.SetActive(true);

            _audio.volume = _minVolume;

            _pausedGame.Raise(true);

            foreach(Collider collider in _canvasColliders)
            {
                collider.enabled = true;
            }

            _countingDown.Value = false;
            _startedWcPuzzle.Value = false;
      
            for (int i = 0; i < _teleport.Length; i++)
            {
                _teleport[i].enabled = false;
            }
            for (int j = 0; j < _interactable.Length; j++)
            {
                _interactable[j].enabled = false;
            }

            _pauseMenuCs.enabled = true;
        }

        public void RestartGame()
        {
            SteamVR_LoadLevel.Begin(_sceneName);
        }

        public void ContinueGame()
        {
            _laserPointer.SetActive(false);

            _audio.volume = 1;

            _pausedGame.Raise(false);

            foreach (Collider collider in _canvasColliders)
            {
                collider.enabled = false;
            }

            _countingDown.Value = true;
            _startedWcPuzzle.Value = true;

            for (int i = 0; i < _teleport.Length; i++)
            {
                _teleport[i].enabled = true;
            }
            for (int j = 0; j < _interactable.Length; j++)
            {
                _interactable[j].enabled = true;
            }

            _pauseMenuCs.enabled = false;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
