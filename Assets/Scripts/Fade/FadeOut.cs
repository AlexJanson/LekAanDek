using UnityEngine;
using UnityEngine.UI;
using LekAanDek.Variables;

namespace LekAanDek.UI.FadeOut
{
    /// <summary>
    /// This script is used to fade an image out at the start of the scene
    /// and fade an image in when the game is restarting
    /// </summary>
    public class FadeOut : MonoBehaviour
    {

        [SerializeField]
        private Image _fadeImage;

        [SerializeField]
        private float _fadeTime;

        [SerializeField]
        private BoolVariable _fading;

        // Start is called before the first frame update
        void Start()
        {
            _fading.Value = false;
            _fadeImage.canvasRenderer.SetAlpha(1.0f);
            FadeImageOut();
        }

        private void Update()
        {
            if (_fading.Value == true)
            {
                FadeImageIn();
                _fading.Value = false;
            }
        }

        private void FadeImageOut()
        {
            _fadeImage.CrossFadeAlpha(0, _fadeTime, false);
        }

        public void FadeImageIn()
        {
            _fadeImage.CrossFadeAlpha(1, _fadeTime, false);
        }
    }
}
