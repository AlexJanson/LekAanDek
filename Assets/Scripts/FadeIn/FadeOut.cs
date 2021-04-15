using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LekAanDek.UI.FadeOut
{
    /// <summary>
    /// This script is used to fade an image out at the start of the scene
    /// so the player won't see water go through the ship at he start
    /// </summary>
    public class FadeOut : MonoBehaviour
    {

        [SerializeField]
        private Image _fadeOutImage;

        [SerializeField]
        private float _fadeOutTime;
        // Start is called before the first frame update
        void Start()
        {
            _fadeOutImage.canvasRenderer.SetAlpha(1.0f);
            FadeImageOut();
        }

        private void FadeImageOut()
        {
            _fadeOutImage.CrossFadeAlpha(0, _fadeOutTime, false);
        }
    }
}
