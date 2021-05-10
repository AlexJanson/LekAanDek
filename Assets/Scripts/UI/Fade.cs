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

        private void Start()
        {
            StartCoroutine(WaitCoroutine());
        }
        private void FadeTo()
        {
            //set start color
            SteamVR_Fade.Start(Color.clear, 0f);
            //set and start fade to
            SteamVR_Fade.Start(Color.black, _fadeDuration);
        }
        private void FadeFrom()
        {
            //set start color
            SteamVR_Fade.Start(Color.black, 1f);
            //set and start fade to
            SteamVR_Fade.Start(Color.clear, _fadeDuration);
        }

        IEnumerator WaitCoroutine()
        {
           yield return new WaitForSeconds(_buffer);
            FadeFrom();
        }
    }
}
