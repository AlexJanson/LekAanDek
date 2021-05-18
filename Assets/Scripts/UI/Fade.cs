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

        private void Start() => StartCoroutine(FadeOutCoroutine());

  
        private void FadeTo()
        {
            //set start color
            SteamVR_Fade.View(Color.clear, 0);
            //set and start fade to
            SteamVR_Fade.View(Color.black, _fadeDuration);
        }

        IEnumerator FadeOutCoroutine()
        {
            SteamVR_Fade.View(Color.black, 0);

            yield return new WaitForSeconds(_buffer);

            SteamVR_Fade.View(Color.clear, _fadeDuration);
        }
    }
}
