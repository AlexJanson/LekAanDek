using UnityEngine;
using UnityEngine.UI;
using LekAanDek.Variables;
using Valve.VR;

namespace LekAanDek.UI
{
    /// <summary>
    /// This script is used to fade an image out at the start of the scene
    /// and fade an image in when the game is restarting
    /// </summary>
    public class Fade : MonoBehaviour
    {
        private float _fadeDuration = 2f;

        private void Start()
        {
            FadeToWhite();
            Invoke("FadeFromWhite", _fadeDuration);
        }
        private void FadeToWhite()
        {
            //set start color
            SteamVR_Fade.Start(Color.clear, 0f);
            //set and start fade to
            SteamVR_Fade.Start(Color.black, _fadeDuration);
        }
        private void FadeFromWhite()
        {
            //set start color
            SteamVR_Fade.Start(Color.black, 0f);
            //set and start fade to
            SteamVR_Fade.Start(Color.clear, _fadeDuration);
        }
    }
}
