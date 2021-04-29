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
        private Hand[] _hands;

        [SerializeField]
        private GameObject _joyStick;

        [SerializeField]
        private Collider _joyStickHead;

        [SerializeField]
        private GameObject _keyPad;

        [SerializeField]
        private BoolVariable _timerPaused;
        [SerializeField]
        private BoolVariable _startedWcPuzzle;

        private Quaternion _joyStickRot;

        [SerializeField]
        private BoolEvent _pausedGame;

        [SerializeField]
        private Collider[] _canvasColliders;

        private int _testInt = 0;
        
        [SerializeField]
        private AudioSource _audio;

        [Range(0, 1)]
        [SerializeField]
        private float _minVolume;

        private string _sceneName;

        [SerializeField]
        private SteamVR_Action_Boolean _clickAction;

        [SerializeField]
        private SteamVR_Input_Sources _rightHand = SteamVR_Input_Sources.RightHand;

        // Start is called before the first frame update
        void Start()
        {
            /* _joyStickRot = _joyStick.transform.rotation;
             _hands = FindObjectsOfType<Hand>();
             _teleport = FindObjectsOfType<Teleport>();
             _interactable = FindObjectsOfType<Interactable>();*/

            _sceneName = SceneManager.GetActiveScene().name;

            _canvasColliders = _pauseMenuCs.GetComponentsInChildren<Collider>();

            foreach (Collider collider in _canvasColliders)
            {
                collider.enabled = false;
            }

            _pauseMenuCs.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (_clickAction.GetState(_rightHand) == true)
            {
                _testInt++;

                if (_testInt == 1)
                {
                    GamePaused();
                }
                else if (_testInt == 2)
                {
                    ContinueGame();
                    _testInt = 0;
                }
            }
        }

        private void GamePaused()
        {

            _audio.volume = _minVolume;

            _pausedGame.Raise(true);
            
            //var col = _keyPad.GetComponentsInChildren<Collider>();

            //Time.timeScale = 0f;
            _pauseMenuCs.enabled = true;

            foreach(Collider collider in _canvasColliders)
            {
                collider.enabled = true;
            }

            /*MonoBehaviour[] keyPadScripts = _keyPad.GetComponents<MonoBehaviour>();
            //keyPadScripts = _keyPad.GetComponentsInChildren<MonoBehaviour>();
            _timerPaused.Value = false;
            _startedWcPuzzle.Value = false;

            _joyStickHead.enabled = false;
            _joyStick.transform.rotation = _joyStickRot;

            foreach(MonoBehaviour script in keyPadScripts)
            {
                script.enabled = false;
            }

            for (var index = 0; index < col.Length; index++)
            {
                var colliderItem = col[index];
                colliderItem.enabled = false;
            }

            for (int i = 0; i < _teleport.Length; i++)
            {
                _teleport[i].enabled = false;
            }
            for (int j = 0; j < _interactable.Length; j++)
            {
                _interactable[j].enabled = false;
            }*/
        }

        public void RestartGame()
        {
            SteamVR_LoadLevel.Begin(_sceneName);
        }

        public void ContinueGame()
        {
            _audio.volume = 1;
            _pauseMenuCs.enabled = false;
            _pausedGame.Raise(false);
            foreach (Collider collider in _canvasColliders)
            {
                collider.enabled = false;
            }
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
