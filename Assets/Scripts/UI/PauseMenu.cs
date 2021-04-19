using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;
using LekAanDek.Variables;

namespace LekAanDek
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
        private BoolVariable _timerPaused;

        [SerializeField]
        private BoolVariable _startedWcPuzzle;
        // Start is called before the first frame update
        void Start()
        {
            _teleport = FindObjectsOfType<Teleport>();
            _interactable = FindObjectsOfType<Interactable>();
            _pauseMenuCs.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("p"))
            {
                GamePaused();
            }
        }

        private void GamePaused()
        {
            _pauseMenuCs.enabled = true;
            _timerPaused.Value = false;
            _startedWcPuzzle.Value = false;

            for (int i = 0; i < _teleport.Length; i++)
            {
                _teleport[i].enabled = false;
            }
            for (int j = 0; j < _interactable.Length; j++)
            {
                _interactable[j].enabled = false;
            }
        }
    }
}
