using UnityEngine;
using System.Collections;
using Valve.VR;

namespace LekAanDek.UI
{
    /// <summary>
    /// This script is used to fade an image out at the start of the scene
    /// and fade an image in when the game is restarting
    /// </summary>
    public class Fade : MonoBehaviour
    {
        [SerializeField]
        private float _fadeDuration = 2f;

        [SerializeField]
        private float _buffer = 1f;

        private bool _startFading = false;

        [SerializeField]
        private Camera _camera;

        private void Start()
        {
            StartCoroutine(WaitCoroutine());
        }
        private void Update()
        {
            if(_startFading == true)
            {

            }
        }

        private void FadeTo()
        {
            //set start color
            SteamVR_Fade.View(Color.clear, 0f);
            //set and start fade to
            SteamVR_Fade.View(Color.black, _fadeDuration);
        }
        private void FadeFrom()
        {
            //set start color
            SteamVR_Fade.View(Color.black, 1f);
            //set and start fade to
            SteamVR_Fade.View(Color.clear, _fadeDuration);
        }

        IEnumerator WaitCoroutine()
        {
           yield return new WaitForSeconds(_buffer);
            FadeFrom();
        }
    }
}
